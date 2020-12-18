using Microsoft.Reporting.WinForms;
using report.MailDbDataSetTableAdapters;
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

namespace report
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ReportViewer.Load += ReportViewerOnLoad;
        }

        private void ReportViewerOnLoad(object sender, EventArgs eventArgs)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            MailDbDataSet dataset = new MailDbDataSet();
            dataset.BeginInit();
            reportDataSource.Name = "RecipientsDataSet";
            reportDataSource.Value = dataset.Recipients;
            ReportViewer.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer.LocalReport.ReportPath = "../../Report1.rdlc";
            dataset.EndInit();
            RecipientsTableAdapter recipientsTableAdapter = new RecipientsTableAdapter { ClearBeforeFill = true };
            recipientsTableAdapter.Fill(dataset.Recipients);
            ReportViewer.RefreshReport();
        }

    }
}
