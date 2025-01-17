using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOpsTrainingSeleniumCSharp.Pages
{

    internal class TextboxPages
    {
        public IWebDriver driver;

        IWebElement userName => driver.FindElement(By.Id("userName"));
        IWebElement userEmail => driver.FindElement(By.Id("userEmail"));
        IWebElement currentAddress => driver.FindElement(By.Id("currentAddress"));
        IWebElement permanentAddress => driver.FindElement(By.Id("permanentAddress"));
        IWebElement submit => driver.FindElement(By.Id("submit"));
        IWebElement verifyName => driver.FindElement(By.Id("name"));
        IWebElement verifyEmail => driver.FindElement(By.Id("email"));




        public TextboxPages(IWebDriver driver1)
        {
            driver = driver1;
        }

        public void EnterTheValues(String name, String email, String currentAdd, String permanentAdd)
        {
            userName.SendKeys(name);
            userEmail.SendKeys(email);
            currentAddress.SendKeys(currentAdd);
            permanentAddress.SendKeys(permanentAdd);
        }

        public void JavaScriptExecutorToScroll()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,1000)");
        }

        public void submitButton()
        {
            submit.Click();
        }

        public String verifyNameTextbox()
        {
            return verifyName.Text;
        }

        public String verifyEmailTextbox()
        {
            return verifyEmail.Text;
        }

    }
}
