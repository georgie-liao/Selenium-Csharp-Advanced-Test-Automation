using MarsAdvancedProject.Global;
using MarsAdvancedProject.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsAdvancedProject.Global.GlobalDefinitions;

namespace MarsAdvancedProject.Tests
{
    internal class Chat_Tests
    {
        [TestFixture]

        class User : Global.Base
        {

            #region  Test 1 : Show all notifition test
            [Test]
            public void StartChat_Test()
            {
                //Start the Reports
                test = extent.StartTest("Chat");
                test.Log(LogStatus.Info, "Chat created");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "Chat");

                // Enter Share Skill steps    
                Chat_page chatObj = new Chat_page();
                chatObj.StartChat_Steps();

                // Assert the sent message 
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Chat");
                string testMessage = (GlobalDefinitions.ExcelLib.ReadData(2, "Message"));
                string newSentMssage = chatObj.GetSentMessage(driver);
                if (newSentMssage.Contains(testMessage))
                {
                    Assert.Pass("Expected sent message and test message are matched. Test Passed.");
                }
                else Assert.Fail("Expected sent message and test message are not matched. Test Failed.");
            }
            #endregion

            #region  Test 2 : Find Chat history
            [Test]
            public void ChatHistory_Test()
            {
                //Start the Reports
                test = extent.StartTest("Chat History");
                test.Log(LogStatus.Info, "Find chat history");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "Chat");

                // Enter Share Skill steps    
                Chat_page chatObj = new Chat_page();
                chatObj.ChatHistory_Steps();

                // Assertion
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Chat");
                string testMessage = (GlobalDefinitions.ExcelLib.ReadData(2, "Message"));
                string testSellerName = (GlobalDefinitions.ExcelLib.ReadData(2, "SellerName"));
                string newSentMssage = chatObj.GetSentMessage(driver);
                string newSellerName = chatObj.GetSellerName(driver);
                
                if (newSentMssage.Contains(testMessage) && newSellerName.Contains(testSellerName))
                {
                    Assert.Pass("Expected chat history is matched. Test Passed.");
                }
                else Assert.Fail("Expected chat history is matched. Test Failed.");
            }
            #endregion
        }
    }
}
