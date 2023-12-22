using NopCommerceBDD.Hooks;
using NopCommerceBDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace NopCommerceBDD.StepDefinitions
{
    [Binding]
    internal class UserRegisterationStep : CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;
        [When(@"User will click on the Register Button")]
        public void WhenUserWillClickOnTheRegisterButton()
        {
            var fluentwait = Waits(driver);
            AllHooks.test = AllHooks.extent.CreateTest(" Register test started");
            IWebElement? Regbutton = fluentwait.Until(d => driver?.FindElement(By.XPath("//a[text()='Register']")));
            Regbutton?.Click();
        }

        [Then(@"Registrtion Page is loaded in the same page")]
        public void ThenRegistrtionPageIsLoadedInTheSamePage()
        {
            string filepath = TakeScreenshot(driver);
            AllHooks.test.AddScreenCaptureFromPath(filepath);
            try
            {
                Assert.That(driver.Url, Does.Contain("register"));
                LogTestResult("User reg Test", "loaded in the same page");
            }
            catch (AssertionException ex)
            {
                LogTestResult("User register Page Test", " Test Failed", ex.Message);
            }

        }

        [When(@"Selecting gender option")]
        public void WhenSelectingGenderOption()
        {
            var fluentWait = Waits(driver);
            IWebElement? Gender = fluentWait.Until(d => driver.FindElement(By.XPath("//label[contains(text(),'Male')]")));
            Gender?.Click();
        }
        [When(@"Fills the User Details '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void WhenFillsTheUserDetails(string firstname, string lastname, string day, string month, string year, string email, string pwd, string cnfrmpwd)
        {
            var fluentWait = Waits(driver);

            IWebElement? FirstnameIn = fluentWait.Until(d => driver?.FindElement(By.XPath("//input[@id='FirstName']")));
            FirstnameIn?.Click();
            FirstnameIn?.SendKeys(firstname);
            IWebElement? LastnameInput = fluentWait.Until(d => driver?.FindElement(By.XPath("//input[@id='LastName']")));
            LastnameInput?.Click();
            LastnameInput?.SendKeys(lastname);
            IWebElement? Day = fluentWait.Until(d => driver?.FindElement(By.XPath("//select[@name='DateOfBirthDay']//child::option[@value=" + day + "]")));
            Day?.Click();
            IWebElement? Month = fluentWait.Until(d => driver?.FindElement(By.XPath("//select[@name='DateOfBirthMonth']//child::option[@value=" + month + "]")));
            Month?.Click();
            IWebElement? Year = fluentWait.Until(d => driver?.FindElement(By.XPath("//select[@name='DateOfBirthYear']//child::option[@value=" + year + "]")));
            Year?.Click();
            IWebElement? Email = fluentWait.Until(d => driver?.FindElement(By.XPath("//input[@type='email'][position()=1]")));
            Email?.Click();
            Email?.SendKeys(email);
            IWebElement? PWD = fluentWait.Until(d => driver?.FindElement(By.XPath("//input[@id='Password']")));
            PWD?.Click();
            PWD?.SendKeys(pwd);
            IWebElement? CfrmPwd = fluentWait.Until(d => driver?.FindElement(By.XPath("//input[@id='ConfirmPassword']")));
            CfrmPwd?.Click();
            CfrmPwd?.SendKeys(cnfrmpwd);



        }

        [When(@"Clicks the Register user")]
        public void WhenClicksTheRegisterUser()
        {
            var fluentWait = Waits(driver);
            IWebElement? Regfinl = fluentWait.Until(d => driver.FindElement(By.XPath("//button[@id='register-button']")));
            Regfinl?.Click();
        }

        [Then(@"Customer details added successfully")]
        public void ThenCustomerDetailsAddedSuccessfully()
        {
            string filepath = TakeScreenshot(driver);
            AllHooks.test.AddScreenCaptureFromPath(filepath);
            try
            {

                Assert.That(driver.Url, Does.Contain("registerresult"));
               
                LogTestResult("Register Test", "successful");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Register Test fail", "Register Test failed", ex.Message);
            }
        }
    }
}
