using System.Windows;
using WPFExpl.Services;

namespace WPFExpl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginViewModel viewModel;

        public MainWindow()
        {
            viewModel = new LoginViewModel();

            DataContext = viewModel;

            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = textboxUsername.Text;
            var password = textboxPassword.Text;

            var loginResult = AuthService.Instance.Login(username, password);

            if (loginResult)
            {
                textboxUsername.Visibility = Visibility.Hidden;
                textboxPassword.Visibility = Visibility.Hidden;
                viewModel.Message = "Welcome, " + username;
                viewModel.OnPropertyChanged(nameof(viewModel.Message));
            }
            else
            {
                textboxUsername.Clear();
                textboxPassword.Clear();
                viewModel.Message = "Wrong credentials";
                viewModel.OnPropertyChanged(nameof(viewModel.Message));
            }
        }
    }
}
