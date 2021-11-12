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
        [Required]
        public int SchoolId { get; set; }

        [Key]
        public int EducatorId { get; set; }

        [Required]
        [Display(Name ="School Name")]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.  Try again.")]
        [MaxLength(45, ErrorMessage ="There are too many characters in this field.  Try again.")]
        public string SchoolName { get; set; }

        [Display(Name ="Grade Levels")]
        public string SchoolGradeLevels { get; set; }

        [Display(Name ="Lowest Grade Level")]
        public string LowestGradeLevel { get; set; }

        [Display(Name ="Highest Grade Level")]
        public string HighestGradeLevel { get; set; }

        [Required]
        [Display(Name ="Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
