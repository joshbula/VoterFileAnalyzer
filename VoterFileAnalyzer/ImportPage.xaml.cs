using Excel;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VoterFileAnalyzer
{
    /// <summary>
    /// Interaction logic for ImportPage.xaml
    /// </summary>
    public partial class ImportPage : Page
    {
        string MembershipExcelFilePath = "";
        string VoterHistoryFolderPath = "";
        string VoterExtractFolderPath = "";

        List<Member> Members = new List<Member>();
        List<Vote> Votes = new List<Vote>();

        public ImportPage()
        {
            InitializeComponent();
        }


        #region Controls

        private void btnSelectMembershipFile_Click(object sender, RoutedEventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Excel 2007+ Files (*.xlsx)|*.xlsx";
            if (fd.ShowDialog() == true)
            {
                MembershipExcelFilePath = fd.FileName;
                lblMembershipFilePath.Text = MembershipExcelFilePath;
                lblMembershipFilePath.Foreground = Brushes.Green;

            }
        }

        private void btnSelectVoterExtract_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog();
            dlg.IsFolderPicker = true;
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                VoterExtractFolderPath = dlg.FileName;
                lblVoterExtractPath.Text = VoterExtractFolderPath;
                lblVoterExtractPath.Foreground = Brushes.Green;
            }

        }

        private void btnSelectVoterHistory_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog();
            dlg.IsFolderPicker = true;
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                VoterHistoryFolderPath = dlg.FileName;
                lblVoterHistoryPath.Text = VoterHistoryFolderPath;
                lblVoterHistoryPath.Foreground = Brushes.Green;
            }
        }


        private void tcMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckIfAllFilesComplete();
        }

        private async void btnImportFiles_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfAllFilesComplete())
            {
                var progressIndicator = new Progress<string>(ReportProgress);
                int importedMembers = await ImportMembers(progressIndicator);
            }
            else
            {
                tbStatus.Text = "File or Folders missing! Use the buttons to to select everything.";
            }
        }

        #endregion




        #region HelperFunctions

        private bool CheckIfAllFilesComplete()
        {
            lblReportErrors.Text = "";

            if (MembershipExcelFilePath != "" && VoterExtractFolderPath != "" && VoterHistoryFolderPath != "")
            {
                return true;
            }
            else
            {
                if (MembershipExcelFilePath == "")
                    lblReportErrors.Text += "Membership Excel File is missing. ";

                if (VoterExtractFolderPath == "")
                    lblReportErrors.Text += "Voter Extract Folder is missing. ";

                if (VoterHistoryFolderPath == "")
                    lblReportErrors.Text += "Voter History Folder is missing. ";

                return false;
            }
        }

        async Task<int> ImportMembers(IProgress<string> progress)
        {
            FileStream stream = File.Open(MembershipExcelFilePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet ds = excelReader.AsDataSet();


            int processCount = await Task.Run<int>(() =>
            {
                int tempCount = 0;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var member = new Member();
                    DataRow row = ds.Tables[0].Rows[i];

                    member.FMEAID = Convert.ToInt32(row[0]);
                    member.FirstName = row["FirstName"].ToString();
                    member.LastName = row["LastName"].ToString();
                    member.HomeCounty = row["HomeCounty"].ToString();
                    member.HomeCity = row["HomeCity"].ToString();
                    member.HomeEmail = row["HomeEmail"].ToString();
                    member.TotalVotes = 0;
                    member.LastElection = null;
                    Members.Add(member);

                    if (progress != null)
                    {
                        progress.Report("Importing Members: " + tempCount.ToString());
                    }

                    tempCount++;

                }



                //Get VoterExtract Info

                string[] extractFiles = Directory.GetFiles(VoterExtractFolderPath);

                foreach (var file in extractFiles)
                {
                    string filename = System.IO.Path.GetFileName(file);

                    using (TextReader tr = File.OpenText(file))
                    {
                        string line;
                        while ((line = tr.ReadLine()) != null)
                        {
                            string[] fields = line.Split('\t');

                            string FirstName = fields[4];
                            string LastName = fields[2];
                            string HomeCity = fields[9];

                            var member = Members.Where(p => p.FirstName == FirstName && p.LastName == LastName && p.HomeCity == HomeCity).OrderByDescending(p => p.MemberID).FirstOrDefault();
                            if (member != null)
                            {
                                member.VoterID = Convert.ToInt32(fields[1]);
                                member.RegisteredTovote = fields[28] == "ACT" ? true : false;
                                member.Party = fields[23];
                               
                                if (progress != null)
                                {
                                    progress.Report("Found Voter Match in " + filename + " - \n" + member.FirstName + " " + member.LastName);
                                }

                            }

                        }

                    }

                }


                //Get VoterHistory

                string[] historyFiles = Directory.GetFiles(VoterHistoryFolderPath);

                foreach (var file in historyFiles)
                {
                    string filename = System.IO.Path.GetFileName(file);

                    using (TextReader tr = File.OpenText(file))
                    {
                        string line;
                        while ((line = tr.ReadLine()) != null)
                        {
                            string[] fields = line.Split('\t');

                            int voterId = Convert.ToInt32(fields[1]);
                            DateTime ElectionDate = Convert.ToDateTime(fields[2]);
                            string ElectionType = fields[3];
                            string VoteType = fields[4];


                            var member = Members.Where(p => p.VoterID == voterId).OrderByDescending(p => p.MemberID).FirstOrDefault();
                            if (member != null)
                            {
                                member.TotalVotes += 1;

                                if (member.FirstElection == null || member.FirstElection > ElectionDate)
                                {
                                    member.FirstElection = ElectionDate;
                                }

                                if (member.LastElection == null || member.LastElection < ElectionDate)
                                {
                                    member.LastElection = ElectionDate;
                                }

                                var vote = new Vote()
                                {
                                    VoterID = voterId,
                                    ElectionDate = ElectionDate,
                                    ElectionType = ElectionType,
                                    VoteType = VoteType
                                };

                                Votes.Add(vote);


                                //db.SaveChanges();
                                if (progress != null)
                                {
                                    progress.Report("Loading Voter History: " + filename + " - \n\nFound Member:\n" + member.FirstName + " " + member.LastName);
                                }
                            }

                        }

                    }
                }



                using (var db = new VoterFileContext())
                {

                    db.Database.ExecuteSqlCommand("DELETE FROM Members");
                    db.Database.ExecuteSqlCommand("DELETE FROM Votes");

                    int i = 0;
                    try
                    {
                        foreach (var member in Members)
                        {
                            progress.Report("Saving to Database " + i.ToString());
                            db.Members.Add(member);
                            db.SaveChanges();
                            var votes = Votes.Where(p => p.VoterID == member.VoterID);
                            foreach (var vote in votes)
                            {
                                vote.MemberID = member.MemberID;
                                db.Votes.Add(vote);
                                db.SaveChanges();
                            }

                            i++;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }


                }//end using

                progress.Report("Finished!");

                return tempCount;
            });



            Debug.WriteLine("Finished importing Membership List");

            ds.Dispose();
            excelReader.Close();
            // dgMembers.ItemsSource = Members;
            return processCount;

        }


        void ReportProgress(string Value)
        {
            btnImportFiles.Content = "Importing...";
            btnImportFiles.IsEnabled = false;
            tbStatus.Text = Value;
        }


        #endregion
    }
}
