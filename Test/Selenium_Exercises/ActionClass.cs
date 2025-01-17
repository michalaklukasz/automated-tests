using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Automation.Test.Selenium_Exercises
{
    internal class ActionClass
    {
        [Test]
        public void ActionStatements()
        {
            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            // Navigate to the specified URL
            driver.Navigate().GoToUrl("https://formy-project.herokuapp.com/dropdown");

            // Initialize the Actions class
            Actions actions = new Actions(driver);

            // Find the dropdown button
            IWebElement dropdownButton = driver.FindElement(By.Id("dropdownMenuButton"));

            // Click on the dropdown button to open it
            //actions.Click(dropdownButton).Perform();
            dropdownButton.Click();

            // Find an option within the dropdown
            IWebElement option = driver.FindElement(By.XPath("(//a[@href='/buttons'])[2]"));

            // Click on the option to select it
            actions.Click(option).Perform();

            //Wait for 3second
            Thread.Sleep(3000);

            // Close the browser
            driver.Quit();
        }
    }
}
