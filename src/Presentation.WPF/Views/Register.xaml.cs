using Core.Interfaces;
using Domain.Primitives;
using Domain.Users;
using Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Presentation.WPF.Views
{
    public partial class Register : Window
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;

        public Register(IUnitOfWork unitOfWork, IUserRepository userRepositor, IPasswordHasher passwordHasher, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userRepository = userRepositor;
            _passwordHasher = passwordHasher;
            _serviceProvider = serviceProvider;
            _unitOfWork = unitOfWork;
        }

        private void ReturnToMainWindow()
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ReturnToMainWindow();
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

            ReturnToMainWindow();
        }
    }
}
