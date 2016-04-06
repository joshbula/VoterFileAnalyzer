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
        public ReportViewerPage(string ReportFile, DataTable dt, string datatableName, string Parameter = null)
        {
            //TODO: change Parameter to a list of key/value pairs if any more reports are added that need parameters or multiple parameters per report.

            InitializeComponent();
            myReportViewer.Reset();
            ReportDataSource ds = new ReportDataSource(datatableName, dt);
            myReportViewer.LocalReport.DataSources.Add(ds);
            string reportFilePath = AppDomain.CurrentDomain.BaseDirectory + @"Reports\" + ReportFile;
            myReportViewer.LocalReport.ReportPath = reportFilePath;
            if (Parameter != null)
            {
                ReportParameter param = new ReportParameter();
                param.Name = "ElectionDate";
                param.Values.Add(Parameter);
                myReportViewer.LocalReport.SetParameters(param);
            }
            myReportViewer.RefreshReport();

        }
    }
}
