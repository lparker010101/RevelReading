using RevelReading.Models;
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
        [HttpGet]
        public ActionResult Index() // The ActionResult is a return type.  It allows us to return a View() method.  That 
                                    // View() method will return a view that corresponds to the ResourceController.
                                    // When running the app, we can go to localhost:xxxxx/Reource/Index.  The path 
                                    // starts with the name of the controller (without the word controller), then the name
                                    // of the action, which is Index.
        {
            var model = new ResourceListItem[0]; // Initializing a new instance of the ResourceListItem as an IEnumerable with the [0] syntax.  
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }


    }
}