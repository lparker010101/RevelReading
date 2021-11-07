using Microsoft.AspNet.Identity;
using RevelReading.Models;
using RevelReading.Services;
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
            var educatorUserId = Guid.Parse(User.Identity.GetUserId());
            var service = new EducatorService(educatorUserId);
            var educators = service.GetAllEducators();

            return View(educators);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EducatorCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
                var service = CreateEducatorService();

                if (service.CreateEducator(model))
                {
                    TempData["SaveResult"] = "The educator was created."; //TempData removes information after it's accessed.
                    return RedirectToAction("Index");
                };

                ModelState.AddModelError("", "Educator could not be created.");
                return View(model);
            }



            return RedirectToAction("Index");  // The Create(EducatorCreate model) method makes sure the model is valid, 
                                               // grabs the current userId, calls on EducatorCreate, and returns
                                               // the user back to the index view.
        }

        private EducatorService CreateEducatorService()
        {
            var educatorUserId = Guid.Parse(User.Identity.GetUserId());
            var service = new EducatorService(educatorUserId);
            return service;
        }
    }
}