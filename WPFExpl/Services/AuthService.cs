using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFExpl.Services
{
    public class AuthService
    {
        private static AuthService instance = null;
        private static readonly object padlock = new object();

        private AuthService()
        {

        }

        public bool Login(string username, string password) =>
            string.Compare(username, "a") == 0 
            && string.Compare(password, "b") == 0;

        public static AuthService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AuthService();
                    }
                }

                return instance;
            }
        }
    }
}
