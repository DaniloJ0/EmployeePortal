using Core.Interfaces;
using Domain.Users;
using Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Presentation.WPF.Views;
using System.Windows;

namespace Presentation.WPF
{

    public partial class MainWindow : Window
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IServiceProvider _serviceProvider;

        public MainWindow( IUserRepository userRepositor, IPasswordHasher passwordHasher, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userRepository = userRepositor;
            _passwordHasher = passwordHasher;
            _serviceProvider = serviceProvider;
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

            var registerWindow = _serviceProvider.GetRequiredService<PortalEmployee>();
            registerWindow.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = _serviceProvider.GetRequiredService<Register>();
            registerWindow.Show();
            this.Close();
        }
    }
}