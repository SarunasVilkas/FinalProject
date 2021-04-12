using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using FinalProject.Drivers;
using FinalProject.Page;
using FinalProject.Tools;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static VerywellfitPaceCalcPage verywellfitPaceCalcpg;
        public static VerywellfitRecipeNutritionCalcPage verywellfitRecipeNutritionCalcpg;
        public static VerywellfitCalBurnDailyCalcPage verywellfitCalBurnDailyCalcpg;

        [OneTimeSetUp]

        public static void OneTimeSetup()
        {
            driver = CustomDriver.GetChromeDriver();
            verywellfitPaceCalcpg = new VerywellfitPaceCalcPage(driver);
            verywellfitRecipeNutritionCalcpg = new VerywellfitRecipeNutritionCalcPage(driver);
            verywellfitCalBurnDailyCalcpg = new VerywellfitCalBurnDailyCalcPage(driver);
        }


        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                FailScreenshot.TakeScreenshot(driver);
            }

        }

        [OneTimeTearDown]

        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
