using RevelReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevelReading.WebMVC.Controllers
{
    [Authorize]
    public class EducatorController : Controller
    {
        // GET: Educator
        public ActionResult Index()
        {
            var model = new EducatorListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EducatorCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}