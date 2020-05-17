using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFExpl.Services;

namespace WPFExpl
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string message;
        public string Message {
            get => message;
            set => SetPropertyValue(ref message, value);
        }

        private string username;
        public string Username
        {
            get => username;
            set => SetPropertyValue(ref username, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetPropertyValue(ref password, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            Message = "User not logged in.";
        }

        public void Login()
        {
            var loginResult = AuthService.Instance.Login(Username, Password);

            Message = loginResult
                ? "Welcome, " + username
                : "Wrong credentials";
            ResetUsernameAndPassword();
        }

        private void ResetUsernameAndPassword()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        private void SetPropertyValue<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
