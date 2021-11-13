using Microsoft.AspNet.Identity;
using RevelReading.Models.SchoolModels;
using RevelReading.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevelReading.WebMVC.Controllers
{
    [Authorize] //C# Attribute: This annotation makes it so that the views are accessible only to logged in users.
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index() //The Index() method displays all the schools for the current user.  
        {
            //var model = new SchoolListItem[0];  //Initializing a new instance of the SchoolListItem as an IEnumberable with the [0] syntax.
            //this safifies some requirements for our Index View.  
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolService(userId);
            var schools = service.GetSchools();
            
            return View(schools);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
                var service = CreateSchoolService();

                if (service.CreateSchool(model))
                {
                    TempData["SaveResult"] = "Your school was successfully added."; //TempData removes information after it's accessed.
                    return RedirectToAction("Index");
                }

            ModelState.AddModelError("", "School could not be added.  Please try again later.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSchoolService();
            var detail = service.GetSchoolById(id);
            var model =
                new SchoolEdit
                {
                    SchoolId = detail.SchoolId,
                    SchoolName = detail.SchoolName,
                    SchoolGradeLevels = detail.SchoolGradeLevels,
                    LowestGradeLevel = detail.LowestGradeLevel,
                    HighestGradeLevel = detail.HighestGradeLevel,
                    StreetAddress = detail.StreetAddress,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode
                };

                    return View(model);
                }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SchoolEdit model)
        {
            if(!ModelState.IsValid) return View(model);

            if(model.SchoolId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSchoolService();

            if (service.UpdateSchool(model))
            {
                TempData["SaveResult"] = "Your school information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your school information could not be updated.  Try again later.");
            return View(model);
        }

        [ActionName(name: "Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchoolById(int id)
        {
            var service = CreateSchoolService();

            service.DeleteSchool(id);

            TempData["SaveResult"] = "Your school information was successfully deleted.";

            return RedirectToAction("Index");
        }


        private SchoolService CreateSchoolService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolService(userId);
            return service;
        }
    }
}

//1. The first word in the controller name will be the first part of our path. Keep that in mind.
//Our path will be localhost:xxxxx/Note.

//2. The ActionResult is a return type. You can read more in the docs later, but for now, realize
//that it allows us to return a View() method.That View() method will return a view that corresponds
//to the NoteController. More on that in a minute.

//3. When running the app, we can go to localhost:xxxxx / Note / Index.Notice the path starts with
//the name of the controller (without the word controller), then the name of the action, which is Index.

//4. When we go to that path it will return a view for that path.