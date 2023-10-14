using LearningProject.Context;
using LearningProject.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LearningProject.Steps
{
    [Binding]
    public class StepDefenitions
    {
        private LoginPage _Loginpage { get; }

        private DataContext DataContext;
        public StepDefenitions(LoginPage loginPage, DataContext dataContext)
        {
            _Loginpage = loginPage;
            DataContext = dataContext;
        }


        [Then(@"I close the application")]
        public void ThenICloseTheApplication()
        {
            _Loginpage.CloseApplication();
        }

        [When(@"I open the buggy application home page")]
        [Then(@"I open the buggy application home page")]
        [Given(@"I open the buggy application home page")]
        public void GivenIOpenTheBuggyApplication()
        {
            _Loginpage.NavigatetoBuggyHome();
            _Loginpage.Waitfor5seconds();
        }


        [Then(@"I click login button")]
        public void ThenIClickLoginButton()
        {
            _Loginpage.clickLoginButton();
        }

        [Then(@"I Validate error message for invalid login")]
        public void ThenIValidateErrorMessageForInvalidLogin()
        {
            string expectedvalidationmessage = "Invalid username/password";
            string actualvalidationmessage = _Loginpage.ValidationMessageforLogin();
            Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "validation message not found or doesnt match");
        }



        [When(@"I fill in login Information")]
        public void WhenIFillInLoginInformation(Table table)
        {
            foreach (var item in table.Rows)

            {
                string login = item.GetString("login");
                string password = item.GetString("password");
                if (login != null && login != string.Empty)
                {
                    _Loginpage.SetUsername(login);
                    _Loginpage.Waitfor2seconds();
                }
                if (password != null && password != string.Empty)
                {
                    _Loginpage.SetPassword(password);
                    _Loginpage.Waitfor2seconds();
                }
            }
        }

    }
}
