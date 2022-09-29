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
    public class ShareSkill_StepDefinitions
    {
        ShareSkill_page shareSkillObj = new ShareSkill_page();

        ManageListings_Page manageListingObj = new ManageListings_Page();

        [Given(@"I go to Share Skill page")]
        public void GivenIGoToShareSkillPage()
        {
            shareSkillObj.GoToShareSkill();
        }

        [When(@"Add a new Share Skill")]
        public void WhenAddANewShareSkill()
        {
            shareSkillObj.EnterShareSkill_Steps();
        }

        [Then(@"The new Share Skill should be added succssfully")]
        public void ThenTheNewShareSkillShouldBeAddedSuccssfully()
        {
           // string alertmessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
            //string newSkillAlertMessage = shareSkillObj.GetAddNewSkillMessage(driver);
           // Assert.That(alertmessage == "Service Listing Added successfully", "Actual alert message doesn't match expected message.");

            manageListingObj.GoToManageListing();
            Thread.Sleep(2000);

            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "ShareSkill");
            // Assertion 1: Get the new Category and compare it with the test data. If both value are matched, test passed; else, failed.
            string NewCategory = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]")).Text;
            Assert.AreEqual(NewCategory, ExcelLib.ReadData(2, "Category"));

            // Assertion 2: Get the new Title and compare it with the test data. If both value are matched, test passed; else, failed.
            string NewTitle = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")).Text;
            Assert.AreEqual(NewTitle, ExcelLib.ReadData(2, "Title"));

            // Assertion 3: Get the new Description and compare it with the test data. If both value are matched, test passed; else, failed.
            string NewDescription = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")).Text;
            Assert.AreEqual(NewDescription, ExcelLib.ReadData(2, "Description"));
        }
    }
}
