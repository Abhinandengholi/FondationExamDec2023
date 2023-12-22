using NopCommerceNunit.Helper;
using NopCommerceNunit.PageObjects;
using NopCommerceNunit.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceNunit.TestScripts
{
    internal class SearchPageTest:CoreCodes
    { //Asserts
        [Test, Order(1), Category("end to end Test")]
        [TestCase("laptop")]
        public void UserRegister(string product)
        {
            var fluentWait = Waits(driver);

            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            test = extent.CreateTest("User search Report");

            NopcommerceHomePage nchp = new(driver);
            Log.Information("User search Test Started");

            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Searchdata";
            

                try
                {

                  
                    var search = fluentWait.Until(d => nchp.Search(product));
                    Log.Information("selected specific product");
                    test.Info("selected specific product");
                    var prodct= fluentWait.Until(d => search.SpecificProduct());

                    Log.Information("Add to cart product");
                    test.Info("Add to cart product");
                     
                    Assert.That(driver.Url, Does.Contain("asus"));

                    string filepath = TakeScreenshot();
                    test.AddScreenCaptureFromPath(filepath);
                    LogTestResult("Search Test", "Search test passed");
                    test.Pass("Search Test passed");


                }
                catch (AssertionException ex)
                {
                    string filepath = TakeScreenshot();
                    test.AddScreenCaptureFromPath(filepath);
                    LogTestResult("Register Test", "User reg Failed", ex.Message);
                    test.Fail("Registeration Testfailed");

                }

            
        }
    }
}
