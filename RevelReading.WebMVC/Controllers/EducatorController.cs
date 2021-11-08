﻿using Microsoft.AspNet.Identity;
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
        [HttpGet]
        public ActionResult Index()
        {
            var educatorUserId = Guid.Parse(User.Identity.GetUserId());
            var service = new EducatorService(educatorUserId);
            var educators = service.GetAllEducators();

            return View(educators);
        }

        [HttpGet]
        public ActionResult Create() // Right click to add a view after the EducatorCreate model is complete.
        {
            return View();  // Need to have a view and we need a model for the view.  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EducatorCreate model)  // Create an educator.
        {
            if (!ModelState.IsValid) return View(model);
            {
                var service = CreateEducatorService();

                if (service.CreateEducator(model))
                {
                    TempData["SaveResult"] = "The educator was successfully added."; //TempData removes information after it's accessed.
                    return RedirectToAction("Index");
                };
            };

            ModelState.AddModelError("", "Educator could not be added.  Please try again later.");
            return View(model);
        }

        public ActionResult Details(int educatorUserId)  
        {
            var svc = CreateEducatorService();
            var model = svc.GetEducatorById(educatorUserId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int EducatorUserId)  //An overloaded Edit ActionResult.  Overloading happens when you have
                                                      //two methods with the same name but different signatures(or arguments).
        {
            var service = CreateEducatorService();
            var detail = service.GetEducatorById(EducatorUserId);
            var model =
                new EducatorEdit
                {
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    EmailAddress = detail.EmailAddress
                };
            return View(model);
        }

        [HttpPut]
        public ActionResult Edit(int EducatorUserId, EducatorEdit model) 
        {
            if(!ModelState.IsValid) return View(model);

            if(model.EducatorId != EducatorUserId)
            {
                ModelState.AddModelError("", "Id Mismatch"); // Ask about this ??????????????
                return View(model);
            }

            var service = CreateEducatorService());

            if (service.UpdateEducator(model))
            {
                TempData["Save Result"] = "Your profile information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile information could not be updated.  Please try again later");
            return View(model);
        }

        [ActionName(name: "Delete")]
        public ActionResult Delete(int EducatorUserId)
        {
            var svc = CreateEducatorService();
            var model = svc.GetEducatorById(EducatorUserId);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int EducatorUserId)
        {
            var service = CreateEducatorService();
            service.DeleteEducator(EducatorUserId);

            TempData["SaveResult"] = "Your profile information was successsfully deleted.";

            return RedirectToAction("Index");
        }

        private EducatorService CreateEducatorService()
        {
            var educatorUserId = Guid.Parse(User.Identity.GetUserId());
            var service = new EducatorService(educatorUserId);
            return service;
        }
    }
}
        // The Create(EducatorCreate model) method makes sure the model is valid, 
        // grabs the current userId, calls on EducatorCreate, and returns
        // the user back to the index view.
        // Note: Create views for the models in the controller by right clicking
        // on the methods.