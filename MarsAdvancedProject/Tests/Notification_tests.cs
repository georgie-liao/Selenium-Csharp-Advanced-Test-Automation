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
    internal class Notification_tests
    {
        [TestFixture]

        class User : Global.Base
        {

            #region  Test 1 : Show all notifition test
            [Test]
            public void SeeAllNotificaiton_test()
            {

                //Start the Reports
                test = extent.StartTest("See all notification");
                test.Log(LogStatus.Info, "See all notification");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps    
                Notification_page NotificationObj = new Notification_page();
                NotificationObj.SeeAllNotification_steps();
            }
            #endregion

            #region  Test 2 : Show less notifition test
            [Test]
            public void SeeLessNotificaiton_Test()
            {

                //Start the Reports
                test = extent.StartTest("See less notificationl");
                test.Log(LogStatus.Info, "See less notification");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps    
                Notification_page NotificationObj = new Notification_page();
                NotificationObj.ShowLessNotification_Steps();
            }
            #endregion

            #region  Test 3 : Delete Notification
            [Test]
            public void DeleteNotification_Test()
            {

                //Start the Reports
                test = extent.StartTest("Delete nofification");
                test.Log(LogStatus.Info, "Delete nofification");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps    
                Notification_page NotificationObj = new Notification_page();
                NotificationObj.DeleteOneNotification_Steps();

                // Assert the alart message to confirm the new education has been added
                string newAlertMssage = NotificationObj.GetDeletionAlertMessage(driver);
                Assert.That(newAlertMssage == "Notification updated", "Expected pop up message is not matched.");
            }
            #endregion

            #region  Test 4 : Mark Notification as read
            [Test]
            public void MarkAsRead_Test()
            {

                //Start the Reports
                test = extent.StartTest("Mark notification as read");
                test.Log(LogStatus.Info, "Mark notification as read");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps    
                Notification_page NotificationObj = new Notification_page();
                NotificationObj.MarkAsRead_Steps();

                // Assert the alart message to confirm the new education has been added
                string newAlertMssage = NotificationObj.GetUpdateAlertMessage(driver);
                Assert.That(newAlertMssage == "Notification updated", "Expected pop up message is not matched.");
            }
            #endregion

            #region  Test 5 : Select Notification
            [Test]
            public void SelectNotification_Test()
            {

                //Start the Reports
                test = extent.StartTest("Select notification");
                test.Log(LogStatus.Info, "Select notification");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps    
                Notification_page NotificationObj = new Notification_page();
                NotificationObj.SelectAllNotification_Steps();


                string unselectBtn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]")).GetAttribute("style");
                if (unselectBtn.Contains("inline"))
                {
                    Assert.Pass("Unselect button is activated. Test Passed.");
                }
                else Assert.Fail("Unselect button is not activated. Test Failed.");

            }
            #endregion

            #region  Test 6 : Unselect Notification
            [Test]
            public void UnselectNotification_Test()
            {

                //Start the Reports
                test = extent.StartTest("Unselect notification");
                test.Log(LogStatus.Info, "Unselect notification");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps    
                Notification_page NotificationObj = new Notification_page();
                NotificationObj.UnselectAllNotification_Steps();


                string unselectBtn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]")).GetAttribute("style");
                if (unselectBtn.Contains("none"))
                {
                    Assert.Pass("Unselect button is unactivated. Test Passed.");
                }
                else Assert.Fail("Unselect button is activated. Test Failed.");

            }
            #endregion


        }
    }
}
