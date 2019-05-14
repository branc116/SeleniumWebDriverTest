using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeleniumWebDriverTest.Models;

namespace SeleniumWebDriverTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<bool> ZseCheckIsTop10(string dionicaName)
        {
            using (var driver = new OpenQA.Selenium.Firefox.FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://www.zse.hr/");
                var top10Table = driver.FindElement(OpenQA.Selenium.By.XPath(@"//*[@id=""mainContainer""]/table/tbody/tr[1]/td/table/tbody/tr/td[2]/div[1]/div[1]/table"));
                var top10DionicarskihDrustva = top10Table.FindElements(OpenQA.Selenium.By.TagName("strong"));
                return top10DionicarskihDrustva.Where(dd => dd.Text == dionicaName).Any();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
