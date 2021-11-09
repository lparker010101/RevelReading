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
    [Authorize] // This annotation makes it so that the views are accessible only to logged in users.
    public class ResourceController : Controller // The first word in the controller name will be the first part of our path.
                                                 // Our path will be localhost:xxxxx/Resource
    {
        // GET: Resource
        public ActionResult Index() // The ActionResult is a return type.  It allows us to return a View() method.  That 
                                    // View() method will return a view that corresponds to the ResourceController.
                                    // When running the app, we can go to localhost:xxxxx/Reource/Index.  The path 
                                    // starts with the name of the controller (without the word controller), then the name
                                    // of the action, which is Index.  The Index() method displays all the resources for the current user.
                                    // It calls upon the methods and services.
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ResourceService(userId);
            var model = service.GetResources();
            //var model = new ResourceListItem[0]; Initializing a new instance of the ResourceListItem as an IEnumerable with the [0] syntax.  
            return View(model); // When we go to that path, it will return a view for that path.
        }

        // GET
        [HttpGet]
        public ActionResult Create() // Right click to add a view after the ResourceCreate model is complete.
        {
            return View(); // Need to have a view and we need a model for the view.
        }

        [HttpPost] // Here we write a post method that will eventually push the data inputted in the view through our service and into the database.  
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResourceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
                var service = CreateResourceService();

                if (service.CreateResource(model))
                {
                    TempData["SaveResult"] = "Your resource was created."; // TempDaa removes information after it's accessed.
                    return RedirectToAction("Index");
                };
                // The Create(ResourceCreate model) method makes sure the model is valid, grabs the current
            };
            ModelState.AddModelError("", "Resource could not be created.");     // userId, calls on CreateResource, and returns the user back to the index view.
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateResourceService();
            var model = svc.GetResourceById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateResourceService();
            var detail = service.GetResourceById(id);
            var model =
                new ResourceEdit
                {
                    ResourceId = detail.ResourceId,
                    Title = detail.Title,
                    Content = detail.Content,
                    SchoolGradeLevel = detail.SchoolGradeLevel,
                    ReadingCategory = detail.ReadingCategory
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResourceEdit model)
        {
            if(!ModelState.IsValid) return View(model);

            if(model.ResourceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateResourceService();

            if (service.UpdateResource(model))
            {
                TempData["SaveResult"] = "Your resource was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your resource could not be updated.  Try again later.");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateResourceService();
            svc.DeleteResource(id);

            TempData["SaveResult"] = "Your resource was successfully deleted.";

            return RedirectToAction("Index");
        }

        private ResourceService CreateResourceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ResourceService(userId);
            return service;
        }
    }
}