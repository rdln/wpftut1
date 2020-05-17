using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (!EqualityComparer<string>.Default.Equals(message, value))
                {
                    message = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
                }
            }
        }

        public LoginViewModel()
        {
            Message = "User not logged in.";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
