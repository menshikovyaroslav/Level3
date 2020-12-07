using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace wpfMutex
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Mutex _instanceMutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            bool createdNew;

            _instanceMutex = new Mutex(true, $"{Environment.UserName};MyMutex", out createdNew);
            if (!createdNew)
            {
                _instanceMutex = null;
                MessageBox.Show("У Вас уже запущена копия данного приложения !");
                Application.Current.Shutdown();
                return;
            }

            base.OnStartup(e);
        }
    }
}
