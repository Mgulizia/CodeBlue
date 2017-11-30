using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlue.Controllers;
using CodeBlue.Models;
using CodeBlue.ViewModels.Accounts;

namespace CodeBlue.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Login(string returnUrl)
        {

        }

        [TestMethod]
        public void Login(LoginViewModel model, string returnUrl)
        {

        }

        [TestMethod]
        public void Index()
        {
            
        }

        [TestMethod]
        public void Create(ApplicationUser user)
        {
            
        }

        [TestMethod]
        public void Edit(string id)
        {
            
        }

        [TestMethod]
        public void Save(ApplicationUserAddViewModel model)
        {
            
        }

        [TestMethod]
        public void Update(ApplicationUserEditViewModel model)
        {
            
        }

        [TestMethod]
        public void ConfirmEmail(string userId, string code)
        {
            
        }

        [TestMethod]
        public void ForgotPassword()
        {
            
        }

        [TestMethod]
        public void ForgotPassword(ForgotPasswordViewModel model)
        {
            
        }

        [TestMethod]
        public void ForgotPasswordConfirmation()
        {
            
        }

        [TestMethod]
        public void ResetPassword(string code)
        {
            
        }

        [TestMethod]
        public void ResetPassword(ResetPasswordViewModel model)
        {
            
        }

        [TestMethod]
        public void ResetPasswordConfirmation()
        {
            
        }

        [TestMethod]
        public void ExternalLogin(string provider, string returnUrl)
        {
            
        }

        [TestMethod]
        public void SendCode(SendCodeViewModel model)
        {
            
        }

        [TestMethod]
        public void SendCode(string returnUrl, bool rememberMe)
        {

        }

        [TestMethod]
        public void ExternalLoginCallback(string returnUrl)
        {
            
        }

        [TestMethod]
        public void ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            
        }

        [TestMethod]
        public void Logoff()
        {
            
        }

        [TestMethod]
        public void ExternalLoginFailure()
        {
            
        }

        [TestMethod]
        public void VerifyCode(string provider, string url, bool rememberMe)
        {
            
        }

        [TestMethod]
        public void VerifyCode(VerifyCodeViewModel model)
        {
            
        }
    }
}
