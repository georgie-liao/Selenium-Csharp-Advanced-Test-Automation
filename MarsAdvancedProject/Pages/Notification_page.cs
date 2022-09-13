using MarsAdvancedProject.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsAdvancedProject.Pages
{
    public class Notification_page
    {
        public Notification_page()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize web elements

        // Notification button
        [FindsBy(How = How.XPath, Using = "//div[@class='ui top left pointing dropdown item']")]
        private IWebElement NotificationBtn { get; set; }

        // Mark All As Read Button
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Mark all as read']")]
        private IWebElement MarkAllAsReadBtn { get; set; }

        // See All button                  
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='See All...']")]
        private IWebElement SeeAllBtn { get; set; }

        // Load More Button
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a")]
        private IWebElement LoadMoreBtn { get; set; }

        // Show Less Button                
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[11]/div[1]/center/a")]
        private IWebElement ShowLessBtn { get; set; }

        // List notification                
        [FindsBy(How = How.XPath, Using = "//div[@class='item link']")]
        private IList<IWebElement> NotificationList { get; set; }

        // Alert message              
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IList<IWebElement> AlertMessage { get; set; }

        // List checkbox                
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private IList<IWebElement> CheckBoxList { get; set; }

        // First checkbox                
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input")]
        private IWebElement FirstCheckBox { get; set; }

        // Seletct All Button                
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Select all']")]
        private IWebElement SelectAllBtn { get; set; }

        // Seletct All Button                
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Unselect all']")]
        private IWebElement UnSelectAllBtn { get; set; }

        // Delete Button                
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Delete selection']")]
        private IWebElement DeleteBtn { get; set; }

        // Delete Button                
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Mark selection as read']")]
        private IWebElement MarkAsReadBtn { get; set; }

        // ui Button                
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Load More...']")]
        private IList<IWebElement> uiBtn { get; set; }
        #endregion

        #region Show ALL Notification
        public void SeeAllNotification_steps()
        {

            //Wait until the Notification button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, NotificationBtn);
            NotificationBtn.Click();

            //Wait until until the SeeAll button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, SeeAllBtn);
            SeeAllBtn.Click();

            //Wait until the LoadMore button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, LoadMoreBtn);
            LoadMoreBtn.Click();

            Thread.Sleep(3000);

            int loadmoreBtn = uiBtn.Count();
            for (int i = 0; i < loadmoreBtn; i++)
            {
                if (uiBtn[i].Text.Contains("Load More..."))
                {
                    uiBtn[i].Click();
                   
                    GlobalDefinitions.ScrollToBottom();

                    Thread.Sleep(2000);
                }
            }

            Thread.Sleep(2000);
            
            int ntn = NotificationList.Count();

            Console.WriteLine("Total count is " + ntn);

            string notificationNo = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='floating ui blue label']")).Text;

            Assert.That(Convert.ToInt16(notificationNo) == ntn, "Total notification numbers are not the same. Test failed");
        }
        #endregion

        #region Show Less Notification
        public void ShowLessNotification_Steps()
        {

            //Wait until the Notification button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, NotificationBtn);
            NotificationBtn.Click();

            //Wait until until the SeeAll button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, SeeAllBtn);
            SeeAllBtn.Click();

            //Wait until the LoadMore button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, LoadMoreBtn);
            LoadMoreBtn.Click();

            //Wait until the ShowLess button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, ShowLessBtn);
            ShowLessBtn.Click();

            Thread.Sleep(3000);

            int notificationNo = NotificationList.Count();

            Console.WriteLine("Total matched result is " + notificationNo + "." + "Test passed.");
        }
        #endregion

        #region Delete one Notification
        public void DeleteOneNotification_Steps()
        {
            //Wait until the Notification button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, NotificationBtn);
            NotificationBtn.Click();

            //Wait until until the SeeAll button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, SeeAllBtn);
            SeeAllBtn.Click();

            //Wait until the LoadMore button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, LoadMoreBtn);
            LoadMoreBtn.Click();

            //Wait until the first checkbox is clickble then clickle
            WaitHelper.WaitClickble(GlobalDefinitions.driver, FirstCheckBox);
            FirstCheckBox.Click();

            //Wait until until the delete button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, DeleteBtn);
            DeleteBtn.Click();

            Thread.Sleep(2000);
        }
        #endregion

        public string GetDeletionAlertMessage(IWebDriver driver) // Get the pop-up alert message
        {
            string alertMessageXPath = "//div[@class='ns-box-inner']";
            IWebElement editedLanguageAlertmMessage = driver.FindElement(By.XPath(alertMessageXPath));
            return editedLanguageAlertmMessage.Text;
        }

        #region Mark as read 
        public void MarkAsRead_Steps()
        {

            //Wait until the Notification button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, NotificationBtn);
            NotificationBtn.Click();

            //Wait until until the SeeAll button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, SeeAllBtn);
            SeeAllBtn.Click();

            //Wait until the LoadMore button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, LoadMoreBtn);
            LoadMoreBtn.Click();

            //Wait until until the first checkbox is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, FirstCheckBox);
            FirstCheckBox.Click();

            //Wait until until the Mart as Read button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, MarkAsReadBtn);
            MarkAsReadBtn.Click();

            Thread.Sleep(2000); 
        }
        #endregion

        public string GetUpdateAlertMessage(IWebDriver driver) // Get the pop-up alert message
        {
            string alertMessageXPath = "//div[@class='ns-box-inner']";
            IWebElement editedLanguageAlertmMessage = driver.FindElement(By.XPath(alertMessageXPath));
            return editedLanguageAlertmMessage.Text;
        }

        #region Select All Notification
        public void SelectAllNotification_Steps()
        {

            //Wait until the Notification button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, NotificationBtn);
            NotificationBtn.Click();

            //Wait until until the SeeAll button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, SeeAllBtn);
            SeeAllBtn.Click();

            //Wait until the LoadMore button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, LoadMoreBtn);
            LoadMoreBtn.Click();

            //Wait until until the Select All button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, SelectAllBtn);
            SelectAllBtn.Click();

            Thread.Sleep(1000);
        }
        #endregion

        #region Unselect All Notification
        public void UnselectAllNotification_Steps()
        {

            //Wait until the Notification button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, NotificationBtn);
            NotificationBtn.Click();

            //Wait until until the SeeAll button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, SeeAllBtn);
            SeeAllBtn.Click();

            //Wait until the LoadMore button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, LoadMoreBtn);
            LoadMoreBtn.Click();

            //Wait until until the Select All button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, SelectAllBtn);
            SelectAllBtn.Click();


            //Wait until until the unselect All button is clickble then click
            WaitHelper.WaitClickble(GlobalDefinitions.driver, UnSelectAllBtn);
            UnSelectAllBtn.Click();

        }
        #endregion
    }

}
