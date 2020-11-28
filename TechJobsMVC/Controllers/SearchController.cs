﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchTerm, string searchType)
        {
            ViewBag.Columns = ListController.ColumnChoices;
            ViewBag.title = "Search";
            if (searchTerm == null)
            {
                ViewBag.jobs = Data.JobData.FindAll();
            } else
            {
                ViewBag.jobs = Data.JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            return View("Views/Search/Index.cshtml");

        }
    }
}
