using SeleniumSpecFlow.Pages;
using SeleniumSpecFlow.Utilities;
using System;
using TechTalk.SpecFlow;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumSpecFlow
{
    [Binding]
    public class Chat_StepDefinitions
    {
        Chat_page chatObj = new Chat_page();

        [Given(@"I navigate to Search Skill page")]
        public void GivenINavigateToSearchSkillPage()
        {
            chatObj.GoToSearchPage();
        }

        [Then(@"I find a seller")]
        public void ThenIFindASeller()
        {
            chatObj.SearchForSeller();
        }

        [When(@"I send a chat message to the seller")]
        public void WhenISendAChatMessageToTheSeller()
        {
            chatObj.SendChatMessage();
        }

        [Then(@"The chat message should be sent to the user successfully")]
        public void ThenTheChatMessageShouldBeSentToTheUserSuccessfully()
        {
            // Get the test message from test data
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "Chat");
            string testMessage = (GlobalDefinitions.ExcelLib.ReadData(2, "Message"));

            // Get the last sent message in the chatbox
            string lastSentMessage = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/span[1]/div[last()]/div[1]/div[1]")).Text;

            //Assertion: If test message and actual last sent message are matched, test passed; eles, failed
            Assert.That(lastSentMessage == testMessage, "Actual last message and test message are not matched");
        }

        [Given(@"I go to Chat Room")]
        public void GivenIGoToChatRoom()
        {
            chatObj.GoToChatRoom();
        }

        [When(@"I search for a chat history under a user name")]
        public void WhenISearchForAChatHistoryUnderAUserName()
        {
            chatObj.SearchChatHistory();
        }

        [Then(@"I should be able to find chat history successfully")]
        public void ThenIShouldBeAbleToFindChatHistorySuccessfully()
        {
            // Get test message and seller name from test data
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "Chat");
            string testMessage = (GlobalDefinitions.ExcelLib.ReadData(2, "Message"));

            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string testSellerName = (GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            // Get the actual seller name and last sent message in the search result
            string messageRecord = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/span[1]/div[last()]/div[1]/div[1]")).Text;
            string sellerName = driver.FindElement(By.XPath("//*[@id='chatList']")).Text;

            Assert.That(messageRecord.Contains(testMessage) && sellerName.Contains(testSellerName), "Actual chat history and search result are not matched");
        }
    }
}
