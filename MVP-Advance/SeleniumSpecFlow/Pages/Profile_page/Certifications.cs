using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using static SeleniumSpecFlow.Utilities.WaitHelpers;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;

namespace SeleniumSpecFlow.Pages.ProfilePages
{
    public class Certifications
    {
        #region Web elements
        private IWebElement buttonAddNew => driver.FindElement(By.XPath(e_buttonAddNew));
        private IWebElement addedCertificate => driver.FindElement(By.Name("certificationName"));
        private IWebElement addedCertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        private IWebElement dropdownYear => driver.FindElement(By.Name("certificationYear"));
        private IWebElement buttonCompleteAdd => driver.FindElement(By.XPath(e_CompleteAdd));
        private IWebElement certifcate => driver.FindElement(By.XPath(e_certificate));
        private IWebElement certificationFrom => driver.FindElement(By.XPath(e_certificateFrom));
        private IWebElement certificationYear => driver.FindElement(By.XPath(e_certificationYear));
        private IWebElement buttonStartUpdate => driver.FindElement(By.XPath(e_buttonStartUpdate));
        private IWebElement editedCertificate => driver.FindElement(By.Name("certificationName"));
        private IWebElement editedCertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        private IWebElement buttonCompleteUpdate => driver.FindElement(By.XPath(e_buttonCompleteUpdate));
        private IWebElement buttonDelete => driver.FindElement(By.XPath(e_buttonDelete));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[4]"));
        private IList<IWebElement> certificates => driver.FindElements(By.XPath("//div[@data-tab='fourth']//tbody/tr/td[1]"));
        #endregion

        #region Wait elements
        private string e_buttonAddNew = "//div[@data-tab='fourth']//div[@class ='ui teal button ']";
        private string e_certificate = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]";
        private string e_certificateFrom = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[2]";
        private string e_certificationYear = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[3]";
        private string e_tab = "//div[@class='ui top attached tabular menu']";
        private string e_CompleteAdd = "//div[@class='five wide field']/input[1]";
        private string e_buttonStartUpdate = "//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]";
        private string e_buttonCompleteUpdate = "//input[@value='Update']";
        private string e_buttonDelete = "//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]";
        private string e_message = "//div[@class='ns-box-inner']";
        #endregion

        #region Go to Certifications
        public void GoToCertifications()
        {
            //Wait for Centifications tabs to be visible then click
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_tab, 3);
            tabOption.Click();
        }
        #endregion

        #region Add new certification
        public void ClickButtonAddNew()
        {
            //Wait for Add New button to be clickble then click
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonAddNew, 5);
            buttonAddNew.Click();
        }

        public void EnterCertificate()
        {
            //Get the test data from the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "Profile");

            //Enter Certificate/Award
            addedCertificate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

            //Enter Certifier
            addedCertificationFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom"));

            //Select year
            var addedYear = new SelectElement(dropdownYear);
            addedYear.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(2, "Year"));

            //Click on Add
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_CompleteAdd, 5);
            buttonCompleteAdd.Click();
        }
        #endregion

        #region Get actual data 
        public string GetMessage()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 10);
            return message.Text;
        }

        public string GetCertificate()
        {
            try
            {
                //Check on last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_certificate, 5);
                return certifcate.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public string GetCertificationFrom()
        {
            try
            {
                //Check on last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_certificateFrom, 5);
                return certificationFrom.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public string GetCertificationYear()
        {
            try
            {
                //Check on last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_certificationYear, 5);
                return certificationYear.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }
        #endregion

        #region Delete certificate
        public void DeleteCertificate()
        {
            try
            {
                //wait for button delete
                WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonDelete, 3);

                //Get the test data from the excel file
                GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "Profile");
                string testCertificate = GlobalDefinitions.ExcelLib.ReadData(3, "Certificate");

                //Get the actual certificate 
                string actualCertificate = GetCertificate();

                //Check if university is matching the university to be deleted
                if (actualCertificate == testCertificate)
                {
                    //click on delete button
                    buttonDelete.Click();
                }
                else
                {
                    Assert.Fail("No matching certificate found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No certificate is found.", ex.Message);
            }
        }
        #endregion

        #region Edit certificate
        public void ClickEdit(string certifcate1)
        {

            string e_Edit = "//div[@data-tab='fourth']//tbody[" + GetCertificateIndex(certifcate1) + "]/tr/td[4]/span[1]";
            IWebElement btnEdit = driver.FindElement(By.XPath(e_Edit));
            btnEdit.Click();

        }
        public string GetCertificate(string certificate)
        {
            string findCertificate = "null";
            int titleCount = certificates.Count();
            if (titleCount.Equals(0))
                return "No certificate is found";
            else
            {
                for (int i = 0; i < titleCount; i++)
                {
                    if (certificates[i].Text.Equals(certificate))
                    {
                        findCertificate = certificates[i].Text;
                        break;
                    }
                }
                if (findCertificate.Equals("null"))
                {
                    return "Certificate not found";
                }
            }
            return findCertificate;
        }

        public int GetCertificateIndex(string certificate)
        {
            int index = 0;
            int titleCount = certificates.Count();
            if (titleCount.Equals(0))
                Assert.Ignore("There is no certificate record.");
            else
            {
                for (int i = 0; i < titleCount; i++)
                {
                    if (certificates[i].Text.Equals(certificate))
                    {
                        index = i + 1;
                        break;
                    }
                }
                if (index.Equals(0))
                {
                    Assert.Ignore("Certificate " + certificate + "is not found.");
                }
            }
            return index;
        }

        public void EditCertificate(string certificate2, string from, string year)
        {
            //Edit Certificate/Award
            editedCertificate.Clear();
            editedCertificate.SendKeys(certificate2);

            //Edit Certifier
            editedCertificationFrom.Clear();
            editedCertificationFrom.SendKeys(from);

            //Edit year
            var editedYear = new SelectElement(dropdownYear);
            editedYear.SelectByValue(year);

            //Click on Update
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonCompleteUpdate, 5);
            buttonCompleteUpdate.Click();

        }
        #endregion
    }
}