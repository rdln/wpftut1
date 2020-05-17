using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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
            LoginCommand = new LoginDelegateCommand(this);
        }

        public ICommand LoginCommand { get; }

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

    class LoginDelegateCommand : ICommand
    {
        private readonly LoginViewModel viewModel;

        public event EventHandler CanExecuteChanged;

        public LoginDelegateCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Login();
        }
    }
}
