using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;

namespace SeleniumSpecFlow.Pages
{
    public class ShareSkill_page
    {
        #region  Share Skill web elements
        //ShareSkill Button
        private IWebElement shareSkillBtn => driver.FindElement(By.LinkText("Share Skill"));

        //Title textbox
        private IWebElement titleTextbox => driver.FindElement(By.Name("title"));

        //Description textbox
        private IWebElement descriptionTextbox => driver.FindElement(By.Name("description"));

        //Category Dropdown
        private IWebElement categoryDropDown => driver.FindElement(By.Name("categoryId"));

        //SubCategory Dropdown
        private IWebElement subCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));

        //Tag textbox
        private IWebElement tagsTextbox => driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));

        //Tag Removal button
        private IWebElement tagsRemovalBtn => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div/div/div/span/a"));

        //Service type options
        private IWebElement serviceTypeOptions => driver.FindElement(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));

        //Hourly Service Type
        private IWebElement hourlyServiceType => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));

        //On-Off Service Type
        private IWebElement oneOffServiceType => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));

        //Location Type
        private IWebElement locationTypeOption => driver.FindElement(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //On-Site Location Type
        private IWebElement onSiteLocationType => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));

        //Online Location Type
        private IWebElement onlineLocationType => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        //Start Date dropdown
        private IWebElement startDateDropDown => driver.FindElement(By.Name("startDate"));

        //End Date dropdown
        private IWebElement endDateDropDown => driver.FindElement(By.Name("endDate"));

        //Available days
        private IWebElement days => driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]"));

        //Starttime
        private IWebElement startTime => driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //StartTime dropdown
        private IWebElement startTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //EndTime dropdown
        private IWebElement endTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));

        //Skill Trade option
        private IWebElement credit => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

        //Skill Exchange
        private IWebElement skillExchange => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));

        //Exchange tag
        private IWebElement skillExchangeTag => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));

        //Amount for Credit
        private IWebElement creditAmount => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //Active/Hidden option
        private IWebElement activeOption => driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Find Active Button
        private IWebElement activeButton => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        //Find Hidden Button
        private IWebElement hiddenButton => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));

        //Click on Work Sample button
        private IWebElement WorkSampleBtn => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));

        //Click on Save button
        private IWebElement saveBtn => driver.FindElement(By.XPath("//input[@value='Save']"));
        #endregion

        #region Wait elements
        private string e_shareSkillBtn = "//a[normalize-space()='Share Skill']";
        private string e_titleTextbox = "//div[2]/div/form/div[1]/div/div[2]/div/div[1]/input";
        private string e_alertMessage = "//div[@class='ns-box-inner']";
        #endregion

        #region Go to Share Skill page
        public void GoToShareSkill()
        {
            //Wait until the Share Kill button is clickble then click
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_shareSkillBtn, 5);
            shareSkillBtn.Click();
        }
        #endregion

        #region  Service type 
        public void ServiveType() // Select service type
        {
            // Import data from the excel file
            String ServiceType = ((GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")));

            // Select service type
            if (ServiceType.Equals("Hourly basis service"))
            {
                hourlyServiceType.Click();
            }
            else if (ServiceType.Equals("One-off service"))
            {
                oneOffServiceType.Click();
            }
        }
        #endregion

        #region  Location type 
        public void LocationType() // Set location typle
        {
            // Import data from the excel file
            String LocationType = ((GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")));

            // Select location type
            if (LocationType.Equals("On-site"))
            {
                onSiteLocationType.Click();
            }
            else if (LocationType.Equals("Online"))
            {
                onlineLocationType.Click();
            }
        }
        #endregion

        #region Clear tags
        public void ClearTages()
        {
            IList<IWebElement> tags = days.FindElements(By.XPath("//form[@class='ui form']/div[4]/div[2]/div/div/div/span/a"));
            int countTags = tags.Count();
            for (int i = 0; i < countTags; i++)
            {
                if (countTags > 0)
                    tags[i].Click();
            }
        }
        #endregion

        #region Clear Skill-Exchange
        public void ClearSkillExchange()
        {
            IList<IWebElement> exchangeTags = days.FindElements(By.XPath("//div[2]/div/form/div[8]/div[4]/div/div/div/div/span/a"));
            int countTags = exchangeTags.Count();
            for (int i = 0; i < countTags; i++)
            {
                if (countTags > 0)
                    exchangeTags[i].Click();
            }
        }
        #endregion


        #region Clear checkbox of Available days
        public void ClearSelectedDays()
        {
            IList<IWebElement> AvailableCheckboxes = days.FindElements(By.Name("Available"));
            for (int i = 0; i < AvailableCheckboxes.Count(); i++)
            {
                bool dayState = AvailableCheckboxes[i].Selected;
                if (dayState.Equals(true))
                {
                    
                    AvailableCheckboxes[i].Click();
                }
            }
        }
        #endregion

        #region  Available days, start and end date, start and end time
        public void AvailableDays() // Set Available days
        {
            // Set available days
            startDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            endDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));
            String[] WeekDays = new String[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            IList<IWebElement> AvailableCheckboxes = days.FindElements(By.Name("Available"));
            String AvailableDaysValue = GlobalDefinitions.ExcelLib.ReadData(2, "SelectDay");
            IList<String> AvailableDays = AvailableDaysValue.Split(',');
            for (int i = 0; i < WeekDays.Count(); i++)
            {
                if (AvailableDays.Contains(WeekDays[i]))
                {
                   
                    AvailableCheckboxes[i].Click();
                }
            }

            // Set Start times
            IList<IWebElement> AvailableStartTimeInputs = days.FindElements(By.Name("StartTime"));
            String AvailableStartTimesValue = GlobalDefinitions.ExcelLib.ReadData(2, "StartingTime");
            IList<String> AvailableStartTimes = AvailableStartTimesValue.Split(',');
            for (int i = 0; i < AvailableStartTimes.Count(); i++)
            {
                IList<String> startTimeInfo = AvailableStartTimes[i].Split(':');
                String startTimeDay = startTimeInfo[0];
                String startTimeValue = startTimeInfo[1];
                int indexOfDay = Array.IndexOf(WeekDays, startTimeDay);
                AvailableStartTimeInputs[indexOfDay].SendKeys(startTimeValue);
            }

            // Set End time
            IList<IWebElement> AvailableEndTimeInputs = days.FindElements(By.Name("EndTime"));
            String AvailableEndTimesValue = GlobalDefinitions.ExcelLib.ReadData(2, "EndingTime");
            IList<String> AvailableEndTimes = AvailableEndTimesValue.Split(',');
            for (int i = 0; i < AvailableEndTimes.Count(); i++)
            {
                IList<String> endTimeInfo = AvailableEndTimes[i].Split(':');
                String endTimeDay = endTimeInfo[0];
                String endTimeValue = endTimeInfo[1];
                int indexOfDay = Array.IndexOf(WeekDays, endTimeDay);
                AvailableEndTimeInputs[indexOfDay].SendKeys(endTimeValue);
            }
        }
        #endregion

        #region  Skill trade type
        public void SkillTrade() // Set Skill Trade type
        {
            // Import data from excel file
            String SkillTradeType = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTradeType");

            // Select skill trade type 
            if (SkillTradeType.Equals("Skill-exchange"))
            {
                skillExchange.Click();
                skillExchangeTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchangeTag"));
                skillExchangeTag.SendKeys(Keys.Enter);
            }
            else if (SkillTradeType.Equals("Credit"))
            {
                credit.Click();
                creditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditAmount"));
            }
        }
        #endregion

        #region Active type
        public void ActiveType() // Set Active tuype
        {
            // Import Status data from excel file
            String ActiveType = GlobalDefinitions.ExcelLib.ReadData(2, "Status");

            // Select active type
            if (ActiveType.Equals("Active"))
            {
                activeButton.Click();
            }
            else if (ActiveType.Equals("Hidden"))
            {
                hiddenButton.Click();
            }
        }
        #endregion

        #region Work Sample upload
        public void WorkSampleUpload() // Upload Work Sample 
        {
            // Click on worksample button and upload sample file
            WorkSampleBtn.Click();

            Thread.Sleep(2000);

            // AutoIt file upload
            using (Process exeProcess = Process.Start(@"E:\MVP Studio\PROJECTS\MarsQA_CompetitionProject\FileUpload\AutoItFileUpload.exe"))
            {
                exeProcess.WaitForExit();
            }

            Thread.Sleep(1000);
        }
        #endregion

        #region Enter new Share Skill steps
        public void EnterShareSkill_Steps() // Enter new Share Skill steps
        {
            //Get the test data from the excel 
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "ShareSkill");

            //Wait until the Title textbox is available then enter data
            WaitHelpers.WaiToBeExistent(driver, "XPath", e_titleTextbox, 5);
            titleTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            // Enter description
            descriptionTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            // Click on category dropdown and Select category
            categoryDropDown.Click();
            SelectElement selectCategory = new SelectElement(categoryDropDown);
            selectCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            // Click on subcategory dropdown and select subcategory
            subCategoryDropDown.Click();
            SelectElement selectSubCategory = new SelectElement(subCategoryDropDown);
            selectSubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            // Enter tags
            tagsTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            tagsTextbox.SendKeys(Keys.Enter);

            // Select Service Type
            ServiveType();

            // Select Location Type
            LocationType();

            // Select Available days
            AvailableDays();

            // Select Skill Trade type
            SkillTrade();

            // Upload Work Sample
            WorkSampleUpload();

            // Select Active type
            ActiveType();

            // Click Save button to save the newly entered Share Skill 
            saveBtn.Click();
        }

        public string GetAddNewSkillMessage(IWebDriver driver)
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_alertMessage, 5);
            IWebElement alertMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            return alertMessage.Text;
        }
        #endregion

        #region Edit Share Skill steps
        public void EditShareSkill_Steps()
        {
            // Import value from excel data file
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "EditShareSkill");

            //Wait until the Title textbox is available, clear existing data, then enter new data
            WaitHelpers.WaiToBeExistent(driver, "XPath", e_titleTextbox, 5);
            titleTextbox.Clear();
            titleTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            // Clear description textbox then enter new value
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            // Click on category dropdown then select new calue
            categoryDropDown.Click();
            SelectElement selectCategory = new SelectElement(categoryDropDown);
            selectCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            // Click on subcategory dropdown then select new calue
            subCategoryDropDown.Click();
            SelectElement selectSubCategory = new SelectElement(subCategoryDropDown);
            selectSubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            // Clear existing tags then enter new ones
            ClearTages();
            tagsTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            tagsTextbox.SendKeys(Keys.Enter);

            // Select new Service Type
            ServiveType();

            // Select new Location Type
            LocationType();

            // Clear the checkbox of Available days then select the new ones
            ClearSelectedDays();
            AvailableDays();

            // Select new Skill Trade type
            SkillTrade();

            ClearSkillExchange();
            skillExchangeTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchangeTag"));
            skillExchangeTag.SendKeys(Keys.Enter);

            // Upload Work Sample
            //WorkSampleUpload();

            // Select new Active type
            ActiveType();

            // Click Save button to save the newly entered Share Skill 
            saveBtn.Click();

            Thread.Sleep(1000);
        }

        public string GetEditedSkillMessage(IWebDriver driver)
        {
            IWebElement alertMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            return alertMessage.Text;
        }
        #endregion
    }
}
