using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPFExpl.Services;

namespace WPFExpl
{
    class LoginViewModel : GenericViewModel
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
            set {
                SetPropertyValue(ref username, value);
                LoginCommand.InvokeCanExecuteChanged();
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set {
                SetPropertyValue(ref password, value);
                LoginCommand.InvokeCanExecuteChanged();
            }
        }

        public GenericDelegateCommand LoginCommand { get; }

        public LoginViewModel()
        {
            Message = "User not logged in.";
            LoginCommand = new GenericDelegateCommand(p => Login(), p => CheckCanLogin());
        }

        public void Login()
        {
            var loginResult = AuthService.Instance.Login(Username, Password);

            Message = loginResult
                ? "Welcome, " + username
                : "Wrong credentials";
            ResetUsernameAndPassword();
        }

        private bool CheckCanLogin()
        {
            return !string.IsNullOrEmpty(Username)
                && !string.IsNullOrEmpty(Password);
        }

        private void ResetUsernameAndPassword()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }

    class GenericViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetPropertyValue<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class GenericDelegateCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;
        private static readonly Func<object, bool> DefaultCanExecute = (p) => true;

        public event EventHandler CanExecuteChanged;

        public GenericDelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute ?? DefaultCanExecute;
        }

        public bool CanExecute(object parameter) => canExecute(parameter);
        public void Execute(object parameter) => execute(parameter);
        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
