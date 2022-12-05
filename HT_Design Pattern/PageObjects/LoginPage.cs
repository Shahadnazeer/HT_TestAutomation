using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Actions = OpenQA.Selenium.Interactions.Actions;


namespace HT_Design_Pattern.PageObjects
{
    public class LoginPage
    {
        public LoginPage() 
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        public IWebElement UsernameField => BaseTest.driver.FindElement(By.Id("identifierId"));

        public IWebElement NextButton => BaseTest.driver.FindElement(By.Id("identifierNext"));
        public IWebElement PasswordField => BaseTest.driver.FindElement(By.XPath("//*[@id='password']//input"));

        public WebDriverWait wait = new WebDriverWait(BaseTest.driver, TimeSpan.FromSeconds(50));
        
        public IWebElement LoginButton => BaseTest.driver.FindElement(By.Id("passwordNext"));

        public IWebElement MainPage => BaseTest.driver.FindElement(By.CssSelector("body"));

        //TODO string senderMail, string subject, string textbox parameter values are not used in function
        public void Login(string username, string password)
        {
            //username = "shahadnaz807@gmail.com";
            //password = "Epaam1234";
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)BaseTest.driver;
            WebDriverWait wait = new WebDriverWait(BaseTest.driver, TimeSpan.FromSeconds(50));
            jsExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border:2px solid red; background:yellow')", UsernameField);
            UsernameField.SendKeys(username); //pass this value from test
            //NextButton.Click();
            jsExecutor.ExecuteScript("arguments[0].click();", NextButton);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PasswordField));
            PasswordField.SendKeys(password); //pass this value from test

        }

        public void LoginClick()
        {
            //LoginButton.Click();
            var PasswordButton = new Button(LoginButton);
            PasswordButton.Click();
        }

        public void ViewMainPage()
        {
            MainPage.Click();
        }

    }
}