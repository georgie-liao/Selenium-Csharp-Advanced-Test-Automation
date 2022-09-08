using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedProject.Global
{
   
        class GlobalDefinitions
        {
            //Initialise the browser
            public static IWebDriver driver { get; set; }

            #region WaitforElement 
            public static void wait(int time)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

            }
            public static IWebElement WaitVisible(IWebDriver driver, By by, int timeOutinSeconds)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
            }
            #endregion


            #region Excel TestData 

            // Read data from TestData excel
            public class ExcelLib
            {
                static List<Datacollection> dataCol = new List<Datacollection>();

                public class Datacollection
                {
                    public int rowNumber { get; set; }
                    public string colName { get; set; }
                    public string colValue { get; set; }
                }

                // Read data
                public static string ReadData(int rowNumber, string columnName)
                {
                    try
                    {
                        //Retriving Data using LINQ to reduce much of iterations
                        rowNumber = rowNumber - 1;
                        string data = (from colData in dataCol
                                       where colData.colName == columnName && colData.rowNumber == rowNumber
                                       select colData.colValue).SingleOrDefault();

                        return data.ToString();
                    }

                    catch (Exception e)
                    {
                        // Exception message
                        Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                        return null;
                    }
                }

                // Clear the data
                public static void ClearData()
                {
                    dataCol.Clear();
                }

                // Import data from excel to table
                private static DataTable ExcelToDataTable(string fileName, string SheetName)
                {
                    // Open file and return as Stream
                    using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                    {

                        using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                        {

                            var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });


                            // Get the table
                            DataTableCollection table = result.Tables;

                            // Store data into the table
                            DataTable resultTable = table[SheetName];

                            //excelReader.Dispose();
                            //excelReader.Close();
                            // return
                            return resultTable;
                        }
                    }
                }



                public static void PopulateInCollection(string fileName, string SheetName)
                {
                    ExcelLib.ClearData();
                    DataTable table = ExcelToDataTable(fileName, SheetName);

                    //Iterate through the rows and columns of the Table
                    for (int row = 1; row <= table.Rows.Count; row++)
                    {
                        for (int col = 0; col < table.Columns.Count; col++)
                        {
                            Datacollection dtTable = new Datacollection()
                            {
                                rowNumber = row,
                                colName = table.Columns[col].ColumnName,
                                colValue = table.Rows[row - 1][col].ToString()
                            };

                            //Add all the details for each row
                            dataCol.Add(dtTable);

                        }
                    }

                }
            }
            #endregion

            #region Screenshots
            public class SaveScreenShotClass
            {
                public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName)
                {
                    var folderLocation = (Base.ScreenshotPath);

                    if (!System.IO.Directory.Exists(folderLocation))
                    {
                        System.IO.Directory.CreateDirectory(folderLocation);
                    }

                    var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                    var fileName = new StringBuilder(folderLocation);

                    fileName.Append(ScreenShotFileName);
                    fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                    fileName.Append(".jpeg");
                    screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                    return fileName.ToString();
                }
            }
        #endregion

            public static void ScrollToBottom()
            {
            Actions a = new Actions(driver);
            a.SendKeys(Keys.End).Perform();
            }

        }
    
}
