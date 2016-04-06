using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.IO;
using System.IO.Compression;
using System.Data.SqlClient;

namespace VoterFileAnalyzer
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            try
            {

                InitializeComponent();

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred in the Main Page: " + ex.ToString());
            }


        }

        private void LoadData()
        {
            cbElectionDate.ItemsSource = ((IListSource)DataFunctions.ElectionDates()).GetList();

            ElectionCountySummary.Visibility = Visibility.Hidden;//hide until something is selected from the combobox

            using (var db = new VoterFileContext())
            {
                int Members = db.Members.Count();


                if (Members == 0)
                {
                    MemberCountTextBlock.Text = "No data has been imported yet. \n\n\n";
                }
                else
                {
                    int RegisteredVoters = db.Members.Where(p => p.RegisteredTovote == true).Count();
                    int HasVoted = db.Members.Where(p => p.TotalVotes > 0).Count();

                    MemberCountTextBlock.Text = "Members: " + Members.ToString() + "\nRegistered To Vote: " + RegisteredVoters.ToString() + "\nMembers Who Have Voted: " + HasVoted.ToString();
                    MemberCountTextBlock.Text += "\n";
                    double PercentRegistered = 0.00;
                    double PercentHasVoted = 0.00;
                    PercentRegistered = Convert.ToDouble(RegisteredVoters) / Convert.ToDouble(Members);
                    PercentHasVoted = Convert.ToDouble(HasVoted) / Convert.ToDouble(Members);

                    MemberCountTextBlock.Text += String.Format("{0:P2}", PercentRegistered) + " of your membership is registered to vote. \n";
                    MemberCountTextBlock.Text += String.Format("{0:P2}", PercentHasVoted) + " of your membership has voted in a past election.\n\n";


                }

            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ImportPage());
        }


        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var fd = new SaveFileDialog();
            fd.Filter = "Excel 2007+ Files (*.xlsx)|*.xlsx";
            if (fd.ShowDialog() == true)
            {
                string FilePath = fd.FileName;
                if (!FilePath.EndsWith(".xlsx"))
                {
                    FilePath += ".xlsx";
                }
                ExcelExporter.ExcelGenerator(DataFunctions.GetMembers(), "Members", FilePath);
            }

            MessageBox.Show("Excel File Saved");
        }

        private void AllMembers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReportViewerPage("AllMembers.rdlc", DataFunctions.GetMembers(), "Members"));

        }

        private void AllByCounty_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReportViewerPage("GroupedByCounty.rdlc", DataFunctions.GetMembers(), "Members"));
        }

        private void CountySummary_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReportViewerPage("Counties.rdlc", DataFunctions.VotersByCounty(), "Counties"));
        }

        private void cbElectionDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ElectionCountySummary.Visibility = Visibility.Visible;
            DateTime ElectionDate = Convert.ToDateTime(cbElectionDate.SelectedValue);
            using (var db = new VoterFileContext())
            {
                int VoteCount = db.Votes.Where(p => p.ElectionDate == ElectionDate).Count();
                ElectionCountTextBlock.Text = VoteCount.ToString() + " members voted in the election on " + String.Format("{0:d}", ElectionDate) + ".";
            }

        }

        private void ElectionCountySummary_Click(object sender, RoutedEventArgs e)
        {
            DateTime ElectionDate = Convert.ToDateTime(cbElectionDate.SelectedValue);
            this.NavigationService.Navigate(new ReportViewerPage("VotesByCounty.rdlc", DataFunctions.VotesByCounty(ElectionDate), "VotesByCounty", string.Format("{0:d}", ElectionDate)));
        }

        private void MembersByParty_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReportViewerPage("MembersByParty.rdlc", DataFunctions.MembersByParty(), "MembersByParty"));
        }

        private void BackupDatabase_Click(object sender, RoutedEventArgs e)
        {
            var fd = new SaveFileDialog();
            fd.Filter = "Backup File (*.bak)|*.bak";
            if (fd.ShowDialog() == true)
            {
                string FilePath = fd.FileName;

                if (!FilePath.EndsWith(".bak"))
                {
                    FilePath += ".bak";
                }

                try
                {
                    using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VoterFileConnection"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("BACKUP DATABASE VoterFileConnection TO DISK = @FilePath", conn);
                        cmd.Parameters.AddWithValue("@FilePath", FilePath);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                MessageBox.Show("Database Backup Saved");
            }

        }

        private void RestoreDatabase_Click(object sender, RoutedEventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Backup Files (*.bak)|*.bak";
            if (fd.ShowDialog() == true)
            {
                if (fd.FileName.EndsWith(".bak"))
                {
                    try
                    {
                        string query = @"USE master; ALTER DATABASE VoterFileConnection SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE VoterFileConnection FROM DISK = @FilePath WITH REPLACE; ALTER DATABASE VoterFileConnection SET MULTI_USER;";
                        using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VoterFileConnection"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@FilePath", fd.FileName);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        LoadData();
                        MessageBox.Show("Database Restored");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                   
                }
            }
        }
    }
}
