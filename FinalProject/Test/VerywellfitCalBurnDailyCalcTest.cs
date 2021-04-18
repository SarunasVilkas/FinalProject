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
    public class VerywellfitCalBurnDailyCalcTest : BaseTest
    {
        [TestCase("male", "31", "173", "75", "light", "2312", TestName = "Male, Age: 31, Height: 173 cm, Weight: 75 kg Calories burned daily: 2312")]
        [TestCase("female", "24", "162", "50", "sedentary", "1478", TestName = "Female, Age: 24, Height: 162 cm, Weight: 50 kg Calories burned daily: 1478")]
        [TestCase("male", "50", "210", "120", "very", "3911", TestName = "Male, Age: 50, Height: 210 cm, Weight: 120 kg Calories burned daily: 3911")]
        [TestCase("male", "16", "185", "85", "moderate", "2993", TestName = "Male, Age: 16, Height: 185 cm, Weight: 85 kg Calories burned daily: 2993")]
        [TestCase("female", "65", "158", "48", "sedentary", "1178", TestName = "Female, Age: 65, Height: 158 cm, Weight: 48 kg Calories burned daily: 1178")]

        public static void CalcCalories(string gender, string age, string height, string weight, string activity, string expResult)
        {
            verywellfitCalBurnDailyCalcpg.NavigateToHome()
                .CloseCookiePopUp()
                .ChooseMetricUnits()
                .ChooseGender(gender)
                .EnterAge(age)
                .EnterHeight(height)
                .EnterWeight(weight)
                .ChooseActivity(activity)
                .Calculate()
                .ValidateResult(expResult)
                .StartOverPage();
        }
    }
}
