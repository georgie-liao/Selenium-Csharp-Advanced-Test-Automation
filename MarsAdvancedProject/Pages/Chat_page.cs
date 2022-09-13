using MarsAdvancedProject.Global;
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
    public class Chat_page
    {
        public Chat_page()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize web elements

        // Chat button
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Chat']")]
        private IWebElement ChatBtn { get; set; }

        // Chat Search textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search']")]
        private IWebElement ChatSearchTextbox { get; set; }

        // Search Icon
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private IWebElement SearchIcon { get; set; }

        // Search Icon
        [FindsBy(How = How.XPath, Using = "//div[@class='item']")]
        private IList<IWebElement> ChatRoomList { get; set; }

        // Chat input textbox
        [FindsBy(How = How.XPath, Using = "//input[@id='chatTextBox']")]
        private IWebElement ChatInputTextBox { get; set; }

        // Send message button
        [FindsBy(How = How.XPath, Using = "//button[@id='btnSend']")]
        private IWebElement SendMessageBtn { get; set; }

        // Send message button
        [FindsBy(How = How.Id, Using = "//div[@class='message-container']")]
        private IWebElement MessageRecord { get; set; }

        // Search skills icon 
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private IWebElement searchIcon { get; set; }

        // Title on the first skill record
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p")]
        private IWebElement TitleOnSkillRecord { get; set; }

        // Start Chat button
        [FindsBy(How = How.XPath, Using = "//a[@class='ui teal button']")]
        private IWebElement StartChatBtn { get; set; }

        // Start Chat button
        [FindsBy(How = How.XPath, Using = "//*[@id='chatList']/div[1]/div[2]")]
        private IWebElement ChatList { get; set; }

        #endregion

        #region Start a chat with another user
        public void StartChat_Steps()
        {
            // Enter Share Skill steps  
            SearchSkills_page SearchSkillsObj = new SearchSkills_page();
            SearchSkillsObj.SearchUser_steps();

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Chat");

            //Wait until the title on the first skill record is available then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, TitleOnSkillRecord);
            TitleOnSkillRecord.Click();


            //Wait until the start chat button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, StartChatBtn);
            StartChatBtn.Click();

            //Wait until the chat input textbox is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, ChatInputTextBox);
            ChatInputTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Message"));

            WaitHelper.WaitClickble(GlobalDefinitions.driver, SendMessageBtn);
            SendMessageBtn.Click();

            Thread.Sleep(3000);

        }

        public string GetSentMessage(IWebDriver driver) // Get the pop-up alert message
        {
            string sentMessageXPath = "//div[@class='message-container']";
            IWebElement sentMessage = driver.FindElement(By.XPath(sentMessageXPath));
            return sentMessage.Text;
        }


        #endregion

        #region Find chat history
        public void ChatHistory_Steps()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Requests");

            //Wait until the Chat button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, ChatBtn);
            ChatBtn.Click();


            //Wait until the chat search textbox is available then enter data
            WaitHelper.WaitClickble(GlobalDefinitions.driver, ChatSearchTextbox);
            ChatSearchTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SellerName"));

            //Wait until the  Chat List is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, ChatList);
            ChatList.Click();

            Thread.Sleep(2000);
        }

        public string GetSellerName(IWebDriver driver) // Get the pop-up alert message
        {
            string SearchcChatXPath = "//*[@id='chatList']";
            IWebElement searchChatResult = driver.FindElement(By.XPath(SearchcChatXPath));
            return searchChatResult.Text;
        }

        public string GetChatHistoryMessage(IWebDriver driver) // Get the pop-up alert message
        {
            string sentMessageXPath = "//div[@class='message-container']";
            IWebElement sentMessage = driver.FindElement(By.XPath(sentMessageXPath));
            return sentMessage.Text;
        }

        #endregion
    }
}
