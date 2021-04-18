using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject.Page
{
    public class VerywellfitRecipeNutritionCalcPage : BasePage
    {
        private const string pageAddress = "https://www.verywellfit.com/recipe-nutrition-analyzer-4157076";

        private IWebElement textBox => Driver.FindElement(By.XPath("//textarea"));
        private SelectElement servingsDropDown => new SelectElement(Driver.FindElement(By.XPath("//select")));
        private IWebElement analyzeBtn => Driver.FindElement(By.CssSelector(".btn-padded"));
        private IWebElement resultTxt => Driver.FindElement(By.CssSelector(".results-heading"));

        public VerywellfitRecipeNutritionCalcPage(IWebDriver webdriver) : base(webdriver) { }

        public VerywellfitRecipeNutritionCalcPage NavigateToHome()
        {
            if (Driver.Url != pageAddress)
            {
                Driver.Url = pageAddress;
            }
            return this;
        }

        public VerywellfitRecipeNutritionCalcPage CloseCookiePopUp()
        {
            if (Driver.Manage().Cookies.GetCookieNamed("OptanonAlertBoxClosed") == null)
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(verywellfitPaceCalcpg => Driver.FindElement(By.Id("onetrust-accept-btn-handler")).Displayed);
                Driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            }
            return this;
        }

        public VerywellfitRecipeNutritionCalcPage AddTextToTextBox(string first, string second, string third)
        {

            List<string> ingredients = new List<string> { first, second, third };
            textBox.Clear();
            foreach (string item in ingredients)
            {
                textBox.SendKeys(item);
                textBox.SendKeys("\n");
            }
            return this;
        }

        public VerywellfitRecipeNutritionCalcPage SelectFromServingDropDown(string value)
        {
            servingsDropDown.SelectByText(value);
            return this;
        }

        public VerywellfitRecipeNutritionCalcPage GetAnlyzed()
        {
            analyzeBtn.Click();
            return this;
        }

        public VerywellfitRecipeNutritionCalcPage VerifyResult(string exp)
        {
            List<IWebElement> alertElementList = new List<IWebElement>();
            alertElementList.AddRange(Driver.FindElements(By.CssSelector("#alert_1-2 > .alert-text")));

            if (alertElementList.Count > 0)
            {
                Assert.Pass("Error message shown: Wrong ingredient added");
            }
            Assert.IsTrue(resultTxt.Text.Contains(exp), $"Result is wrong. It shold shave been {exp} calories, but we got {resultTxt.Text}");
            return this;
        }
    }
}
