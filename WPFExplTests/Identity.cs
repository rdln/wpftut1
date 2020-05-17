namespace WPFExplTests
{
    class Identity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Identity(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
