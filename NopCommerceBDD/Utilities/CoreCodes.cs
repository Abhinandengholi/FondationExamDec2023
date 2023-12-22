using NopCommerceBDD.Hooks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace NopCommerceBDD.Utilities
{

        internal class CoreCodes
        {

            protected string TakeScreenshot(IWebDriver driver)
            {
                ITakesScreenshot its = (ITakesScreenshot)driver;
                Screenshot screenshot = its.GetScreenshot();
                string currDir = Directory.GetParent(@"../../../").FullName;
                string filepath = currDir + "/Screenshot/ss_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                screenshot.SaveAsFile(filepath);
                Console.WriteLine("Taken ss");
                return filepath;
            }
            protected void LogTestResult(string testName, string result, string errorMessage = null)
            {
                Log.Information(result);
                if (errorMessage == null)
                {
                    Log.Information(testName + "passed");
                    AllHooks.test.Pass(result);
                }

                else
                {
                    Log.Error($"Test failed for{testName}.\n Exception: \n{errorMessage}");
                    AllHooks.test.Fail(result);
                }
            }
            public static DefaultWait<IWebDriver> Waits(IWebDriver driver)
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(30);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(150);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Message = "element not found";
                return fluentWait;
            }


        }
    }
