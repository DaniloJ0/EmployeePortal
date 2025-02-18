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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        //private void BtnShowEmployees_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        // Obtener el número de empleados desde la base de datos
        //        int employeeCount = _dbContext.Arls.Count();

        //        // Mostrar el número en el Label
        //        LblEmployeeCount.Content = $"Número de empleados: {employeeCount}";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al obtener empleados: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }
}