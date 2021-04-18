using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Page;
using System.Threading;

namespace FinalProject.Test
{
    public class VerywellfitPaceCalcTest : BaseTest
    {
        [Test]
        public static void CheckPaceFor10kmIn1Hr()
        {
            verywellfitPaceCalcpg.NavigateToHome()
            .CloseCookiePopUp()
            .ChooseDistanceUnits("Kilometers")
            .ChooseDistance("10")
            .PickTimeH_m_s("1")
            .ChoosePaceUnits("Kilometer")
            .Submit()
            .VerifyResult("06", "00");
        }

        [Test]
        public static void CheckPaceFor20MilesIn1Hr50min()
        {
            verywellfitPaceCalcpg.NavigateToHome()
            .CloseCookiePopUp()
            .ChooseDistanceUnits("Miles")
            .ChooseDistance("20")
            .PickTimeH_m_s("1", "50")
            .ChoosePaceUnits("Mile")
            .Submit()
            .VerifyResult("05", "30");
        }
    }
}
