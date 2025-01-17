namespace Selenium_Automation.Test.Selenium_Exercises
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;

    /// <summary>
    /// Defines the <see cref="CheckboxExercises" />
    /// </summary>
    internal class CheckboxExercises
    {
        /// <summary>
        /// The Checkbox
        /// </summary>
        [Test]
        public void Checkbox()
        {
            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            // Navigate to the URL
            driver.Navigate().GoToUrl("https://demoqa.com/checkbox");

            // Find the checkbox element by its XPath and click it
            IWebElement checkbox = driver.FindElement(By.XPath("//span[@class='rct-checkbox']"));
            checkbox.Click();

            // Optionally, you can verify if the checkbox is selected
            IWebElement checkboxInput = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            bool isChecked = checkboxInput.Selected;
            Console.WriteLine("Checkbox is selected: " + isChecked);

            // Wait for a few seconds to see the result
            System.Threading.Thread.Sleep(3000);

            // Close the browser
            driver.Quit();
        }
    }
}
