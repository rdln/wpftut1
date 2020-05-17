using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WPFExpl;

namespace WPFExplTests
{
    [TestClass]
    public class LoginViewModelTests
    {
        [TestMethod]
        public void TestCorrectCredentialsAreSent()
        {
            var authService = new AuthServiceMock(true);
            var viewModel = new LoginViewModel(authService);

            const string username = "user";
            const string password = "password";
            viewModel.Username =username;
            viewModel.Password = password;

            viewModel.LoginCommand.Execute(null);

            Assert.IsTrue(authService.loginsLog.Any());
            
            var usedIdentity = authService.loginsLog.First();
            Assert.AreEqual(username, usedIdentity.Username);
            Assert.AreEqual(password, usedIdentity.Password);
        }

        [TestMethod]
        public void TestSuccessfulLoginHandledCorrectly()
        {
            var authService = new AuthServiceMock(true);
            var viewModel = new LoginViewModel(authService);

            const string username = "user";
            const string password = "password";
            viewModel.Username = username;
            viewModel.Password = password;

            viewModel.LoginCommand.Execute(null);
            Assert.AreEqual("Welcome, " + username, viewModel.Message);
        }

        [TestMethod]
        public void TestUnsuccessfulLoginHandledCorrectly()
        {
            var authService = new AuthServiceMock(false);
            var viewModel = new LoginViewModel(authService);

            const string username = "user";
            const string password = "password";
            viewModel.Username = username;
            viewModel.Password = password;

            viewModel.LoginCommand.Execute(null);
            Assert.AreEqual("Wrong credentials", viewModel.Message);
        }

        [TestMethod]
        public void TestConditionsLoginCommandEnabled()
        {
            var viewModel = new LoginViewModel(new AuthServiceMock(false));

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
