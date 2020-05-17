namespace WPFExpl.Services
{
    class AuthService : IAuthService
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
