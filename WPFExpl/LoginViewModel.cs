using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace WPFExpl
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string message;
        public string Message {
            get
            {
                return message;
            }
            set
            {
                SetPropertyValue(ref message, value);
            }
        }

        public LoginViewModel()
        {
            Message = "User not logged in.";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetPropertyValue<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName);
            }
        }
    }
}
