using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceNunit.PageObjects
{
    internal class RegisterPage
    {
        public IWebDriver driver;
        public RegisterPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange

        [FindsBy(How = How.XPath, Using = "//input[@id='FirstName']")]
        private IWebElement? Firstname{ get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='LastName']")]
        private IWebElement? Lastname { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='email'][position()=1]")]
        private IWebElement? Email { get; set; }
   
        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        private IWebElement? Password { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='ConfirmPassword']")]
        private IWebElement? CnfrmPwd { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[@id='register-button']")]
        private IWebElement? Reg { get; set; }
        //Act
        public void UserRegisteration(string gender,string firstname,string lastname,string day,string month,string year,string email,string pwd,string cnfrmpwd)
        {
    
            driver.FindElement(By.XPath("//label[contains(text(),"+gender+")]")).Click();
            Firstname?.Click();
            Firstname?.SendKeys(firstname);
            Lastname?.Click();
            Lastname?.SendKeys(lastname);

            driver.FindElement(By.XPath("//select[@name='DateOfBirthDay']//child::option[@value=" + day + "]")).Click();
            driver.FindElement(By.XPath("//select[@name='DateOfBirthMonth']//child::option[@value="+month+"]")).Click();
            driver.FindElement(By.XPath("//select[@name='DateOfBirthYear']//child::option[@value="+year+"]")).Click();
            Email?.Click();
            Email?.SendKeys(email);
            Password?.Click();
            Password?.SendKeys(pwd);
            CnfrmPwd?.Click();
            CnfrmPwd?.SendKeys(cnfrmpwd);
            Reg?.Click();
            //driver.FindElement(By.XPath("//a[@class='button-1 register-continue-button']")).Click();
          

        }
    }
}

