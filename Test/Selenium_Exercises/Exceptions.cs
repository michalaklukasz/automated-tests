namespace Selenium_Automation.Test.Selenium_Exercises
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;

    /// <summary>
    /// Defines the <see cref="ExceptionExercises" />
    /// </summary>
    internal class Exceptions
    {
        /// <summary>
        /// The Checkbox
        /// </summary>
        [Test]
        public void Exception_Example()
        {
            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            // Navigate to the DemoQA Browser Windows page
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            // Set implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {
                // Navigate to the DemoQA Elements page
                driver.Navigate().GoToUrl("https://demoqa.com/elements");

                // Create a WebDriverWait instance
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Click on the "Text Box" section
                IWebElement textBoxButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Text Box']")));
                textBoxButton.Click();

                // Fill out the text box
                IWebElement fullNameInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("userName")));
                fullNameInput.SendKeys("John Doe");

                IWebElement emailInput = driver.FindElement(By.Id("userEmail"));
                emailInput.SendKeys("john.doe@example.com");

                IWebElement currentAddressInput = driver.FindElement(By.Id("currentAddress"));
                currentAddressInput.SendKeys("123 Main St");

                IWebElement permanentAddressInput = driver.FindElement(By.Id("permanentAddress"));
                permanentAddressInput.SendKeys("456 Elm St");

                IWebElement submitButton = driver.FindElement(By.Id("submit"));
                submitButton.Click();

                // Wait for the output to be visible after submission
                IWebElement output = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("output")));
                TestContext.WriteLine("Output:");
                TestContext.WriteLine(output.Text);
            }
            catch (NoSuchElementException ex)
            {
                TestContext.WriteLine("Element not found: " + ex.Message);
            }
            catch (ElementClickInterceptedException ex)
            {
                TestContext.WriteLine("Element could not be clicked: " + ex.Message);
            }
            catch (TimeoutException ex)
            {
                TestContext.WriteLine("Operation timed out: " + ex.Message);
            }
            catch (StaleElementReferenceException ex)
            {
                TestContext.WriteLine("The element is no longer attached to the DOM: " + ex.Message);
            }
            catch (WebDriverException ex)
            {
                TestContext.WriteLine("WebDriver error: " + ex.Message);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("An unexpected error occurred: " + ex.Message);
            }

            driver.Quit();
        }
    }
}
