using RevelReading.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models.SchoolModels
{
    public class SchoolListItem
    {
        public int SchoolId { get; set; }
        
        [Display(Name ="School Name")]
        public string SchoolName { get; set; }

        [Display(Name ="School Grade Levels")]
        public string SchoolGradeLevels { get; set; }

        [Display(Name = "Lowest Grade Level")]
        public string LowestGradeLevel { get; set; }

        [Display(Name ="Highest Grade Level")]
        public string HighestGradeLevel { get; set; }

        public List<Educator> Educators { get; set; } = new List<Educator>();
    }
}
