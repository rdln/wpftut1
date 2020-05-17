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

        public string Message { get; set; }

        public LoginViewModel()
        {
            Message = "User not logged in.";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
