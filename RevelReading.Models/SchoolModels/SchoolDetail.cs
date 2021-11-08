using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models.SchoolModels
{
    public class SchoolDetail
    {
        public int SchoolId { get; set; }
        
        [Display(Name ="School Name")]
        public string SchoolName { get; set; }

        [Display(Name ="School Grade Levels")]
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

        public SchoolDetail() { }

        public SchoolDetail(int schoolId, string schoolName, string schoolGradeLevels, string lowestGradeLevel, string highestGradeLevel, string streetAddress, string city, string state, string zipCode)
        {
            this.SchoolId = schoolId;
            this.SchoolName = schoolName;
            this.SchoolGradeLevels = schoolGradeLevels;
            this.LowestGradeLevel = lowestGradeLevel;
            this.HighestGradeLevel = highestGradeLevel;
            this.StreetAddress = streetAddress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
        }
    }
}
