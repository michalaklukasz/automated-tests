using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Selenium_Automation.Test.Selenium_Exercises
{
    internal class Datadriven_Exercises
    {
        [Test]
        public void DataDrivenTesting()
        {

            // Create ChromeOptions instance
            ChromeOptions options = new ChromeOptions();

            // Add incognito argument
            options.AddArgument("--incognito");

            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver(options);

            //Maximum the driver
            driver.Manage().Window.Maximize();

            // Navigate to the URL
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Login to the website
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            // Read test data from Excel
            var workbook = new XLWorkbook(@"C:\\volvo\\Selenium_Csharp_training_support\\CSharp_Selenium_Learning_Program1\\Selenium_Automation\\Selenium Automation\\Test\\Selenium_Exercises\\TestData.xlsx");
            //var workbook = new XLWorkbook(@"C:\path\to\your\TestData.xlsx");

            var worksheet = workbook.Worksheet(1);
            var title = worksheet.Cell(1, 1).GetString();
            var description = worksheet.Cell(1, 2).GetString();

            // Add one product to the cart
            driver.FindElement(By.XPath("//div[text()='" + title + "']")).Click();

            // Click on add to cart button
            driver.FindElement(By.XPath("//button[@data-test='add-to-cart']")).Click();

            // Click on add to cart image
            driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();

            // Verify again with the title and description
            var cartTitle = driver.FindElement(By.ClassName("inventory_item_name")).Text;
            var cartDescription = driver.FindElement(By.ClassName("inventory_item_desc")).Text;

            //Verify first name
            Assert.AreEqual(title, cartTitle);

            //verify emails
            Assert.AreEqual(description, cartDescription);

            // Click on checkout
            driver.FindElement(By.Id("checkout")).Click();

            // Fill first name, last name, and zip code
            driver.FindElement(By.Id("first-name")).SendKeys("John");
            driver.FindElement(By.Id("last-name")).SendKeys("Doe");
            driver.FindElement(By.Id("postal-code")).SendKeys("12345");
            driver.FindElement(By.Id("continue")).Click();

            // Verify again with the title and description
            var checkoutTitle = driver.FindElement(By.ClassName("inventory_item_name")).Text;
            var checkoutDescription = driver.FindElement(By.ClassName("inventory_item_desc")).Text;

            //Verify first name
            Assert.AreEqual(title, checkoutTitle);

            //verify emails
            Assert.AreEqual(description, checkoutDescription);

            // Close the browser
            driver.Quit();
        }

        [Test]
        public void DemoQADataDrivenTesting()
        {
            // Initialize WebDriver
            IWebDriver driver = new ChromeDriver();

            //Maximum the driver
            driver.Manage().Window.Maximize();

            //Navigate to the URL
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            //Open Workbook
            var workbook = new XLWorkbook("C:\\volvo\\Selenium_Csharp_training_support\\CSharp_Selenium_Learning_Program1\\Selenium_Automation\\Selenium Automation\\Test\\Selenium_Exercises\\TestData1.xlsx");

            //Get the data from the excel
            var worksheet = workbook.Worksheet(1);
            var name = worksheet.Cell(2, 1).GetString();
            var email = worksheet.Cell(2, 2).GetString();
            var currentAddress = worksheet.Cell(2, 3).GetString();
            var permanentAddress = worksheet.Cell(2, 4).GetString();

            // Enter values into text boxes
            driver.FindElement(By.Id("userName")).SendKeys(name);
            driver.FindElement(By.Id("userEmail")).SendKeys(email);
            driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            driver.FindElement(By.Id("permanentAddress")).SendKeys(permanentAddress);

            // Scroll down by 1000 pixels
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,1000)");

            // Click on submit
            driver.FindElement(By.Id("submit")).Click();

            // Verification (you can add more detailed verification as needed)
            Console.WriteLine("Form submitted successfully.");

            //Get the text from textbox
            var verifyName = driver.FindElement(By.Id("name")).Text;
            var verifyEmail = driver.FindElement(By.Id("email")).Text;

            //Verify first name
            Assert.AreEqual("Name:" + name, verifyName);

            //verify emails
            Assert.AreEqual("Email:" + email, verifyEmail);

            // Close the browser
            driver.Quit();
        }
    }
}
