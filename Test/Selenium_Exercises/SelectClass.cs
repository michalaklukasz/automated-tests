using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Selenium_Automation.Test.Selenium_Exercises
{
    /// <summary>
    /// Defines the <see cref="SelectClass" />
    /// </summary>
    internal class SelectClass
    {
        /// <summary>
        /// The SelectStatements
        /// </summary>
        [Test]
        public void SelectStatements()
        {
            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            // Navigate to the specified URL
            driver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/select-dropdown-menu/");

            // Find the dropdown element
            IWebElement dropdown = driver.FindElement(By.XPath("//select"));

            // Initialize the Select class with the dropdown element
            SelectElement select = new SelectElement(dropdown);

            // Select an option by text
            select.SelectByText("Australia");

            //Wait for 3second
            Thread.Sleep(3000);

            // Select an option by value
            select.SelectByValue("ASM");

            //Wait for 3second
            Thread.Sleep(3000);

            // Select an option by index
            select.SelectByIndex(10);

            //Wait for 3second
            Thread.Sleep(3000);

            // Close the browser
            driver.Quit();
        }
    }
}
