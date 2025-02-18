using Infrastructure.Persistance;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationDbContext _dbContext;

        public MainWindow(ApplicationDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Ejemplo: Verificar conexión a la base de datos
            var employees = _dbContext.Employees.ToList();
            MessageBox.Show($"Hay {employees.Count} empleados en la base de datos.");
        }
    }
}