using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace VoterFileAnalyzer
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ImportPage());
        }

        /// <summary>
        /// Exports the Members table to an excel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                using (var db = new VoterFileContext())
                {
                    DataSet ds = new DataSet();
                    DataTable dt = ds.Tables.Add("Members");
                    string[] columns = typeof(Member).GetProperties().Select(p => p.Name).ToArray();
                    foreach (var column in columns)
                    {
                        dt.Columns.Add(column);
                    }

                    var Members = db.Members.OrderBy(p => p.LastName);
                    foreach (var m in Members)
                    {
                        DataRow r = dt.NewRow();
                        r["FMEAID"] = m.FMEAID;
                        r["FirstName"] = m.FirstName;
                        r["LastName"] = m.LastName;
                        r["HomeCounty"] = m.HomeCounty;
                        r["HomeCity"] = m.HomeCity;
                        r["HomeEmail"] = m.HomeEmail;
                        r["RegisteredTovote"] = m.RegisteredTovote;
                        r["Party"] = m.Party;
                        r["VoterID"] = m.VoterID;
                        r["TotalVotes"] = m.TotalVotes;
                        r["FirstElection"] = m.FirstElection;
                        r["LastElection"] = m.LastElection;

                        dt.Rows.Add(r);

                    }

                    ExcelExporter.ExcelGenerator(dt, "Members", FilePath);
                }

                MessageBox.Show("Excel File Saved");
            }
        }
    }
}
