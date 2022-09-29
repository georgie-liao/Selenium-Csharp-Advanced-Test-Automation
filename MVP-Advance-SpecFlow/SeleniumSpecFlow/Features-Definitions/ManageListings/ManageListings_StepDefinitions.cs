using SeleniumSpecFlow.Pages;
using System;
using TechTalk.SpecFlow;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumSpecFlow.Utilities;

namespace SeleniumSpecFlow
{
    [Binding]
    public class ManageListings_StepDefinitions
    {
        // Initialise the Manage Listing page object
        ManageListings_Page managelistingObj = new ManageListings_Page();

        // Initialise the Share Skill page object
        ShareSkill_page shareSkillObj = new ShareSkill_page();

        [Given(@"I go to Manage Listings page")]
        public void GivenIGoToManageListingsPage()
        {
            managelistingObj.GoToManageListing();
        }

        [Given(@"I click the edit icon")]
        public void GivenIClickTheEditIcon()
        {
            managelistingObj.ClickEditIcon();
        }

        [When(@"I edit the skill listing")]
        public void WhenIEditTheSkillListing()
        {
            shareSkillObj.EditShareSkill_Steps();
        }

        [Then(@"The skill listing should be edited successfully")]
        public void ThenTheSkillListingShouldBeEditedSuccessfully()
        {
            // Assertion 1: Get the alert message. If it contains "has been updated", test passed; else, failed.
            //string editedskillMessage = shareSkillObj.GetEditedSkillMessage(driver);
            //Assert.That(editedskillMessage.Contains("updated successfully"), "Expected message and actual message are not matched");
            
            // Get the test message from test data
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "EditShareSkill");

           
            managelistingObj.GoToManageListing();
            Thread.Sleep(2000);

            // Assertion 2: Get the edited Category and compare it with the test data. If both value are matched, test passed; else, failed.
            string EditedCategory = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]")).Text;
            Assert.AreEqual(EditedCategory, ExcelLib.ReadData(2, "Category"));

            // Assertion 3: Get the edited Title and compare it with the test data. If both value are matched, test passed; else, failed.
            string EditedTitle = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")).Text;
            Assert.AreEqual(EditedTitle, ExcelLib.ReadData(2, "Title"));

            // Assertion 4: Get the edited Description and compare it with the test data. If both value are matched, test passed; else, failed.
            string EditedDescription = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")).Text;
            Assert.AreEqual(EditedDescription, ExcelLib.ReadData(2, "Description"));
        }

        [When(@"I delete a skill listing")]
        public void WhenIDeleteASkillListing()
        {
            managelistingObj.DeleteListing();
        }

        [Then(@"The skill listing should be deleted successfully")]
        public void ThenTheSkillListingShouldBeDeletedSuccessfully()
        {
            // Assertion: Get the Alert message. If it contains "has been deleted", test passed; else, failed.
            string message = (driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"))).Text;
            Assert.That(message.Contains("has been deleted"), "Actual message and expected message are not matched.");
        }
    }
}
