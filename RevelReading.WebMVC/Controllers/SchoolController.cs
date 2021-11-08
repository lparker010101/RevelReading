using RevelReading.Models.SchoolModels;
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
        public ActionResult Index()
        {
            var model = new SchoolListItem[0];  //Initializing a new instance of the SchoolListItem as an IEnumberable with the [0] syntax.
                                                //this safifies some requirements for our Index View.  
            return View(model);
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
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