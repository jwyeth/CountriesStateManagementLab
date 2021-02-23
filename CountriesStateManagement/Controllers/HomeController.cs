using CountriesStateManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesStateManagement.Controllers
{

    public class HomeController : Controller
    {
        public List<Country> Countries { get; set; }
        public HomeController()
        {
            Countries = new List<Country>();
            List<string> langs = new List<string>();
            langs.Add("English");
            langs.Add("French");
            List<string> colors = new List<string>();
            colors.Add("Red");
            colors.Add("Black");
            Country c = new Country("Stankonia", langs, "Valvete amici!", colors, "Dopest country on Earth");

            List<string> langs2 = new List<string>();
            langs2.Add("German");
            langs2.Add("French");
            langs2.Add("English");
            List<string> colors2 = new List<string>();
            colors2.Add("Blue");
            colors2.Add("Gold");
            Country c2 = new Country("France", langs2, "Bonjur!", colors2, "They do French stuff here");

            Countries.Add(c2);
            Countries.Add(c);
        }


        public IActionResult Index()
        {
            return View(Countries);
        }

        // This action's job is to store the country name
        [HttpPost]
        public IActionResult Index(string countryName)
        {
            TempData["countryName"] = countryName;
            return View(Countries);
        }

        //Details needs to instead pull our country from TempData
        //Step 1: Store country in tempdata
        //Step 2: Search up the country from our list
        public IActionResult Details()
        {
            string countryName;
            Country selected = null;

            try
            {
                countryName = TempData.Peek("countryName").ToString();

            }
            catch (NullReferenceException)
            {
                countryName = null;
            }
            if (countryName != null) {
                for (int i = 0; i < Countries.Count; i++)
                {
                    Country c = Countries[i];
                    if (c.Name == countryName)
                    {
                        selected = c;
                        TempData["currentCountry"] = c.Name;
                    }
                }
            }
            return View(selected);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
