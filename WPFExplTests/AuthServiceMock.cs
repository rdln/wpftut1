using System.Collections.Generic;
using WPFExpl.Services;

namespace WPFExplTests
{
    class AuthServiceMock : IAuthService
    {
        private readonly bool returnValue;
        public readonly List<Identity> loginsLog = new List<Identity>();


        public AuthServiceMock(bool returnValue)
        {
            this.returnValue = returnValue;
        }

        public bool Login(string username, string password)
        {
            loginsLog.Add(new Identity(username, password));
            return returnValue;
        }
    }
}
