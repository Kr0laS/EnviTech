using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            AppHost = BuildHost();
        }

        static IHost BuildHost()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((ctx, services) =>
                {

                })
                .Build();
        }
    }
}
