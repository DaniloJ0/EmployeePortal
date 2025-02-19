using Domain.Arls;
using Domain.Employees;
using Domain.Epss;
using Domain.Pensions;
using Domain.Primitives;
using System.Windows;

namespace Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private readonly IArlRepository _arlRepository;
        private readonly IPensionRepository _pensionRepository;
        private readonly IEpsRepository _epsRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public Register(IArlRepository arlRepository, IPensionRepository pensionRepository, IEpsRepository epsRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _arlRepository = arlRepository;
            _pensionRepository = pensionRepository;
            _epsRepository = epsRepository;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(_arlRepository, _pensionRepository, _epsRepository, _employeeRepository, _unitOfWork);
            mainWindow.Show();

            this.Close();
        }
    }
}
