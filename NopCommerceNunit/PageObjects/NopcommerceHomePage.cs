using NopCommerceNunit.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceNunit.PageObjects
{
    internal class NopcommerceHomePage
    {
        public IWebDriver driver;
        public NopcommerceHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver)); //if the driver is null exception thrown
            PageFactory.InitElements(driver, this);//for optimizing 
        }

        //Arrange

        [FindsBy(How = How.XPath, Using = "//a[text()='Register']")]
        private IWebElement? Registerbutton { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@class='search-box-text ui-autocomplete-input']")]
        private IWebElement? Searchfld{ get; set; }
       
        [FindsBy(How = How.XPath, Using = " //button[@class='button-1 search-box-button']")]
        private IWebElement? Searchbutton { get; set; }




        //Act
        public RegisterPage Register()
        {
           Registerbutton?.Click();
            return new RegisterPage(driver);

        }
        public SearchPage Search(string laptop)
        {
            Searchfld?.Click();
            Searchfld?.SendKeys(laptop);
            Searchbutton?.Click();
            return new SearchPage(driver);

        }


    }
}

