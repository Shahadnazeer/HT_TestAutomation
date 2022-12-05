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

    public class SentPage
    {
        public SentPage() 
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        public IWebElement SentField => BaseTest.driver.FindElement(By.XPath("//a[contains(text(),'Sent')]"));

        public IWebElement SentMail => BaseTest.driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement newTextbox => BaseTest.driver.FindElement(By.XPath("//div[@aria-label='Message Body']"));

        public IWebElement newSendField => BaseTest.driver.FindElement(By.XPath("//div[text()='Send']"));

        public IWebElement updatedSentMail => BaseTest.driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement NewSentField => BaseTest.driver.FindElement(By.XPath("//a[contains(text(),'Sent')]"));

        public IWebElement moreField => BaseTest.driver.FindElement(By.XPath("//span[contains(text(),'More')]"));

        public IWebElement trashField => BaseTest.driver.FindElement(By.XPath("//a[contains(text(),'Trash')]"));

        public IWebElement newSentMail => BaseTest.driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement AccountField => BaseTest.driver.FindElement(By.CssSelector("img.gb_Ca.gbii"));

        public IWebElement SignOut => BaseTest.driver.FindElement(By.XPath("//div[text()='Sign out']"));

        public void SendMails(string newMessage)
        {
            Actions ac = new Actions(BaseTest.driver);

            WebDriverWait wait = new WebDriverWait(BaseTest.driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentField));
            var SentButton = new Button(SentField);
            SentButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentMail));
            ac.ContextClick(SentMail).Build().Perform();
            ac.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
            newTextbox.SendKeys(newMessage);
            ac.MoveToElement(newSendField).Click().Build().Perform();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(updatedSentMail));
            //var updatedSentButton = new Button(updatedSentMail);
            //updatedSentButton.Click();
            //BaseTest.driver.Navigate().Back();
            NewSentField.Click();
        }

        public void DeleteMail()
        {
            Actions ac = new Actions(BaseTest.driver);

            WebDriverWait wait = new WebDriverWait(BaseTest.driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(moreField));
            ac.MoveToElement(moreField).Build().Perform();
            ac.Click(moreField).Perform();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(trashField));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(newSentMail));

            ac.DragAndDrop(newSentMail, trashField).Build().Perform();
        }


        public void LogOut()
        {
            //AccountField.Click();
            var AccountButton = new Button(AccountField);
            AccountButton.Click();
            BaseTest.driver.SwitchTo().Frame("account");
            //SignOut.Click();
            var SignOutButton = new Button(SignOut);
            SignOutButton.Click();
            BaseTest.driver.SwitchTo().ParentFrame();
        }


    }

}
