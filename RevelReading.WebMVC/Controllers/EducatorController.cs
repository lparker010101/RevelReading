using RevelReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevelReading.WebMVC.Controllers
{
    public class EducatorController : Controller
    {
        // GET: Educator
        public ActionResult Index()
        {
            var model = new EducatorListItem[0];
            return View(model);
        }
    }
}