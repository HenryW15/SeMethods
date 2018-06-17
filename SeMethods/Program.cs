using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeMethods
{
    class Program
    {
        static void Main(string[] args)
        {


            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("www.test.com");
            driver.Manage().Window.Maximize();
            Console.WriteLine("Navigated to site");

            // Verify element displayed

            IWebElement element = driver.FindElement(By.Id("test"));
            Console.WriteLine(element.Displayed);


            // Wait /Sleep
            System.Threading.Thread.Sleep(2000);

            // clear text box 
            driver.FindElement(By.ClassName("test")).Clear();

            //  Send text/ keys
            driver.FindElement(By.Name("test")).SendKeys("henry");

            // Click

            driver.FindElement(By.Id("test")).Click();

            //Assert checkbox ticked 
            try
            {
                Assert.IsTrue(driver.FindElement(By.Id("test")).Selected);
                Console.WriteLine("test henry");
            }
            catch (Exception e)
            {

                Console.Write(e);
            }

            // Assert Are Equal to

            try
            {
                Assert.AreEqual("google", driver.Title);
                Console.WriteLine("Title Pass");
            }
            catch (Exception e)
            {

                Console.Write(e);
            }
            // Assert page source

            string HtmlPage = "bbc1";
            try
            {
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains(HtmlPage));
            }
            catch (Exception e)
            {

                Console.Write(e);
                Console.Read();
            }

            // Assert image displayed 

            try
            {
                Assert.IsTrue(driver.FindElement(By.Id("test")).Displayed);
                Console.WriteLine("image displayed");
            }
            catch (Exception e)
            {

                Console.Write(e);
            }

            // Select Drop Down Menu DDL

            var option = driver.FindElement(By.Id("carselect"));
            var SelectElement1 = new SelectElement(option);
            System.Threading.Thread.Sleep(5000);
            SelectElement1.SelectByText("Honda");

            // Or
            string name = "honda";
            IWebElement HenryDDL = driver.FindElement(By.Id("test"));
            HenryDDL.Click();

            SelectElement dropdown = new SelectElement(HenryDDL);
            dropdown.SelectByText(name);

            // Get Text 

            IWebElement outPutvalue = driver.FindElement(By.ClassName("test"));
            string currencyValue = outPutvalue.GetAttribute("value");
            Console.WriteLine("Value from textbox is" + currencyValue);

            // Right click

            IWebElement element1 = driver.FindElement(By.Id("bmwradio"));
            System.Threading.Thread.Sleep(5000);

            Actions builder = new Actions(driver);
            builder.ContextClick(element).Build().Perform();

            // Hover and Click 

            Actions builder1 = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.PartialLinkText("Vacancies")))
            .Click().Build().Perform();

            String value = driver.FindElement(By.PartialLinkText("Vacancies")).GetAttribute("Shifts");

            // SCROLL DOWN WINDOW

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0, 290);");
            Console.WriteLine(“Scrolled page down”);

            //OR
            driver.FindElement(By.Id("filter-£500"));
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageDown).Build().Perform();

            //OR
            IWebElement element = driver.FindElement(By.ClassName("Great New Price"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();

            //Take Screenshot

            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            String fp = "C:\\" + "snapshot" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
            screenshot.SaveAsFile(fp, ScreenshotImageFormat.Png);

            //PAGE OBJECTS - Expression bodied members
            //Constructor 
            public loginpageobjects(IWebDriver driver) => _driver = driver;
            public IWebElement usernametxtbox => _driver.FindElement(By.Id("test"));

        // Refresh page

        driver.Navigate().Refresh();
        Console.WriteLine("Page refreshed");

            // Navigate forward/ backwards

            driver.Navigate().Back();
            driver.Navigate().Forward();

        // Accept alert

        IAlert alert = driver.SwitchTo().Alert();
        alert.Accept();

            // if else Conditional statements 

            int x = 10;

            if (x > 10)
            {
                Console.WriteLine("x is greater than 10");
            }
            else if (x< 10);
            {
                Console.WriteLine("x is less than 10");
            }

             // (if, else, else if)

             string password = "hello";

            if (password == "hello") 
            {
                Console.WriteLine("Password is correct");
            }
            else
	        {
                Console.WriteLine("Password is incorrect");
            }

            // Switch Statement

            int myNumber = 5;
            switch (myNumber)
            {
                case 1:
                    Console.WriteLine("The number is 1");
                    break;
                case 2:
                    Console.WriteLine("The number is 2");
                    break;
                case 3:
                    Console.WriteLine("The number is 3");
                    break;
                default:
                    Console.WriteLine("number unknown");
                    break;
            }
            
            //Foreach loop 
            
            // Close
            
            driver.Close();








        }
    }
}
