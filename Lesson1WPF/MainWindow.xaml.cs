using Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using WpfApp1.Data;

namespace Lesson1WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // mssql
            // DBclass db = new DBclass();
            // dgEmails.ItemsSource = db.Messages;

            // postgres
            PgDb db = new PgDb();
            dgEmails.ItemsSource = db.Messages;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var mail = new Mail();
            //
          //  mail.SendMail();
        }
    }
}
