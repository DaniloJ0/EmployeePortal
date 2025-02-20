using Core;
using Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.WPF.Views;
using System.IO;
using System.Windows;


namespace Presentation.WPF
{
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

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (!TestDatabaseConnection(connectionString))
            {
                MessageBox.Show("No se pudo establecer la conexión a la base de datos. La aplicación se cerrará.",
                                "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);

                Environment.Exit(0);
            }

            services.AddSingleton<IConfiguration>(configuration);

            // Capa de infraestructura (base de datos y repositorios)
            services.AddInfrastructure(configuration);

            // Capa de aplicación (servicios de aplicación)
            services.AddApplication();

            // Ventanas de WPF
            services.AddTransient<MainWindow>();
            services.AddTransient<PortalEmployee>();
            services.AddTransient<Register>();
        }


        private static bool TestDatabaseConnection(string? connectionString)
        {
            if (connectionString is null) return false;

            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de conexión a la base de datos: {ex.Message}");
                return false;
            }
        }
    }

}
