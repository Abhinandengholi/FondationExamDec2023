using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceNunit.PageObjects
{
    internal class Productpage
    {
        public IWebDriver driver;
        public Productpage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange

        [FindsBy(How = How.XPath, Using = "//button[@id='add-to-cart-button-5']")]
        private IWebElement? Addtocart { get; set; }


        public void Productselect()
        {

            Addtocart?.Click();
           
            
        }

    }
}