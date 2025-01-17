namespace Selenium_Automation.Test.Selenium_Exercises
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;

    /// <summary>
    /// Defines the <see cref="CheckboxExercises" />
    /// </summary>
    internal class Windows
    {
        /// <summary>
        /// The Checkbox
        /// </summary>
        [Test]
        public void Window()
        {
            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            // Navigate to the DemoQA Browser Windows page
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Create a wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Handle the "Small Modal" window
            IWebElement smallModalButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("//button[@id='tabButton']")));
            smallModalButton.Click();

            // Wait for the small modal to be visible
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("modal-content")));

            // Interact with the small modal
            Console.WriteLine("Small Modal is displayed.");
            IWebElement closeSmallModalButton = driver.FindElement(By.Id("closeSmallModal"));
            closeSmallModalButton.Click();
            Console.WriteLine("Small Modal closed.");

            // Handle the "Large Modal" window
            IWebElement largeModalButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("showLargeModal")));
            largeModalButton.Click();

            // Wait for the large modal to be visible
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("modal-content")));

            // Interact with the large modal
            Console.WriteLine("Large Modal is displayed.");
            IWebElement closeLargeModalButton = driver.FindElement(By.Id("closeLargeModal"));
            closeLargeModalButton.Click();
            Console.WriteLine("Large Modal closed.");

            driver.Quit();
        }
    }
}
