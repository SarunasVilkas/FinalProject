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
    public class VerywellfitCalBurnDailyCalcPage : BasePage
    {
        private const string pageAddress = "https://www.verywellfit.com/how-many-calories-do-i-burn-every-day-3495464";

        private IWebElement metricBtn => Driver.FindElement(By.CssSelector("#radio-toggle_2-2 > .btn:nth-child(4)"));
        private IWebElement maleRadioBtn => Driver.FindElement(By.CssSelector("#radio-button_7-2 .label-inner"));
        private IWebElement femaleRadioBtn => Driver.FindElement(By.CssSelector("#radio-button_8-2 .label-inner"));
        private IWebElement ageTxt => Driver.FindElement(By.Id("tool-input_14-2"));
        private IWebElement heightTxt => Driver.FindElement(By.Id("tool-input_16-2"));
        private IWebElement weightTxt => Driver.FindElement(By.Id("tool-input_17-2"));
        private IWebElement sedActvRadioBtn => Driver.FindElement(By.CssSelector("#radio-button_9-2 .checkbox-text"));
        private IWebElement lightActvRadioBtn => Driver.FindElement(By.CssSelector("#radio-button_10-2 .checkbox-text"));
        private IWebElement modActvRadioBtn => Driver.FindElement(By.CssSelector("#radio-button_11-2 .checkbox-text"));
        private IWebElement veryActvRadioBtn => Driver.FindElement(By.CssSelector("#radio-button_12-2 .checkbox-text"));
        private IWebElement calcBtn => Driver.FindElement(By.CssSelector(".btn-padded"));
        private IWebElement startOverBtn => Driver.FindElement(By.CssSelector(".btn-start-over"));
        private IWebElement result => Driver.FindElement(By.CssSelector("#bmr-results_2-2 > h2"));
        private IWebElement errorMsg => Driver.FindElement(By.Id("alert_5-2"));

        public VerywellfitCalBurnDailyCalcPage(IWebDriver webdriver) : base(webdriver) { }

        public VerywellfitCalBurnDailyCalcPage NavigateToHome()
        {
            if (Driver.Url != pageAddress)
            {
               Driver.Url = pageAddress;
            }
            return this;
        }
        public VerywellfitCalBurnDailyCalcPage CloseCookiePopUp()
        {
            if (Driver.Manage().Cookies.GetCookieNamed("OptanonAlertBoxClosed") == null)
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(verywellfitCalBurnDailyCalcpg => Driver.FindElement(By.Id("onetrust-accept-btn-handler")).Displayed);
                Driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            }
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage ChooseMetricUnits()
        {
            if (!metricBtn.Selected)
                    metricBtn.Click();
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage ChooseGender(string gender)
        {
            if (gender.Equals("male") && !maleRadioBtn.Selected)
                maleRadioBtn.Click();
            if (gender.Equals("female") && !femaleRadioBtn.Selected)
                femaleRadioBtn.Click();
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage EnterAge(string text)
        {
            ageTxt.Clear();
            ageTxt.SendKeys(text);
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage EnterHeight(string height)
        {
            heightTxt.Clear();
            heightTxt.SendKeys(height);
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage EnterWeight(string weight)
        {
            weightTxt.Clear();
            weightTxt.SendKeys(weight);
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage ChooseActivity(string activity)
        {
            if (activity.Equals("sedentary") && !sedActvRadioBtn.Selected)
                sedActvRadioBtn.Click();

            if (activity.Equals("light") && !lightActvRadioBtn.Selected)
                lightActvRadioBtn.Click();

            if (activity.Equals("moderate") && !modActvRadioBtn.Selected)
                modActvRadioBtn.Click();

            if (activity.Equals("very")&& !veryActvRadioBtn.Selected)
                veryActvRadioBtn.Click();
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage Calculate()
        {
            calcBtn.Click();
            return this;
        }



        public VerywellfitCalBurnDailyCalcPage ValidateResult(string exp)
        {

            Assert.IsTrue(result.Text.Contains(exp), $"Wrong result, it shoud've been {exp}, but instead it was {result.Text}");
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage ValidateErrorMessage()
        {
            Assert.IsTrue(errorMsg.Text.Contains("Please enter a valid age"), $"Wrong text showed {errorMsg.Text}");
            return this;
        }

        public VerywellfitCalBurnDailyCalcPage StartOverPage()
        {
            Driver.Navigate().Refresh();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
            return this;
        }





    }
}
