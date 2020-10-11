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

        public object SeleniumExtras { get; private set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(basePage);
            Driver.FindElement(By.CssSelector("#loginarea > span.show-login-form.inline-block.pointer.hover-fade")).Click();
            Driver.FindElement(By.Id("id_username")).SendKeys("ldidil");
            Driver.FindElement(By.Id("id_password")).SendKeys("d98d98");
            Driver.FindElement(By.Id("loginbutton")).Click();
            //Thread.Sleep(7000);
            //Driver.FindElement(By.CssSelector("body > div.app_gdpr--SPx19r > div.popup_popup--1TXMW > div.popup_content--2JBXA > div > div.details_footer--1oDeu > button.button_button--lgX0P.details_save--1ja7w > b > span")).Click();

        }

        [Test]
        public void Krysztalkuj()
        {

            for (int i = 3099; i < 3105; i++)
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

        //[Test]
        //public void Aktywnosc()
        //{
        //    Driver.Navigate().GoToUrl($"{basePage}cloud/ubrania/suknie-sukienki/713679-sukienka-asos/");
        //    Thread.Sleep(3000);
        //    Driver.FindElement(By.CssSelector("body > div.page > div.photos_stage.sp-init > div.ps_outer > div.ps_inner.vert-middle > div > div.ps_popup > div.ps_imgstage > div.ps_thumbs > div:nth-child(4) > a > span")).Click();
        //    Thread.Sleep(5000);

        //    for (int i = 0; i <50; i++)
        //    {

               
        //        Driver.FindElement(By.CssSelector("#videoDiv > button")).Click();
        //        Thread.Sleep(4000);

        //    }
        //    Driver.Close();
        //}

        public void ScrollPage(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
        public void BorderElement(IWebElement elem)
        {
            // draw a border around the found element
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