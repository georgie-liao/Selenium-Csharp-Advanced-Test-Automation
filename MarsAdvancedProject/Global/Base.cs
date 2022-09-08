using MarsAdvancedProject.Config;
using MarsAdvancedProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsAdvancedProject.Global.GlobalDefinitions;

namespace MarsAdvancedProject.Global
{
    class Base
    {
        #region Resource access paths

        public static int Browser = Int32.Parse(MarsResources.Browser);
        public static String ExcelPath = MarsResources.ExcelPath;
        public static string ScreenshotPath = MarsResources.ScreenShotPath;
        public static string ReportPath = MarsResources.ReportPath;
        public static string XMLFilePath = MarsResources.XMLFilePath;

        #endregion

        #region Test and report
        public static ExtentTest test;
        public static ExtentReports extent;

        #endregion

        #region Setup and Tear down
        [SetUp]
        public void Inititalize()
        {

            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    break;

            }

            #region Initialise test reports

            extent = new ExtentReports(ReportPath + ".html", false, DisplayOrder.NewestFirst);
            extent.LoadConfig(XMLFilePath);

            #endregion


            if (MarsResources.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.SignInSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.SignUpSteps();
            }

        }


        [TearDown]
        public void TearDown()
        {
            // Save screenshots
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
            test.Log(LogStatus.Info, "Image example: " + img);

            // End the test. (Reports)
            extent.EndTest(test);

            // Calling Flush to writes test results into reports 
            extent.Flush();

            // Close the driver            
            GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }
        #endregion

    }
}
