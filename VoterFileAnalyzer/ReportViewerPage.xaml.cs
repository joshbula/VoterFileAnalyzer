using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace VoterFileAnalyzer
{
    /// <summary>
    /// Interaction logic for ReportViewerPage.xaml
    /// </summary>
    public partial class ReportViewerPage : Page
    {
        public ReportViewerPage(string ReportFile)
        {
            InitializeComponent();
            myReportViewer.Reset();
            DataTable dt = DataFunctions.GetMembers();
            ReportDataSource ds = new ReportDataSource("Members", dt);
            myReportViewer.LocalReport.DataSources.Add(ds);
            myReportViewer.LocalReport.ReportEmbeddedResource = "VoterFileAnalyzer.Reports." + ReportFile;
            myReportViewer.RefreshReport();

        }
    }
}
