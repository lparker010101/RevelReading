using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models.SchoolModels
{
    public class SchoolCreate
    {
        [Display(Name ="School Name")]
        public string SchoolName { get; set; }

        [Display(Name ="Grade Levels")]
        public string SchoolGradeLevels { get; set; }

        [Display(Name ="Lowest Grade Level")]
        public string LowestGradeLevel { get; set; }

        [Display(Name ="Highest Grade Level")]
        public string HighestGradeLevel { get; set; }

        [Display(Name ="Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
