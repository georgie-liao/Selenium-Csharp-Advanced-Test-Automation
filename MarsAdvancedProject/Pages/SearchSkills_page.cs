using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System.Diagnostics;
using System.Threading;
using MarsAdvancedProject.Global;
using System.Collections;

namespace MarsAdvancedProject.Pages
{
    public class SearchSkills_page
    {
        public SearchSkills_page()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize web elements

        // Search skills textbox 
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search skills']")]
        private  IWebElement searchTextBox { get; set; }

        // Search skills icon 
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private  IWebElement searchIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div")]
        private  IList<IWebElement> getRecordCard { get; set; }

        // get record                        
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div")]
        private IList<IWebElement> getRecord { get; set; }

        // get Title                       
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div/a[2]/p")]
        private IList<IWebElement> getTitle { get; set; }

        // getUsername
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[1]")]
        private IList<IWebElement> getUsername { get; set; }
       
        
        // Get Pagination
        [FindsBy(How = How.XPath, Using = "//button[@class='ui button otherPage']")]
        private IList<IWebElement> Pagination { get; set; }

        // All Category  
        [FindsBy(How = How.XPath, Using = "//a[@class='item category']")]
        private IList<IWebElement> AllCategory { get; set; }

        // Sub Category
        [FindsBy(How = How.XPath, Using = "//a[@class='item subcategory']")]
        private IList<IWebElement> Sub_Category { get; set; }

        // User textBox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input")]
        private IWebElement userTextBox { get; set; }

        // User search icon
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/i")]
        private IWebElement userSearchIcon { get; set; }

        // OnlineB filter button 
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]")]
        private IWebElement onlineButton { get; set; }

        // Onsite filter button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]")]
        private IWebElement onsiteButton { get; set; }

        // Show All Button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]")]
        private IWebElement showAllButton { get; set; }

        // User name on the first record of search result
        [FindsBy(How = How.XPath, Using = "//div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[1]")]
        private IWebElement Username { get; set; }

        // Title on the first record of 
        [FindsBy(How = How.XPath, Using = "//div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p")]
        private IWebElement recordTitle { get; set; }

        // LocationType
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]")]
        private IWebElement LocationType { get; set; }

        // ActivePage
        [FindsBy(How = How.XPath, Using = "//button[@class='ui active button currentPage']")]
        private  IWebElement ActivePage { get; set; }

        // Total Search Result Number
        [FindsBy(How = How.XPath, Using = "//div[@class='ui card']")]
        private IList<IWebElement> TotalSearchResultNo { get; set; }

        // Next page button
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='>']")]
        private IWebElement NextPageBtn { get; set; }



        #endregion


        #region Search Skill steps
        public void SearchBySkill_steps()
        {
            //Prepares the Excel Test Data 
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Wait until the Search Textbox is available then enter data
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchTextBox);
            searchTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Wait until the Search Icon is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchIcon);
            searchIcon.Click();
        
        }
        #endregion

    


        # region Search by Category and sub-category
        public void ClickOnCategory()
        {
            //Wait until the Search Icon is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchIcon);
            searchIcon.Click();

            //Prepares the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            // Count all actegory
            WaitHelper.WaitClickble(GlobalDefinitions.driver, AllCategory[5]);
            var countCategory = AllCategory.Count();

            for (int i = 0; i < countCategory; i++)
            {
                string Category = AllCategory[i].Text;  //Get whole text from web page
                string[] trimmedText = Category.Split(new char[] { '\n' });  //Split by enter
                string CategoryName = trimmedText.First();  //Find first word

                //Check if web Element matches Category in a Excel file
                if (CategoryName == (GlobalDefinitions.ExcelLib.ReadData(2, "Category") + "\r"))
                {
                    //Click on Category
                    AllCategory[i].Click();

                    WaitHelper.WaitClickble(GlobalDefinitions.driver, Sub_Category[2]); 

                    //Count Subcategory
                    var countSubCat = Sub_Category.Count();

                    for (int j = 1; j < countSubCat; j++)
                    {
                        string subCategory = Sub_Category[j].Text;  //Get whole text from web page
                        string[] trimText = subCategory.Split(new char[] { '\n' });   //Split by enter
                        string subCategoryName = trimText.First();  //Find first word

                        //Check if web Element matches Sub-Category in a Excel file
                        if (subCategoryName == (GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory") + "\r"))
                        {
                            //Click on Sub-Category
                            Sub_Category[j].Click();
                            i--;
                            countCategory = AllCategory.Count();
                            break;
                        }
                    }
                }
            }

        }
        #endregion

        # region Validate Search User 
        public void SearchUser_steps()
        {
            //Wait until the Search Icon is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchIcon);
            searchIcon.Click();

            // Wait until the textbox is available
            WaitHelper.WaitClickble(GlobalDefinitions.driver, userTextBox);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");

            // Import user name from excel test data and enter it into search textbox
            userTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName") + " " + GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            Thread.Sleep(2000);
            // press enter key to start search user
            userTextBox.SendKeys(Keys.ArrowDown + Keys.Enter);

            Thread.Sleep(3000);
        }
        #endregion



        #region Function to count search by User Name and Skill
        public void CountSearchResult_steps()
        {

            //Wait until the Search Icon is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchIcon);
            searchIcon.Click();

            // Count search result
            int rowNo = getRecordCard.Count();
            int pageNo = Pagination.Count();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            string a = GlobalDefinitions.ExcelLib.ReadData(2, "Title");

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
            string b = GlobalDefinitions.ExcelLib.ReadData(2, "FirstName") + " " + GlobalDefinitions.ExcelLib.ReadData(2, "LastName");

            for (int j = 2; j <= pageNo; j++)
            {
                for (int i = 0; i < rowNo; i++)
                {
                    if (getTitle[i].Text == a && getUsername[i].Text == b)
                    {

                        Pagination[j].Click();

                    }
                    else break;
                }

            }
            Console.WriteLine("Total matched result is " + rowNo + "." + "Test passed.");
        }
        #endregion


        #region Validate online filter
        public void OnlineFilter_steps()
        {
            //Wait until the Search Icon is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchIcon);
            searchIcon.Click();

            //Wait until finds Online Button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, onlineButton);
            onlineButton.Click();

            //Wait until the title of the record is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, recordTitle);
            recordTitle.Click();

            Thread.Sleep(2000);
        }
        #endregion

   

        #region Validate Onsite filter
        public void OnSiteFilter_steps()
        {
            //Wait until the Search Icon is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchIcon);
            searchIcon.Click();

            //Wait until Online Button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, onsiteButton);
            onsiteButton.Click();

            //Wait until the title of the record is clickable then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, recordTitle);
            recordTitle.Click();

            Thread.Sleep(3000);
        }
        #endregion
 

        #region Validate ShowAll filter
        public void ShowAllFilter_steps()
        {
            //Wait until the Search Icon is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, searchIcon);
            searchIcon.Click();

            //Wait until ShowAll Button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, showAllButton);
            showAllButton.Click();

            // Count pages of search result
            WaitHelper.WaitClickble(GlobalDefinitions.driver, Pagination[3]);
            int pageNo = Pagination.Count();

            for (int i = 0; i < pageNo; i++)
            {
                if (Pagination[i].Text == "243")
                {
                    Pagination[i].Click();
                    break;
                }

            }

            if (ActivePage.Text == "243")
            {
                Assert.Pass("Aacctual page is " + ActivePage.Text);
            }

        }
        #endregion
    }
}
