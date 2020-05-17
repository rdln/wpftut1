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
            viewModel.Login();
        }
    }
}
