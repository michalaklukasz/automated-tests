using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceLabDemo
{
    [TestFixture]
    [AllureNUnit]
    [AllureParentSuite("Selenium C# Training Suite")]
    public class SauceDemoTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();

            // Disable notifications
            options.AddArgument("--incognito");


            // Initialize Chrome driver and open the browser
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Initialize wait for up to 10 seconds to handle any dynamic elements
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void AddProductToCartAndPlaceOrder()
        {
            // Step 1: Log in to the Sauce Labs website
            IWebElement usernameField = driver.FindElement(By.Id("user-name"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("login-button"));

            usernameField.SendKeys("standard_user"); // Use the correct username
            passwordField.SendKeys("secret_sauce");  // Use the correct password
            loginButton.Click();


            // Step 2: Select a product and get its price
            // Locate the product by its name using XPath with text()
            IWebElement productByName = driver.FindElement(By.XPath("//div[@class='inventory_item_name ' and text()='Sauce Labs Backpack']"));

            // Step 3: Find the corresponding product price using the relative XPath from the product name
            IWebElement productPrice = driver.FindElement(By.XPath("//div[@class='inventory_item_name ' and text()='Sauce Labs Backpack']/following::div[@class='inventory_item_price']"));


            string productPriceOnPage = productPrice.Text; // Get the product price displayed on the page

            // Step 4: Find and click the corresponding "Add to Cart" button for the product
            IWebElement addToCartButton = driver.FindElement(By.XPath("//div[@class='inventory_item_name ' and text()='Sauce Labs Backpack']/following::button[contains(@class,'btn_inventory')]"));
            addToCartButton.Click(); // Click the "Add to Cart" button

            // Step 5: Navigate to the cart
            IWebElement cartButton = driver.FindElement(By.Id("shopping_cart_container"));
            cartButton.Click();

            // Step 6: Validate the product price in the cart
            IWebElement cartProductPrice = driver.FindElement(By.ClassName("inventory_item_price"));
            string productPriceInCart = cartProductPrice.Text;

            // Validate that the product price in the cart matches the price on the product page
            Assert.AreEqual(productPriceOnPage, productPriceInCart, "Product price does not match!");

            // Step 7: Proceed to checkout
            IWebElement checkoutButton = driver.FindElement(By.Id("checkout"));
            checkoutButton.Click();

            // Step 8: Fill in checkout details
            driver.FindElement(By.Id("first-name")).SendKeys("John");
            driver.FindElement(By.Id("last-name")).SendKeys("Doe");
            driver.FindElement(By.Id("postal-code")).SendKeys("12345");

            IWebElement continueButton = driver.FindElement(By.Id("continue"));
            continueButton.Click();

            // Step 9: Finish the order
            IWebElement finishButton = driver.FindElement(By.Id("finish"));
            finishButton.Click();

            // Step 10: Validate that the order is placed
            IWebElement confirmationMessage = driver.FindElement(By.ClassName("complete-header"));
            Assert.AreEqual("Thank you for your order!", confirmationMessage.Text);

            // Print a message to the console for successful test
            Console.WriteLine("Order has been placed successfully.");
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
               
            }
        }
    }
}

