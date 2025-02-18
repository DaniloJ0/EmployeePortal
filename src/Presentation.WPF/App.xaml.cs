using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;
using Infrastructure;
using Core;


namespace Presentation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider serviceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            ConfigureServices(services);

            serviceProvider = services.BuildServiceProvider();

            // Mostrar la ventana principal
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

        }
        private static void ConfigureServices(IServiceCollection services)
        {
            // Configurar appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            services.AddSingleton<IConfiguration>(configuration);

            // Capa de infraestructura (base de datos y repositorios)
            services.AddInfrastructure(configuration);

            // Capa de aplicación (servicios de aplicación)
            services.AddApplication();

            // Ventanas de WPF
            services.AddTransient<MainWindow>();
        }
    }

}
