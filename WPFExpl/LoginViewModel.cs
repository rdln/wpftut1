using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFExpl
{
    class LoginViewModel
    {
        public string Message { get; set; }

        public LoginViewModel()
        {
            Message = "User not logged in.";
        }
    }
}
