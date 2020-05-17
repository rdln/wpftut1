using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
                this.labelUsermessage.Content = "Welcome, " + username;
            }
            else
            {
                textboxUsername.Clear();
                textboxPassword.Clear();
                this.labelUsermessage.Content = "Wrong credentials";
            }
        }
    }
}
