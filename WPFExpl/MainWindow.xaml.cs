using System.Windows;
using WPFExpl.Services;

namespace WPFExpl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var viewModel = new LoginViewModel();

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
                //this.labelUsermessage.Content = "Welcome, " + username;
            }
            else
            {
                textboxUsername.Clear();
                textboxPassword.Clear();
                //this.labelUsermessage.Content = "Wrong credentials";
            }
        }
    }
}
