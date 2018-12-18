using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                //driver.Close();
                //driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [TestMethod]
        public void TheCase1Test()
        {
            driver.Navigate().GoToUrl("http://lunakino.ru/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[1]")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("a.releases-item")));
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase2Test()
        {
            driver.Navigate().GoToUrl("http://lunakino.ru/");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Киноцентр «Луна»'])[2]/following::div[1]")).Click();
            try
            {
                Assert.AreEqual("http://www.ruslan.lunakino.ru/", driver.Url);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase3Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Кинотеатр «Руслан»'])[2]/following::div[1]")).Click();
            try
            {
                Assert.AreEqual("http://www.lunakino.ru/", driver.Url);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase4Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("a.releases-item")));
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase5Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/");
            driver.FindElement(By.LinkText("Новости")).Click();
            try
            {
                Assert.AreEqual("http://www.lunakino.ru/news", driver.Url);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase6Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru");
            driver.FindElement(By.LinkText("Новости")).Click();
            try
            {
                Assert.AreEqual("http://www.ruslan.lunakino.ru/news", driver.Url);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase7Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='ср'])[4]/following::div[5]")).Click();
        }

        [TestMethod]
        public void TheCase8Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='ср'])[4]/following::div[5]")).Click();
        }

        [TestMethod]
        public void TheCase9Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='ср'])[4]/following::div[2]")));
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase10Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='ср'])[4]/following::div[2]")));
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase11Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Средний'])[1]/following::div[2]")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div#root")));
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase12Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Средний'])[1]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Диван на двоих:'])[16]/following::div[47]")).Click();
        }

        [TestMethod]
        public void TheCase13Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Малый'])[2]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Диван на двоих:'])[19]/following::div[71]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Диван на двоих:'])[14]/following::div[23]")).Click();
            Assert.AreEqual("Купить 2 билета", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Назад'])[1]/following::button[1]")).Text);
        }


        [TestMethod]
        public void TheCase14Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Малый'])[2]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Занято'])[1]/following::div[8]")).Click();
            Assert.AreEqual("Места не выбраны", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Назад'])[1]/following::button[1]")).Text);
        }

        [TestMethod]
        public void TheCase15Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Средний'])[1]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Диван на двоих:'])[19]/following::div[39]")).Click();
            Assert.AreEqual("Купить 1 билет", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Назад'])[1]/following::button[1]")).Text);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Диван на двоих:'])[19]/following::div[39]")).Click();
            Assert.AreEqual("Места не выбраны", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Назад'])[1]/following::button[1]")).Text);
        }

        [TestMethod]
        public void TheCase16Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Средний'])[1]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Диван на двоих:'])[20]/following::div[31]")).Click();
        }

        [TestMethod]
        public void TheCase17Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Средний'])[1]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Диван на двоих:'])[12]/following::div[91]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Назад'])[1]/following::button[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email для получения билетов'])[1]/following::input[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email для получения билетов'])[1]/following::input[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email для получения билетов'])[1]/following::input[1]")).SendKeys("test@mail.ru");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='условиями покупки'])[1]/following::button[1]")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Описание платежа'])[1]/preceding::img[1]")));
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase18Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Средний'])[1]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Диван на двоих:'])[10]/following::div[55]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Назад'])[1]/following::button[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Поле не должно быть пустым'])[1]/following::div[2]")).Click();
        }

        [TestMethod]
        public void TheCase19Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/news");
            driver.FindElement(By.CssSelector("a.news-item__title")).Click();
        }

        [TestMethod]
        public void TheCase20Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/news");
            driver.FindElement(By.CssSelector("a.news-item__title")).Click();
        }

        [TestMethod]
        public void TheCase21Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Средний'])[1]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Аквамен'])[1]/following::button[1]")).Click();
        }

        [TestMethod]
        public void TheCase22Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/release/8741");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сегодня'])[1]/following::span[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Зал Средний'])[1]/following::div[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
            driver.FindElement(By.CssSelector("div.kw-overlay")).Click();
        }

        [TestMethod]
        public void TheCase23Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Новости'])[1]/following::a[1]")).Click();
            try
            {
                Assert.AreEqual("О кинотеатре Луна", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='О кинотеатре'])[1]/following::div[4]")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase24Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Новости'])[1]/following::a[1]")).Click();
            try
            {
                Assert.AreEqual("О кинотеатре Руслан", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='О кинотеатре'])[1]/following::div[4]")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase25Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/news");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Киноцентр «Луна»'])[1]/preceding::a[1]")).Click();
            try
            {
                Assert.AreEqual("http://www.lunakino.ru/", driver.Url);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase26Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/news");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Кинотеатр «Руслан»'])[1]/preceding::a[1]")).Click();
            try
            {
                Assert.AreEqual("http://www.ruslan.lunakino.ru/", driver.Url);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase27Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/news");
            driver.FindElement(By.CssSelector("a.breadcrumbs__link")).Click();
            try
            {
                Assert.AreEqual("http://www.lunakino.ru/", driver.Url);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase28Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/news");
            driver.FindElement(By.CssSelector("a.breadcrumbs__link")).Click();
            try
            {
                Assert.AreEqual("http://www.ruslan.lunakino.ru/", driver.Url);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void TheCase29Test()
        {
            driver.Navigate().GoToUrl("http://www.lunakino.ru/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Скоро в кино'])[1]/following::div[4]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [TestMethod]
        public void TheCase30Test()
        {
            driver.Navigate().GoToUrl("http://www.ruslan.lunakino.ru/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Скоро в кино'])[1]/following::div[4]")).Click();
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
