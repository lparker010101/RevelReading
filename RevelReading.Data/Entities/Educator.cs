using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data
{
    public class Educator : District
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EducatorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [ForeignKey("School"), Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolId { get; set; }

        [Required]
        public School School { get; set; }

        public int SchoolGradeLevel { get; set; }
        public virtual ICollection<Resource> Resources { get; set; } // A virtual method is a declared class that allows overriding
                                                                     // by a method with the same derived class signature.  They
                                                                     // allow a program to call methods that don't necessarily even exist
                                                                     // at the moment the code is compiled.
    }
}
