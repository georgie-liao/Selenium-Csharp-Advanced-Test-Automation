using MarsAdvancedProject.Global;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.PageObjects;

namespace MarsAdvancedProject.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign In tab
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Sign In email textbox
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement EmailTextbox { get; set; }

        //Finding the Sign In password textbox
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement PasswordTextBox { get; set; }

        //Finding the Login button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void SignInSteps()
        {
            // Import value from the excel data file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            // Import broswer ulr from section on the excel file
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            GlobalDefinitions.wait(5);

            // Click on the Sign In button
            SignIntab.Click();

            // Enter user login email
            EmailTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            // Enter user login password
            PasswordTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            // Click on Login button
            LoginBtn.Click();
        }
    }
}