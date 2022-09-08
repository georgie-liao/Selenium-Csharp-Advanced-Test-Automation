using MarsAdvancedProject.Pages;
using System;
using MarsAdvancedProject.Global;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System.Threading;
using static MarsAdvancedProject.Global.GlobalDefinitions;
using OpenQA.Selenium;

namespace MarsAdvancedProject.Tests
{
   
    public class SearchSkills_Tests
    {

        [TestFixture]

        class User : Global.Base
        {

            #region  Test 1 : Search Skill test
            [Test]
            public void SearchSkills()
            {

                //Start the Reports
                test = extent.StartTest("Search skill");
                test.Log(LogStatus.Info, "Search skill created");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps    
                SearchSkills SearchSkillsObj = new SearchSkills();
                SearchSkillsObj.SearchBySkill_steps();

                
                // Asserttion 1: If search URL contains the test data "Title", test passed; Else, failed.
                string searchWord = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                string ExpectedURL = "http://localhost:5000/Home/Search?searchString=" + searchWord;
                string ActualURL = GlobalDefinitions.driver.Url;
                if (ExpectedURL == ActualURL)
                {
                    Assert.Pass("I am at " + searchWord + " Skills Page. Test passed!");
                }
                else
                {
                    Assert.Fail("No " + searchWord + " such skills found.");
                }

                // Assertion 2: Currently search test data "Title" has a result of 14 records.
                Thread.Sleep(2000);
                string SearchResultNumber = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div/section/div/div[1]/div[1]/div/a[1]/span")).Text;
                Assert.That(SearchResultNumber == "14", "Search result does not much.");
            }
            #endregion

            #region  Test 2 : Search by categary test
            [Test]
            public void SearchByCategary()
            {

                //Start the Reports
                test = extent.StartTest("Search skill");
                test.Log(LogStatus.Info, "Search skill created");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps    
                SearchSkills SearchSkillsObj = new SearchSkills();
                SearchSkillsObj.ClickOnCategory();

                //Assertion 1:  If search URL matches, test passed; else, failed.
                string ExpectedURL = "http://localhost:5000/Home/Search?cat=WritingTranslation&subcat=4";
                string ActualURL = GlobalDefinitions.driver.Url;

                if (ExpectedURL == ActualURL)
                {
                    Assert.Pass("URL matched. Test passed!");
                }
                else
                {
                    Assert.Fail("URL not matched. Test failed");
                }
                // Assertion 2: Currently search test data "Title" has a result of 157 records.
                string CategaryNumber = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div/section/div/div[1]/div[1]/div/a[4]/span")).Text;
                Assert.That(CategaryNumber == "157", "Search result does not much.");

                // Assertion 2: Currently search test data "Title" has a result of 59 records.
                string SubCategaryNumber = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div/section/div/div[1]/div[1]/div/a[8]/span")).Text;
                Assert.That(SubCategaryNumber == "59", "Search result does not much.");

            }
            #endregion

            [Test]
            #region  Test 3 : Search user test
            public void SearchByUser()
            {

                //Start the Reports
                test = extent.StartTest("Search skill");
                test.Log(LogStatus.Info, "Search skill created");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps  
                SearchSkills SearchSkillsObj = new SearchSkills();
                SearchSkillsObj.SearchUser_steps();

                Thread.Sleep(2000);



                // Assertion: compare first user name on the first search result with the excel test data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
                string Username = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[1]")).Text;
                if (Username == (GlobalDefinitions.ExcelLib.ReadData(2, "FirstName") + " " + GlobalDefinitions.ExcelLib.ReadData(2, "LastName")))
                {
                    Assert.Pass("Expected user name found. Test passed!");
                }
                else
                {
                    Assert.Fail("Expected user name not found. Test Failed!");
                }

            }
            #endregion

            [Test]
            #region  Test 4 : Online filter test
            public void OnlineFilter()
            {

                //Start the Reports
                test = extent.StartTest("Search skill");
                test.Log(LogStatus.Info, "Search skill created");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps  
                SearchSkills SearchSkillsObj = new SearchSkills();
                SearchSkillsObj.OnlineFilter_steps();

                // Assertion: compare the Location Type on the first search result with the excel test data
                string LocationType = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]")).Text;
                if (LocationType == "Online")
                {
                    Assert.Pass("Expected Location Type is 'Online'. Test passed!");
                }
                else
                {
                    Assert.Fail("Expected Location Type is not 'Online'. Test failed!");
                }
            }
            #endregion

            [Test]
            #region  Test 5 : OnSite filter test
            public void OnSiteFilter()
            {

                //Start the Reports
                test = extent.StartTest("Search skill");
                test.Log(LogStatus.Info, "Search skill created");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps  
                SearchSkills SearchSkillsObj = new SearchSkills();
                SearchSkillsObj.OnSiteFilter_steps();

                // Assertion: compare the Location Type on the first search result with the excel test data
                string LocationType = GlobalDefinitions.driver.FindElement(By.XPath("//div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]")).Text;
                if (LocationType == "On-Site")
                {
                    Assert.Pass("Expected Location Type is 'On-Site'. Test passed!");

                }
                else
                {
                    Assert.Fail("Expected Location Type is not 'On-Site'. Test failed!");
                }
            }
            #endregion

            [Test]
            #region  Test 6 : Show All filter test
            public void ShowAllFilter()
            {

                //Start the Reports
                test = extent.StartTest("Search skill");
                test.Log(LogStatus.Info, "Search skill created");

                // Take Screenshots of entering Share Skills
                SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");

                // Enter Share Skill steps  
                SearchSkills SearchSkillsObj = new SearchSkills();
                SearchSkillsObj.ShowAllFilter_steps();
            }
            #endregion
        }
    }
}
