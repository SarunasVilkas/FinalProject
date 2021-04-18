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
    public class VerywellfitPaceCalcPage : BasePage
    {
        private const string pageAddress = "https://www.verywellfit.com/walking-and-running-pace-and-speed-calculator-3952317";

        private SelectElement unitsDropDown => new SelectElement(Driver.FindElement(By.CssSelector(".distance-unit select")));
        private IWebElement distanceInput => Driver.FindElement(By.CssSelector(".distance > .tool-input"));
        private IWebElement timeHoursInput => Driver.FindElement(By.Id("timeHours"));
        private IWebElement timeMinutesInput => Driver.FindElement(By.Id("timeMinutes"));
        private IWebElement timeSecondsInput => Driver.FindElement(By.Id("timeSeconds"));
        private SelectElement paceUnitsDropDown => new SelectElement(Driver.FindElement(By.Name("pace-unit")));
        private IWebElement calculatePaceBtn => Driver.FindElement(By.CssSelector(".btn-padded:nth-child(1)"));
        private IWebElement paceMin => Driver.FindElement(By.Id("paceMinutes"));
        private IWebElement paceSec => Driver.FindElement(By.Id("paceSeconds"));

        public VerywellfitPaceCalcPage(IWebDriver webdriver) : base(webdriver) { }

        public VerywellfitPaceCalcPage NavigateToHome()
        {
            if (Driver.Url != pageAddress)
            {
                Driver.Url = pageAddress;
            }
            return this;
        }

        public VerywellfitPaceCalcPage CloseCookiePopUp()
        {
            if (Driver.Manage().Cookies.GetCookieNamed("OptanonAlertBoxClosed") == null)
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(verywellfitPaceCalcpg => Driver.FindElement(By.Id("onetrust-accept-btn-handler")).Displayed);
                Driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            }
            return this;
        }

        public VerywellfitPaceCalcPage ChooseDistanceUnits(string units)
        {
            unitsDropDown.SelectByText(units);
            return this;
        }

        public VerywellfitPaceCalcPage ChooseDistance(string distance)
        {
            distanceInput.Clear();
            distanceInput.SendKeys(distance);
            return this;
        }

        public VerywellfitPaceCalcPage PickTimeH_m_s(string hours, string minutes = "0", string seconds = "0")
        {
            timeHoursInput.Clear();
            timeHoursInput.SendKeys(hours);

            timeMinutesInput.Clear();
            timeMinutesInput.SendKeys(minutes);

            timeSecondsInput.Clear();
            timeSecondsInput.SendKeys(seconds);
            return this;
        }

        public VerywellfitPaceCalcPage ChoosePaceUnits(string pUnits)
        {
            paceUnitsDropDown.SelectByText(pUnits);
            return this;
        }

        public VerywellfitPaceCalcPage Submit()
        {
            calculatePaceBtn.Click();
            return this;
        }

        public VerywellfitPaceCalcPage VerifyResult(string expMin, string expSec)
        {
            Assert.AreEqual(expMin, paceMin.GetAttribute("value"), "Pace time Minutes value are incorrect");
            Assert.AreEqual(expSec, paceSec.GetAttribute("value"), "Pace time Seconds value are incorrect");
            return this;
        }
    }
}
