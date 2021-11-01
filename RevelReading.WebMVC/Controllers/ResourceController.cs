using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevelReading.WebMVC.Controllers
{
    public class ResourceController : Controller // The first word in the controller name will be the first part of our path.
                                                 // Our path will be localhost:xxxxx/Resource
    {
        // GET: Resource
        public ActionResult Index() // The ActionResult is a return type.  It allows us to return a View() method.  That 
                                    // View() method will return a view that corresponds to the ResourceController.
                                    // When running the app, we can go to localhost:xxxxx/Reource/Index.  The path 
                                    // starts with the name of the controller (without the word controller), then the name
                                    // of the action, which is Index.
        {
            return View(); // When we go to that path, it will return a view for that path.
        }
    }
}