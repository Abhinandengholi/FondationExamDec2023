using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceNunit.PageObjects
{
    internal class SearchPage
    {
        public IWebDriver driver;
        public SearchPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange

        [FindsBy(How = How.XPath, Using = "//div[@class='product-item'][position()=1]")]
        private IWebElement? Productselct { get; set; }
        public Productpage SpecificProduct()
        {

            Productselct?.Click();
            return new Productpage(driver);
        }

    }
}
