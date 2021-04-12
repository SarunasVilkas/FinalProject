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
    class VerywellfitRecipeNutritionCalcTest : BaseTest
    {

        [Test]
        public static void CalculateNutrition3Ingredients2Servings()
        {
            verywellfitRecipeNutritionCalcpg.NavigateToHome()
                .CloseCookiePopUp()
                .AddTextToTextBox("3 medium carrots", "1 medium sweet potato", "1 tablespoon olive oil")
                .SelectFromServingDropDown("2")
                .GetAnlyzed()
                .VerifyResult("149");
        }

        [Test]
        public static void CalculateNutritionWithWrongIngredient()
        {
            verywellfitRecipeNutritionCalcpg.NavigateToHome()
                .CloseCookiePopUp()
                .AddTextToTextBox("3 medium morkos", "1 medium sweet bulves", "1 tablespoon alyvuogiu oil")
                .SelectFromServingDropDown("2")
                .GetAnlyzed()
                .VerifyResult("149");
        }


    }
}
