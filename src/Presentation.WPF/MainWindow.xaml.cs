using Domain.Arls;
using Domain.Employees;
using Domain.Epss;
using Domain.Pensions;
using Domain.Primitives;
using Presentation.WPF.Views;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.WPF
{

    public partial class MainWindow : Window
    {
        private readonly IArlRepository _arlRepository;
        private readonly IPensionRepository _pensionRepository;
        private readonly IEpsRepository _epsRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MainWindow(IArlRepository arlRepository, IPensionRepository pensionRepository, IEpsRepository epsRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _arlRepository = arlRepository;
            _pensionRepository = pensionRepository;
            _epsRepository = epsRepository;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PortalEmployee portalEmployee = new(_arlRepository,_pensionRepository, _epsRepository, _employeeRepository, _unitOfWork);
            portalEmployee.Show();

            this.Close();
        }
    }
}