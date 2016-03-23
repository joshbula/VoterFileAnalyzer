using Excel;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        string MembershipExcelFilePath = "";
        string VoterHistoryFolderPath = "";
        string VoterExtractFolderPath = "";

        int MemberCount = 0;
        int MembersRegisteredToVote = 0;

        List<Member> Members = new List<Member>();
        List<Vote> Votes = new List<Vote>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You Clicked Exit");
        }

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

        private async void btnImportFiles_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfAllFilesComplete())
            {
                btnImportFiles.Content = "Importing...";
                btnImportFiles.IsEnabled = false;

                MemberCount = ImportMembers();
                ImportVoters();
                ImportHistory();
                tcMain.SelectedIndex = 1;
            }


        }

        private bool CheckIfAllFilesComplete()
        {
            return true;

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

        private void tcMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckIfAllFilesComplete();
        }


        #region HelperFunctions




        private int ImportMembers()
        {
            FileStream stream = File.Open(MembershipExcelFilePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet ds = excelReader.AsDataSet();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var member = new Member();
                DataRow row = ds.Tables[0].Rows[i];

                member.MemberID = Convert.ToInt32(row[0]);
                member.FirstName = row["FirstName"].ToString();
                member.LastName = row["LastName"].ToString();
                member.HomeCounty = row["HomeCounty"].ToString();
                member.HomeCity = row["HomeCity"].ToString();
                member.HomeEmail = row["HomeEmail"].ToString();
                member.TotalVotes = 0;

                Members.Add(member);
            }



            ds.Dispose();
            excelReader.Close();
            // dgMembers.ItemsSource = Members;
            return Members.Count();


        }

        private async void ImportVoters()
        {
            int RegisteredVoters = 0;

            string[] files = Directory.GetFiles(VoterExtractFolderPath);

            foreach (var file in files)
            {
               
                await Task.Run(() =>
                {
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

                                if (fields[28] == "ACT")
                                    RegisteredVoters += 0;
                            }

                        }

                    }

                });
                lblStatus.Text = "Reading " + file + "  So far, found " + RegisteredVoters.ToString() + " members who are registered.";
                RegisteredVotersTextBox.Text = RegisteredVoters.ToString();
            }

           

        }

        private void ImportHistory()
        {

        }


        #endregion


    }
}
