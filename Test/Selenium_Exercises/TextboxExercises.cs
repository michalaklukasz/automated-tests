namespace Selenium_Automation.Test.Selenium_Exercises
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    /// <summary>
    /// Defines the <see cref="TextboxExercises" />
    /// </summary>
    internal class TextboxExercises
    {
        /// <summary>
        /// The Textbox
        /// </summary>
        [Test]
        public void Textbox()
        {

            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            // Navigate to the URL
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            // Find the text box element by its ID and send keys
            IWebElement fullNameTextBox = driver.FindElement(By.Id("userName"));
            fullNameTextBox.SendKeys("John Doe");

            IWebElement emailTextBox = driver.FindElement(By.Id("userEmail"));
            emailTextBox.SendKeys("john.doe@example.com");

            IWebElement currentAddressTextBox = driver.FindElement(By.Id("currentAddress"));
            currentAddressTextBox.SendKeys("123 Main St");

            IWebElement permanentAddressTextBox = driver.FindElement(By.Id("permanentAddress"));
            permanentAddressTextBox.SendKeys("456 Elm St");

            // Optionally, you can submit the form
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

            // Wait for a few seconds to see the result
            System.Threading.Thread.Sleep(3000);

            // Close the browser
            driver.Quit();
        }
    }
}
