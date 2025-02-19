using Core.Interfaces;
using Domain.Arls;
using Domain.Employees;
using Domain.Epss;
using Domain.Pensions;
using Domain.Primitives;
using Domain.Users;
using Domain.ValueObjects;
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
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        public MainWindow(IArlRepository arlRepository, IPensionRepository pensionRepository, IEpsRepository epsRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IUserRepository userRepositor, IPasswordHasher passwordHasher)
        {
            InitializeComponent();
            _arlRepository = arlRepository;
            _pensionRepository = pensionRepository;
            _epsRepository = epsRepository;
            _employeeRepository = employeeRepository;
            _userRepository = userRepositor;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailField.Text;
            string password = PasswordField.Password;

            if (Email.Create(email) is not Email emailResult)
            {
                MessageBox.Show("El correo no es válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User? user = await _userRepository.GetByEmailAsync(emailResult);

            if (user == null || !(_passwordHasher.VerifyPassword(password, user.Password)))
            {
                MessageBox.Show("Correo o contraseña invalida.");
                return;
            }

            PortalEmployee portalEmployee = new(_arlRepository,_pensionRepository, _epsRepository, _employeeRepository, _unitOfWork);
            portalEmployee.Show();

            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new(_arlRepository, _pensionRepository, _epsRepository, _employeeRepository, _unitOfWork, _userRepository, _passwordHasher);
            register.Show();

            this.Close();
        }
    }
}