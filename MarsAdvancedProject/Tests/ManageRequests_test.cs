using MarsAdvancedProject.Global;
using MarsAdvancedProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsAdvancedProject.Global.GlobalDefinitions;

namespace MarsAdvancedProject.Tests
{
    
    internal class ManageRequests_test
    {
        [TestFixture]
        
        class User : Global.Base
        {
            

            #region  Test 1 : Send a new request test
            [Test]
            public void SendNewRequest_test()
            {

                //Start the Reports
                test = extent.StartTest("Send new request");
                test.Log(LogStatus.Info, "Send new request");

                // Take Screenshots
                SaveScreenShotClass.SaveScreenshot(driver, "SendNewRequest");

                ManageReqests_page manageRequestsObj = new ManageReqests_page();

                // Sign in portal as user Jim
                manageRequestsObj.SignInAsKiwi_steps();

                // Send a new request     
                manageRequestsObj.SendNewRequest_steps();

                // Assert the confirmation text and the alert message: if the expected  text and alert message matches the actual ones, test passed; eles, failed.
                string newSentConfirmation = manageRequestsObj.GetSentConfirmation(driver);
                string newRequestAlertMssage = manageRequestsObj.GetAlertMessage(driver);
                if (newSentConfirmation.Contains("You have a pending trade request for this listing") && newRequestAlertMssage.Contains("Request sent"))
                {
                    Assert.Pass("Expected texts and actual  texts are matched. Test Passed.");
                }
                else Assert.Fail("Expected texts and actual texts are not matched. Test Failed.");
            }
            #endregion

            #region  Test 2 : Verify a sent request test
            [Test]
            public void VerifySentRequest_test()
            {

                //Start the Reports
                test = extent.StartTest("Verify sent request");
                test.Log(LogStatus.Info, "Verify sent request");

                // Take Screenshots
                SaveScreenShotClass.SaveScreenshot(driver, "VerifySentRequest");

                ManageReqests_page manageRequestsObj = new ManageReqests_page();

                // Sign in portal as user Jim
                manageRequestsObj.SignInAsKiwi_steps();

                // Verify sent request
                manageRequestsObj.VerifySentRequest_steps();

                // Get the request message from the test data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
                string testRequestMessage = GlobalDefinitions.ExcelLib.ReadData(2, "RequestMessage");

                // Get the recipient title from the test data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
                string testTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");

                // Get the recipient first name from the test data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
                string testRecipientName = GlobalDefinitions.ExcelLib.ReadData(2, "FirstName");
                // Get actual Title, Message and Recipient name from the first record 
                string ActualSentTitle = manageRequestsObj.GetSentTitle(driver);
                string ActualSentMessage = manageRequestsObj.GetSentMessage(driver);
                string ActualRecipientName = manageRequestsObj.GetRecipientName(driver);

                // Assertion: If the acctual Title, Message, and Recipient name are matched with the test data, test passed. Else, failed.
                if (testTitle == ActualSentTitle && testRequestMessage == ActualSentMessage && testRecipientName == ActualRecipientName)
                {
                    Assert.Pass("Expected sent request and actual request record are matched. Test Passed.");
                }
                else Assert.Fail("Expected sent request and actual request record are not matched. Test Failed.");

            }
            #endregion

            #region  Test 3 : Verify received request
            [Test]
            public void VerifyReceivedRequest_test()
            {

                //Start the Reports
                test = extent.StartTest("Verify received request");
                test.Log(LogStatus.Info, "Verify received request");

                // Take Screenshots
                SaveScreenShotClass.SaveScreenshot(driver, "VerifySentRequest");

                ManageReqests_page manageRequestsObj = new ManageReqests_page();

                // Verify sent request
                manageRequestsObj.VerifyReceivedRequest_steps();

                // Get the request message from the test data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
                string testRequestMessage = GlobalDefinitions.ExcelLib.ReadData(2, "RequestMessage");

                // Get the recipient title from the test data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
                string testTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");

                // Get the recipient first name from the test data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
                string testRecipientName = GlobalDefinitions.ExcelLib.ReadData(2, "Name");

                // Get actual Title, Message and Recipient name from the first record 
                string ActualReceivedTitle = manageRequestsObj.GetReceivedTitle(driver);
                string ActualReceivedMessage = manageRequestsObj.GetReceivedMessage(driver);
                string ActualSenderName = manageRequestsObj.GetSenderName(driver);

                // Assertion: If the acctual Title, Message, and Recipient name are matched with the test data, test passed. Else, failed.
                if (testTitle == ActualReceivedTitle && testRequestMessage == ActualReceivedMessage && testRecipientName == ActualSenderName)
                {
                    Assert.Pass("Expected received request and actual request record are matched. Test Passed.");
                }
                else Assert.Fail("Expected received request and actual request record are not matched. Test Failed.");

            }
            #endregion

            #region  Test 4 : Withdraw a sent request test
            [Test]
            public void WithdrawRequest_test()
            {

                //Start the Reports
                test = extent.StartTest("Withdraw request");
                test.Log(LogStatus.Info, "Withdrew request");

                // Take Screenshots
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                ManageReqests_page manageRequestsObj = new ManageReqests_page();

                // Sign in portal as user Jim
                manageRequestsObj.SignInAsKiwi_steps();

                // Enter Share Skill steps    
                manageRequestsObj.WithdrawRequest_steps();

                // Get the alert message
                string withdrawAlertmessage = manageRequestsObj.GetAlertMessage(driver);

                // Assertion: If the alert message is "Request has been withdrawn", test passed; else, test failed.
                if (withdrawAlertmessage == "Request has been withdrawn")
                {
                    Assert.Pass("Expected  messages and actual messages are matched. Test Passed.");
                }
                else Assert.Fail("Expected messages and actual messages are not matched.Test Failed.");

            }
            #endregion

            

            #region  Test 5 : Accept a recived request test
            [Test]
            public void AcceptRequest_test()
            {

                //Start the Reports
                test = extent.StartTest("Accept request");
                test.Log(LogStatus.Info, "Accept request");

                // Take Screenshots
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                ManageReqests_page manageRequestsObj = new ManageReqests_page();

                // Enter Share Skill steps    
                manageRequestsObj.AcceptRequest_steps();

                // Get the alert message
                string acceptAlertmessage = manageRequestsObj.GetAlertMessage(driver);

                // Assertion: If the alert message is "Request has been withdrawn", test passed; else, test failed.
                if (acceptAlertmessage == "Service has been updated")
                {
                    Assert.Pass("Expected  messages and actual messages are matched. Test Passed.");
                }
                else Assert.Fail("Expected messages and actual messages are not matched.Test Failed.");

            }
            #endregion


            #region  Test 6 : Complete  a sent request test
            [Test]
            public void CompleteSentRequest_test()
            {

                //Start the Reports
                test = extent.StartTest("Complete sent request");
                test.Log(LogStatus.Info, "Complete sent request");

                // Take Screenshots
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                ManageReqests_page manageRequestsObj = new ManageReqests_page();

                // Sign in portal as user Jim
                manageRequestsObj.SignInAsKiwi_steps();

                // Enter Share Skill steps    
                manageRequestsObj.CompleteSentRequest_steps();

                // Get the actual Status of the first record
                string AccutalStatus = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div[1]/table/tbody/tr[1]/td[5]")).Text;

                // Get the alert message
                string completeRequestAlertmessage = manageRequestsObj.GetAlertMessage(driver);

                // Assertion: If the alert message is "Request has been withdrawn", test passed; else, test failed.
                if (completeRequestAlertmessage == "Service has been updated" && AccutalStatus.Contains("Completed"))
                {
                    Assert.Pass("Expected  messages and  button are matched with actual ones. Test Passed.");
                }
                else Assert.Fail("Expected  messages and  button are not matched with actual ones. Test Failed.");

            }
            #endregion


            #region  Test 7 : Decline a received request test
            [Test]
            public void DeclineRequest_test()
            {

                //Start the Reports
                test = extent.StartTest("Decline request");
                test.Log(LogStatus.Info, "Decline request");

                // Take Screenshots
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                ManageReqests_page manageRequestsObj = new ManageReqests_page();

                // Enter Share Skill steps    
                manageRequestsObj.DeclineRequest_steps();
                // Get the actual Status of the first record
                string declineStatus = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div[1]/table/tbody/tr[1]/td[5]")).Text;

                // Get the alert message
                string declineAlertmessage = manageRequestsObj.GetAlertMessage(driver);

                // Assertion: If the alert message is "Request has been withdrawn", test passed; else, test failed.
                if (declineAlertmessage == "Service has been updated" && declineStatus.Contains("Declined"))
                {
                    Assert.Pass("Expected  messages and actual messages are matched. Test Passed.");
                }
                else Assert.Fail("Expected messages and actual messages are not matched.Test Failed.");

            }
            #endregion

            #region  Test 8 : Complete a received request test
            [Test]
            public void CompleteReceivedRequest_test()
            {

                //Start the Reports
                test = extent.StartTest("Complete received request");
                test.Log(LogStatus.Info, "Complete received request");

                // Take Screenshots
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                ManageReqests_page manageRequestsObj = new ManageReqests_page();

                // Enter Share Skill steps    
                manageRequestsObj.CompleteReceivedRequest_steps();

                // Get the actual Status of the first record
                string declineStatus = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div[1]/table/tbody/tr[1]/td[5]")).Text;

                // Get the alert message
                string completedReAlertmessage = manageRequestsObj.GetAlertMessage(driver);

                // Assertion: If the alert message is "Request has been withdrawn", test passed; else, test failed.
                if (completedReAlertmessage == "Service has been updated" && declineStatus.Contains("Completed"))
                {
                    Assert.Pass("Expected  messages and actual messages are matched. Test Passed.");
                }
                else Assert.Fail("Expected messages and actual messages are not matched.Test Failed.");

            }
            #endregion
        }

    }
}
