using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using EnviTech.Db;
using EnviTech.ViewModel;

namespace EnviTech
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            //Takes connection string from App.config file.
            var connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["EnviTechConnectionString"].ConnectionString;

            AppHost = BuildHost(connectionString);

        }

        static IHost BuildHost(string dbString)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((ctx, services) =>
                {
                    services.AddScoped<IDbConnection>(t => new SqlConnection(dbString));
                    services.AddSingleton<IDateRepository,DateRepository>();

                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();

            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();

            base.OnExit(e);
        }
    }
}
