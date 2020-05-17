using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFExpl;

namespace WPFExplTests
{
    [TestClass]
    public class LoginViewModelTests
    {
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
