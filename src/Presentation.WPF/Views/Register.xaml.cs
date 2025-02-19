using Core.Interfaces;
using Domain.Arls;
using Domain.Employees;
using Domain.Epss;
using Domain.Pensions;
using Domain.Primitives;
using Domain.Users;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        public Register(IArlRepository arlRepository, IPensionRepository pensionRepository, IEpsRepository epsRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IUserRepository userRepositor, IPasswordHasher passwordHasher)
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

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(_arlRepository, _pensionRepository, _epsRepository, _employeeRepository, _unitOfWork, _userRepository, _passwordHasher);
            mainWindow.Show();

            this.Close();
        }

        private async void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailField.Text;
            string password = PasswordField.Password;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("El correo y la constraseña no pueden estar vacía.");
                return;
            }

            if (Email.Create(email) is not Email emailPassed)
            {
                MessageBox.Show("El correo no es válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (await _userRepository.GetByEmail(emailPassed))
            {
                MessageBox.Show("Este correo ya ha sido registrado.");
                return;
            }
            

            string hashedPassword = _passwordHasher.HashPassword(password);

            User user = new
            (
                new UserId(Guid.NewGuid()),
                emailPassed,
                hashedPassword,
                DateTime.Now
            );

            await _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync();

            MessageBox.Show($"Usuario con email {email} fue registrado exitosamente.");

            MainWindow mainWindow = new(_arlRepository, _pensionRepository, _epsRepository, _employeeRepository, _unitOfWork, _userRepository, _passwordHasher);
            mainWindow.Show();

            this.Close();
        }
    }
}
