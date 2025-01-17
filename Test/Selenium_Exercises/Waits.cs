namespace Selenium_Automation.Test.Selenium_Exercises
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;
    using System;

    /// <summary>
    /// Defines the <see cref="WaitsExercises" />
    /// </summary>
    internal class Waits
    {
        /// <summary>
        /// The Checkbox
        /// </summary>
        [Test]
        public void wait()
        {
            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            // Implicit wait: set up a global wait time for all elements
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {
                // Navigate to the DemoQA Elements page
                driver.Navigate().GoToUrl("https://demoqa.com/elements");

                // Explicit wait: create an instance for specific conditions
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Example 1: Interacting with the Text Box element
                IWebElement textBoxButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Text Box']")));
                textBoxButton.Click();

                // Fill out the text box
                IWebElement fullNameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("userName")));
                fullNameInput.SendKeys("John Doe");

                IWebElement emailInput = driver.FindElement(By.Id("userEmail"));
                emailInput.SendKeys("john.doe@example.com");

                // Example 2: Submitting the form and getting the output
                IWebElement currentAddressInput = driver.FindElement(By.Id("currentAddress"));
                currentAddressInput.SendKeys("123 Main St");

                IWebElement permanentAddressInput = driver.FindElement(By.Id("permanentAddress"));
                permanentAddressInput.SendKeys("456 Elm St");

                IWebElement submitButton = driver.FindElement(By.Id("submit"));
                submitButton.Click();

                // Wait for the output to be visible after submission
                IWebElement output = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("output")));

                // Print the output
                TestContext.WriteLine("Output:");
                TestContext.WriteLine(output.Text);
            }
            catch (NoSuchElementException ex)
            {
                TestContext.WriteLine("Element not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }
    }
}
