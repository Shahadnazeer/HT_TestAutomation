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



namespace HT_Design_Pattern.PageObjects
{
    public class DraftPage 
    {
        public DraftPage() 
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        public IWebElement DraftField => BaseTest.driver.FindElement(By.XPath("//a[contains(text(),'Drafts')]"));

        public IWebElement DraftMail => BaseTest.driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public WebDriverWait wait = new WebDriverWait(BaseTest.driver, TimeSpan.FromSeconds(50));

        public IWebElement SendMail => BaseTest.driver.FindElement(By.XPath("//div[text()='Send']"));

        public void DraftMails()
        {
            //DraftField.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DraftField));
            var Draftbutton = new Button(DraftField);
            Draftbutton.Click();
            //DraftMail.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DraftMail));
            var DraftMailbutton = new Button(DraftMail);
            DraftMailbutton.Click();
            Assert.AreEqual(true, DraftMail.Displayed); // Verify, that the mail presents in ‘Drafts’ folder.

        }

        public void sendMailClick()
        {
            //SendMail.Click();
            var SendMailbutton = new Button(SendMail);
            SendMailbutton.Click();

        }

        

    }

}
