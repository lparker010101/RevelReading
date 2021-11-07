using RevelReading.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models
{
    public class EducatorDetail
    {
        public int EducatorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public int SchoolGradeLevel { get; set; }

        [Display(Name= "Resources")]
        public int ResourceCount { get; set; }

        public List<ResourceListItem> Resources { get; set; }
        
        public EducatorDetail() { }

        public EducatorDetail(int educatorId, string firstName, string lastName, string emailAddress, int schoolId, School school, int schoolGradeLevel, int resourceCount, List<ResourceListItem> resources)
        {
            this.EducatorId = educatorId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.SchoolId = schoolId;
            this.School = school;
            this.SchoolGradeLevel = schoolGradeLevel;
            this.ResourceCount = resourceCount;
            this.Resources = resources;
        }
    }
}
