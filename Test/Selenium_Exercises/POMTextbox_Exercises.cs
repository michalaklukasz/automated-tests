namespace TestOpsTrainingSeleniumCSharp.Test.Selenium_Exercises
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using TestOpsTrainingSeleniumCSharp.Pages;
    using System;

    /// <summary>
    /// Defines the <see cref="POM_Example" />
    /// </summary>
    internal class POM_Example
    {
        /// <summary>
        /// The POM
        /// </summary>
        [Test]
        public void POM()
        {
            // Initialize WebDriver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            //Navigate to the URL
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            // Scroll down by 1000 pixels
            TextboxPages page = new TextboxPages(driver);
            page.JavaScriptExecutorToScroll();

            // Enter values into text boxes
            page.EnterTheValues("John Doe", "john@example.com", "Main St", "Elm St");

            // Scroll down by 1000 pixels
            page.JavaScriptExecutorToScroll();

            // Click on submit
            page.submitButton();

            // Verification (you can add more detailed verification as needed)
            Console.WriteLine("Form submitted successfully.");

            // Close the browser
            driver.Quit();
        }
    }
}
