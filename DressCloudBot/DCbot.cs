using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;


namespace DressCloudBot
{
    public class Tests
    {
        public IWebDriver Driver;
        string basePage = "https://dresscloud.pl/";

        //required for proper operation
        readonly string login;
        readonly string password;

        int numberStartPage;
        int numberStopPage;

        public object SeleniumExtras { get; private set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(basePage);

            Driver.FindElement(By.CssSelector("#loginarea > span.show-login-form.inline-block.pointer.hover-fade")).Click();
            Driver.FindElement(By.Id("id_username")).SendKeys(login);
            Driver.FindElement(By.Id("id_password")).SendKeys(password);
            Driver.FindElement(By.Id("loginbutton")).Click();
       
        }

        [Test]
        public void Test()
        {

            for (int i = numberStartPage; i < numberStopPage; i++)
            {

                Driver.Navigate().GoToUrl($"{basePage}cloud/?strona={i}");
                Thread.Sleep(2000);
                var cristals = Driver.FindElements(By.ClassName("fa-diamond"));

                foreach (IWebElement e in cristals)
                {
                    //Thread.Sleep(200);
                    IsClickable(e);
                }
            }
            Driver.Close();
        }


        public void ScrollPage(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        //auxiliary function, used at the stage of code creation 
        //draw a border around the found element
        public void BorderElement(IWebElement elem)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].style.border='3px solid red'", elem);

        }
        public bool IsClickable(IWebElement element)
        {
            try
            {
                ScrollPage(element);
                IJavaScriptExecutor ex = (IJavaScriptExecutor)Driver;
                ex.ExecuteScript("arguments[0].click()", element);
                return true;

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element not found");
            }
            return false;
        }
    }


}