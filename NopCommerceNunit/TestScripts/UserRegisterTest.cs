using NopCommerceNunit.Helper;
using NopCommerceNunit.PageObjects;
using NopCommerceNunit.Utilities;
using NUnit.Framework;
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
    internal class UserRegisterTest:CoreCodes
    {
        //Asserts
        [Test, Order(1), Category("end to end Test")]
        [TestCase("asdf@123", "asdf@123")]
        public void UserRegister(string pwd,string cnfrmpwd)
        {
            var fluentWait = Waits(driver);

            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            test = extent.CreateTest("User Registeration Report");

           NopcommerceHomePage nchp= new(driver);
            Log.Information("User Register Test Started");
           
            IWebElement pageLoadedElement = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Register']")));
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Searchdata";
            List<SearchData> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            {

                try
                {

                    string? firstname = excelData?.FirstName;
                    string? lastname = excelData?.LastName;
                    string? day = excelData?.Day;
                    string? month = excelData?.Month;
                    string? year = excelData?.Year;
                    string? email = excelData?.Email;
                    string? gender = excelData?.Gender;
                    
                    Console.WriteLine($"FirstName: {firstname}, LastName: {lastname}, day: {day},month: {month}, Year: {year}, Email: {email}, Gender: {gender}");
                    var regstr=fluentWait.Until(d=>nchp.Register());
                    Assert.That(driver.Url, Does.Contain("register"));
                    Log.Information("Register button clicked");
                    test.Info("Register button clicked");
                    regstr.UserRegisteration(gender,firstname, lastname, day,month,year,email,pwd,cnfrmpwd);

                    //IWebElement txts = driver.FindElement(By.XPath("//div[@class='result'] "));
                    //string? text = txts.Text;
                    Log.Information("Register Details passed");
                    test.Info("Register Details passed");

                    Assert.That(driver.Url, Does.Contain("registerresult"));

                    string filepath = TakeScreenshot();
                    test.AddScreenCaptureFromPath(filepath);
                    LogTestResult("Register Test", "User added");

                    test.Pass("Registeration Test passed");


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
}