
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumSpecFlow.Utilities;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;


namespace SeleniumSpecFlow.Pages
{
    public class Chat_page
    {
        #region Web elements 
        //Sear User textbox
        private IWebElement searchUserTextBox => driver.FindElement(By.XPath("//input[@placeholder='Search user']"));

        //Search icon
        private IWebElement searchIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/i"));

        // Chat button
        private IWebElement ChatBtn => driver.FindElement(By.XPath("//a[normalize-space()='Chat']"));

        // Chat Search textbox
        private IWebElement ChatSearchTextbox => driver.FindElement(By.XPath("//input[@placeholder='Search']"));

        // Search Icon
        private IWebElement ChatRoomList => driver.FindElement(By.XPath("//div[@class='item']"));

        // Chat input textbox
        private IWebElement ChatInputTextBox => driver.FindElement(By.XPath("//input[@id='chatTextBox']"));

        // Send message button
        private IWebElement SendMessageBtn => driver.FindElement(By.XPath("//button[@id='btnSend']"));

        // Send message button 
        private IWebElement lastSentMessage => driver.FindElement(By.XPath("//*[@id='chatBox']/div[last()]"));

        // Title on the first skill record
        private IWebElement TitleOfListing => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p"));

        // Start Chat button
        private IWebElement StartChatBtn => driver.FindElement(By.XPath("//a[@class='ui teal button']"));

        // Start Chat button
        private IWebElement ChatList => driver.FindElement(By.XPath("//*[@id='chatList']/div[1]/div[2]"));
        #endregion

        #region Wait elements
        private string e_searchIcon = "//*[@id='account-profile-section']/div/div[1]/div[1]/i";
        private string e_searchUserTextBox = "//input[@placeholder='Search user']";
        private string e_titleOfListing = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p";
        private string e_startChatBtn = "//a[normalize-space()='Chat']";
        private string e_chatSearchTextbox = "//input[@placeholder='Search']";
        #endregion


        #region Start a chat with another user
        public void GoToSearchPage()
        {
            //Click search icon to go to the search page
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_searchIcon, 5);
            searchIcon.Click();
        }

        public void SearchForSeller()
        {
            //Get seller name from the test data 
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");

            //Wait until the search user textbox is available then enter user name in the search user textbox
            WaitHelpers.WaiToBeExistent(driver, "XPath", e_searchUserTextBox, 5);
            searchUserTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName") + " " + GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            Thread.Sleep(1000);

            // press enter key to open search result
            searchUserTextBox.SendKeys(Keys.ArrowDown + Keys.Enter);
            Thread.Sleep(1000);
        }

        public void SendChatMessage()
        {
            //Wait until the titile of search result is available then click 
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_titleOfListing, 5);
            TitleOfListing.Click();

            //Wait until the chat button is available then click 
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_startChatBtn, 5);
            StartChatBtn.Click();

            //Get test data from the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "Chat");

            //Enter chat message into textbox 
            ChatInputTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Message"));

            SendMessageBtn.Click();

            Thread.Sleep(1000);
        }
        #endregion

        #region Find chat history
        public void GoToChatRoom()
        {
            //Thread.Sleep(3000); 
            //Wait until the Chat button is available then click
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_startChatBtn, 5);
            ChatBtn.Click();
        }
        public void SearchChatHistory()
        {
            //Get test data from the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");

            //Wait until the searchbox is available then enter seller name
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_chatSearchTextbox, 5);
            ChatSearchTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            Thread.Sleep(2000);

            //Get the user name from search result in the chat
            string chatNames = driver.FindElement(By.XPath("//div[@id='chatList']//div[@class='content']")).Text;

            //Get user name from the test data
            string testName = GlobalDefinitions.ExcelLib.ReadData(2, "FirstName");

            //Assertion:
            if (chatNames.Contains(testName)) //if the user name in the search result matches the test data
            {
                ChatList.Click(); //click on the search result to see chat history
            }
            else
            {
                Assert.Fail("User not found in the chat history"); //If not, display this message
            }

            Thread.Sleep(1000);
        }
        #endregion
    }
}
