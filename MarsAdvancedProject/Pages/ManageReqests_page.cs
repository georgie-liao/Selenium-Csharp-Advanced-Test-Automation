using MarsAdvancedProject.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsAdvancedProject.Pages
{
    public class ManageReqests_page
    {
        public ManageReqests_page()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize web elements

        // SearchIcon
        [FindsBy(How = How.XPath, Using = "//div[@class='ui secondary menu']//i[@class='search link icon']")]
        private IWebElement searchIcon { get; set; }

        // SearchIcon
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search user']")]
        private IWebElement searchUserTextBox { get; set; }

        // Manage Request button
        [FindsBy(How = How.XPath, Using = "//div[@class='ui dropdown link item']")]
        private IWebElement manageRequestsBtn { get; set; }

        // Received requests button
        [FindsBy(How = How.XPath, Using = "//section[1]/div/div[1]/div/a[1]")]
        private IWebElement receivedRequestsBtn { get; set; }

        // Manage Request button
        [FindsBy(How = How.XPath, Using = "//section[1]/div/div[1]/div/a[2]")]
        private IWebElement sentRequestsBtn { get; set; }

        // Received request button
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Received Requests']")]
        private IWebElement receivedRequestBtn { get; set; }

        // Search User textBox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input")]
        private IWebElement userTextBox { get; set; }

        // Request message textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea")]
        private IWebElement RequestTextbox { get; set; }

        // Request message send button
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'button')]")]
        private IWebElement requestBtn { get; set; }

        // Confirm request Yes button
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Yes']")]
        private IWebElement YesBtn { get; set; }

        // Withdraw button
        [FindsBy(How = How.XPath, Using = "//div[2]/div[1]/table/tbody/tr[1]/td[8]/button")]
        private IWebElement withdrawBtn { get; set; }


        // Withdraw button
        [FindsBy(How = How.XPath, Using = "//button[@class='ui green basic button']")]
        private IWebElement signOutBtn { get; set; }

        // Withdraw button
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement signInBtn { get; set; }

        // Withdraw button
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        private IWebElement emailTextbox { get; set; }

        // Withdraw button
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        private IWebElement passwordTextbox { get; set; }

        // Welcome message
        [FindsBy(How = How.XPath, Using = "//button[@class='fluid ui teal button']")]
        private IWebElement loginBtn { get; set; }

        // Record titles
        [FindsBy(How = How.XPath, Using = "//div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div/a[1]")]
        private IList<IWebElement> recordNames { get; set; }

        // Record titles
        [FindsBy(How = How.XPath, Using = "//div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div/a[2]/p")]
        private IList<IWebElement> recordTitles { get; set; }

        // Accept button
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Accept']")]
        private IWebElement acceptBtn { get; set; }

        // Complete button
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Decline']")]
        private IWebElement declineBtn { get; set; }

        // Complete request button
        [FindsBy(How = How.XPath, Using = "//div[2]/div[1]/table/tbody/tr[1]/td[8]/button")]
        private IWebElement completeSentRequestBtn { get; set; }

        // Complete request button
        [FindsBy(How = How.XPath, Using = "//div[2]/div[1]/table/tbody/tr[1]/td[8]/button")]
        private IWebElement completeReceivedRequestBtn { get; set; }
        #endregion


        #region Sign In as user Kiwi
        public void SignInAsKiwi_steps() // Sign in as user Jim
        {
            Thread.Sleep(1000);

            // Get the greeting message on home page
            string greetingMessage = GlobalDefinitions.driver.FindElement(By.XPath("//div/div[1]/div[2]/div/span")).Text;

            // If the greeting message doesn't contain "Hi Kiwi", sign out then sign in as Kiwi
            if (!greetingMessage.Contains("Hi Kiwi"))
            {
                signOutBtn.Click();
            }
            else

            //Wait until the SignIn button is available then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, signInBtn);
            signInBtn.Click();

            // Get user Kiwi's login credential from the test data then enter to textboxes
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
            emailTextbox.Clear();
            emailTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            passwordTextbox.Clear();
            passwordTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            // Click on LogIn button
            loginBtn.Click();
        }
        #endregion

        #region Sign In as user Kiwi
        public string GetAlertMessage(IWebDriver driver)
        {
            IWebElement alertMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            return alertMessage.Text;
        }
        #endregion

        #region Find user and send a new request
        public void SendNewRequest_steps() // Search for a user then send a new request
        {
            // Click on the search icon to navigate to search page 
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchIcon);
            searchIcon.Click();

            // Get user name from the test data then enter it to the "Search user" textbox 
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchUserTextBox);
            searchUserTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName") + " " + GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            Thread.Sleep(1000);

            // Click on the first user name on the search result
            userTextBox.SendKeys(Keys.ArrowDown + Keys.Enter);


            // Get title name from the test data 
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            string a = GlobalDefinitions.ExcelLib.ReadData(2, "Title");

            // Get user name from the test data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchUserTextBox);
            string b = GlobalDefinitions.ExcelLib.ReadData(2, "FirstName") + " " + GlobalDefinitions.ExcelLib.ReadData(2, "LastName");

            // Check search result for user name and title, if both the user name and title match test data, then click on user title to open the skill record
            var countRecordName = recordNames.Count();
            for (int i = 0; i < countRecordName; i++)
            {
                string name = recordNames[i].Text;  //Get whole text from web page
                string[] trimmedText = name.Split(new char[] { '\n' });  //Split by enter
                string theRecordName = trimmedText.First();  //Find first word

                //Check If the record name in search result contains user title from the test data
                if (theRecordName.Contains(b))
                {
                    var countRecordTitle = recordTitles.Count();
                    for (int j = 0; j < countRecordTitle; j++)
                    {
                        string title = recordTitles[j].Text;  //Get whole text from web page
                        string[] trimText = title.Split(new char[] { '\n' });   //Split by enter
                        string theTitle = trimText.First();  //Find first word

                        //If the record title in search result contains user title from the test data
                        if (theTitle.Contains(a))
                        {
                            //Click on Sub-Category
                            recordTitles[j].Click();
                            i--;

                        }
                        break;
                    }
                }
                break;
            }

            // Get request message from the test data and enter into the textbox
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
            WaitHelper.WaitClickble(GlobalDefinitions.driver, RequestTextbox);
            RequestTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "RequestMessage"));

            // Click on "Request" button to sent request message
            WaitHelper.WaitClickble(GlobalDefinitions.driver, requestBtn);
            requestBtn.Click();

            // Click Yes button on the pop-up warning window to confirm
            WaitHelper.WaitClickble(GlobalDefinitions.driver, YesBtn);
            YesBtn.Click();

            Thread.Sleep(1000);
        }

        public string GetSentConfirmation(IWebDriver driver) // Get the pop-up alert message
        {
            IWebElement SentConfirmation = driver.FindElement(By.XPath("//label[@class='center aligned']"));
            return SentConfirmation.Text;
        }
        #endregion


        #region Verify sent requests
        public void VerifySentRequest_steps()
        {

            //Wait until Manage Request button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, manageRequestsBtn);
            manageRequestsBtn.Click();

            //Wait until Sent Request button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, sentRequestsBtn);
            sentRequestsBtn.Click();

            Thread.Sleep(1000);
        }
        public string GetSentTitle(IWebDriver driver) // Get the newly added skill level
        {
            IWebElement newTitle = driver.FindElement(By.XPath("//tbody[1]/tr[1]/td[2]"));
            return newTitle.Text;
        }

        public string GetSentMessage(IWebDriver driver) // Get the newly added skill level
        {
            IWebElement newMessage = driver.FindElement(By.XPath("//tbody[1]/tr[1]/td[3]"));
            return newMessage.Text;
        }

        public string GetRecipientName(IWebDriver driver) // Get the newly added skill level
        {
            IWebElement newRecipient = driver.FindElement(By.XPath("//tbody[1]/tr[1]/td[4]"));
            return newRecipient.Text;
        }
        #endregion


        #region Withdraw a request
        public void WithdrawRequest_steps()
        {

            //Wait until Manage Request button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, manageRequestsBtn);
            manageRequestsBtn.Click();

            //Wait until Sent Request button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, sentRequestsBtn);
            sentRequestsBtn.Click();

            // Get the actual Status of the first record
            string AccutalStatus = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div[1]/table/tbody/tr[1]/td[5]")).Text;

            // If the actual status is not "Pending", un
            if (AccutalStatus != "Pending")
            {
                Console.WriteLine("The acutal Status is " + AccutalStatus + ".");

                Assert.Fail("Expected status is not Pending. Unable to withdraw.");
            }
            else

            // Wait until the Withdraw button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, withdrawBtn);
            withdrawBtn.Click();

            Thread.Sleep(1000);
        }
        #endregion

        #region Complete a sent request
        public void CompleteSentRequest_steps()
        {

            //Wait until Manage Request button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, manageRequestsBtn);
            manageRequestsBtn.Click();

            //Wait until Sent Request button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, sentRequestsBtn);
            sentRequestsBtn.Click();

            // Get the actual Status of the first record                           
            string AccutalStatus = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div[1]/table/tbody/tr[1]/td[8]/button")).Text;

            // If the actual status is not "Pending", un
            if (!AccutalStatus.Contains("Complete"))
            {

                Assert.Fail("Expected Complete button is not existed. Unable to click.");
            }
            else

            // Click on complete button
            completeSentRequestBtn.Click();

            Thread.Sleep(1000);
        }
        #endregion

        #region Accept a request
        public void VerifyReceivedRequest_steps()
        {

            //Wait until Mange Request button is available then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, manageRequestsBtn);
            manageRequestsBtn.Click();

            //Wait until Received Request button is available then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, receivedRequestsBtn);
            receivedRequestsBtn.Click();

            Thread.Sleep(1000);

        }
        public string GetReceivedTitle(IWebDriver driver) // Get the newly added skill level
        {
            IWebElement newTitle = driver.FindElement(By.XPath("//tbody[1]/tr[1]/td[2]"));
            return newTitle.Text;
        }

        public string GetReceivedMessage(IWebDriver driver) // Get the newly added skill level
        {
            IWebElement newMessage = driver.FindElement(By.XPath("//tbody[1]/tr[1]/td[3]"));
            return newMessage.Text;
        }

        public string GetSenderName(IWebDriver driver) // Get the newly added skill level
        {
            IWebElement newSender = driver.FindElement(By.XPath("//tbody[1]/tr[1]/td[4]"));
            return newSender.Text;
        }
        #endregion

        #region Accept a request
        public void AcceptRequest_steps()
        {
            //Wait until Manage Request button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, manageRequestsBtn);
            manageRequestsBtn.Click();

            //Wait until Sent Request button is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, sentRequestsBtn);
            sentRequestsBtn.Click();

            // Get the actual Status of the first record
            string AccutalStatus = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div[1]/table/tbody/tr[1]/td[5]")).Text;

            // If the actual status is not "Pending", un
            if (AccutalStatus != "Pending")
            {
                Console.WriteLine("The acutal Status is " + AccutalStatus + ".");

                Assert.Fail("Expected status is not Pending. Unable to Accept the request.");
            }
            else

                // Wait until the button is clickble then click
                WaitHelper.WaitClickble(GlobalDefinitions.driver, acceptBtn);
            acceptBtn.Click();

            Thread.Sleep(1000);
        }
        #endregion


        #region Decline a request
        public void DeclineRequest_steps()
        {


            //Wait until Mange Request button is available then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, manageRequestsBtn);
            manageRequestsBtn.Click();

            //Wait until Received Request button is available then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, receivedRequestsBtn);
            receivedRequestsBtn.Click();

            // Get the actual Status of the first record
            string AccutalStatus = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div[1]/table/tbody/tr[1]/td[5]")).Text;

            // If the actual status is not "Pending", un
            if (AccutalStatus != "Pending")
            {
                Console.WriteLine("The acutal Status is " + AccutalStatus + ".");

                Assert.Fail("Expected status is not Pending. Unable to Accept the request.");
            }
            else

                // Wait until the button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, declineBtn);
            declineBtn.Click();

            Thread.Sleep(1000);
        }
        #endregion

        #region Complte a received request
        public void CompleteReceivedRequest_steps()
        {


            //Wait until Mange Request button is available then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, manageRequestsBtn);
            manageRequestsBtn.Click();

            //Wait until Received Request button is available then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, receivedRequestsBtn);
            receivedRequestsBtn.Click();

            // Get the actual Status of the first record
            string AccutalStatus = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div[1]/table/tbody/tr[1]/td[5]")).Text;

            // If the actual status is not "Pending", un
            if (AccutalStatus != "Accepted")
            {
                Console.WriteLine("The acutal Status is " + AccutalStatus + ".");

                Assert.Fail("Expected status is not Accepted. Unable to Complete the request.");
            }
            else

            // Wait until the button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, completeReceivedRequestBtn);
            completeReceivedRequestBtn.Click();

            Thread.Sleep(1000);
        }
        #endregion


    }
}
