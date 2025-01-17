namespace Selenium_Automation.Test.Selenium_Exercises
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;

    /// <summary>
    /// Defines the <see cref="CheckboxExercises" />
    /// </summary>
    internal class Alerts
    {
        /// <summary>
        /// The Checkbox
        /// </summary>
        [Test]
        public void Alert()
        {
            IWebDriver driver = new ChromeDriver();

            // Navigate to the DemoQA Alerts page
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Wait until the button is clickable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Trigger the first alert
            IWebElement alertButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("alertButton")));
            alertButton.Click();

            // Wait for the alert to be present
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();

            // Print alert text
            Console.WriteLine("Alert text: " + alert.Text);

            // Accept the alert
            alert.Accept();

            // Trigger the second alert
            IWebElement timerButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("timerAlertButton")));
            timerButton.Click();

            // Wait for the alert to be present
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            alert = driver.SwitchTo().Alert();

            // Print alert text
            Console.WriteLine("Timer Alert text: " + alert.Text);

            // Accept the alert
            alert.Accept();

            // Trigger the confirm alert
            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("confirmButton")));
            confirmButton.Click();

            // Wait for the confirm alert to be present
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            alert = driver.SwitchTo().Alert();

            // Print confirm alert text
            Console.WriteLine("Confirm Alert text: " + alert.Text);

            // Dismiss the confirm alert
            alert.Dismiss();

            // You can handle the result of the confirm alert if needed
            // Additional code to check the result can be added here
        }
    }
}
