﻿using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;
using EnviTech.Db;
using EnviTech.ViewModel;
using EnviTech.StartupHelpers;

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
                    
                    //todo: write wrapper function...
                    services.AddScoped<IDateRepository,DateRepository>();
                    services.AddScoped<IOperatorsRepository,OperatorsRepository>();
                    services.AddScoped<IValuesRepository, ValuesRepository>();
                    services.AddScoped<IDataRepository, DataRepository>();
                    services.AddScoped<RepositoryFacade>();

                    services.AddFormFactory<DataForm>();
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
