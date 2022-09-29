using OpenQA.Selenium;
using SeleniumSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;


namespace SeleniumSpecFlow.Pages
{
    public class ManageListings_Page
    {
        #region  Web element

        // Virify Manage Listing tab
        private IWebElement manageListingsTab => driver.FindElement(By.LinkText("Manage Listings"));

        // View record icon
        private IWebElement viewIcon => driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]"));

        // Delete recrod icon 
        private IWebElement deleteIcon => driver.FindElement(By.XPath("//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]"));

        // Edit reco
        private IWebElement editIcon => driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));

        // Yes button on the pop up alert window
        private IWebElement yesBtn => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        #endregion

        #region Wait elements
        private string e_manageListingsTab = "//a[normalize-space()='Manage Listings']";
        private string e_viewIcon = "//i[@class='eye icon'])[1]";
        private string e_editIcon = "(//i[@class='outline write icon'])[1]";
        private string e_deleteIcon = "//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]";
        private string e_yesBtn = "/html/body/div[2]/div/div[3]/button[2]";
        #endregion

        #region Go to Manage Listing page
        public void GoToManageListing()
        {

            //Wait until Manage List tab is availale then click
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_manageListingsTab, 10);
            manageListingsTab.Click();
        }
        #endregion

        #region View listing
        public void ViewListing()
        {
            // Import value from excel data file
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "ShareSkill");

            //Wait until view icon is availale then click
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_viewIcon, 5);
            viewIcon.Click();
        }
        #endregion


        #region Edit listing
        public void ClickEditIcon()
        {
            //Wait until edit icon is availale then click
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_editIcon, 5);
            editIcon.Click();
        }
        #endregion


        #region Delete listing
        public void DeleteListing()
        {
            //Wait until delete icon is availale then click
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_deleteIcon, 5);
            deleteIcon.Click();

            //Wait until the pop-up window is availale then click Yes button
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_yesBtn, 5);
            yesBtn.Click();
        }
        #endregion
    }
}
