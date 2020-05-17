using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFExpl;

namespace WPFExplTests
{
    [TestClass]
    public class LoginViewModelTests
    {
        [TestMethod]
        public void TestCorrectCredentialsAreSent()
        {
            var viewModel = new LoginViewModel();

            viewModel.Username = "user";
            viewModel.Password = "password";

            viewModel.LoginCommand.Execute(null);
            Assert.IsTrue(false, "How do I check the values received by the LoginService?");
        }

        [TestMethod]
        public void TestSuccessfulLoginHandledCorrectly()
        {
            var viewModel = new LoginViewModel();

            const string username = "user";
            const string password = "password";

            viewModel.Username = username;
            viewModel.Password = password;

            viewModel.LoginCommand.Execute(null);
            Assert.AreEqual("Welcome, " + username, viewModel.Message);
        }

        [TestMethod]
        public void TestConditionsLoginCommandEnabled()
        {
            var viewModel = new LoginViewModel();

            viewModel.Username = string.Empty;
            viewModel.Password = string.Empty;
            Assert.IsFalse(viewModel.LoginCommand.CanExecute(null));

            viewModel.Username = "a";
            viewModel.Password = string.Empty;
            Assert.IsFalse(viewModel.LoginCommand.CanExecute(null));

            viewModel.Username = string.Empty;
            viewModel.Password = "b";
            Assert.IsFalse(viewModel.LoginCommand.CanExecute(null));

            viewModel.Username = "a";
            viewModel.Password = "b";
            Assert.IsTrue(viewModel.LoginCommand.CanExecute(null));
        }
    }
}
