using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Presentation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();

        }
    }

}
