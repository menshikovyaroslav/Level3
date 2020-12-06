using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _hosting;

        public static IHost Hosting
        {
            get
            {
                if (_hosting != null) return _hosting;
                _hosting = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs()).ConfigureServices(ConfigureServices).Build();
                return _hosting;
            }
        }

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif

            services.AddSingleton<MainViewModel>();

        }

        public static IServiceProvider Services { get { return Hosting.Services; } }
    }
}
