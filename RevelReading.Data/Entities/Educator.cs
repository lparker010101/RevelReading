using RevelReading.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data
{
    [Table("Educator")]
    public class Educator
    {
        public Guid OwnerId { get; set; }

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EducatorId { get; set; }

        public string UserPhotoImagePath { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public virtual School School { get; set; }

        //[ForeignKey("School"), Column(Order = 1)]
        //public int SchoolId { get; set; }
        //public School School { get; set; }

        public int SchoolGradeLevel { get; set; }

        public int ResourceCount { get; set; }


        //[ForeignKey("Address"), Column(Order = 2)]
        //public int AddressId { get; set; }
        //public Address Address { get; set; }

        public virtual ICollection<Resource> Resources { get; set; } // A virtual method is a declared class that allows overriding
                                                                     // by a method with the same derived class signature.  They
                                                                     // allow a program to call methods that don't necessarily even exist
                                                                     // at the moment the code is compiled.  
                                                                     // Storing resource virtually in the educator table.  Because we
                                                                     // are storing the resources for real in the resource table.  Don't 
                                                                     // want duplicate data in 2 tables.  
    }
}

//Model:
//Models represent objects or C# POCO's carrying data. POCO is a term that stands for
//Plain Old C# Object. You'll also hear POJO, which stands for Plain Old Java Object. Starting out,
//to give the definition some concrete bounds, a model represents the data that will be represented
//in the view and used by the controller to manage logic. Keep it that simple for now. It can have
//some business logic(validation type of stuff), but for the most part, these will look like simple
//C# classes with properties in the classes.

//View: 
//The View represents the visualization of the data that model contains. The view is often referred to
//as 'dumb' and simply considering what data will be shown.

//Controller: 
//The Controller acts on both the model and the view. It will take information from the model and pass
//it to the view, or it might return a specific view after some action has been taken. It controls the
//data flow into model object and updates the view whenever data changes. In general, it keeps the view
//and model separate.
//The Controller has all the CRUD operations.  It will manage views for Creating, Reading, Updating, and 
//Deleting information for the user.  
