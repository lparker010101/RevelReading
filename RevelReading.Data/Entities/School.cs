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
    [Table("School")]
    public class School
    {
        public Guid OwnerId { get; set; }

        [Key]
        public int SchoolId { get; set; }

        public int EducatorId { get; set; }

        [Required]
        public string SchoolName { get; set; }

        public string SchoolImagePath { get; set; }
        public string SchoolGradeLevels { get; set; }
        public string LowestGradeLevel { get; set; }
        public string HighestGradeLevel { get; set; }
        public List<Educator> Educators { get; set; } = new List<Educator>();
        
        //[ForeignKey("District")]
        //public int DistrictId { get; set; }
        //public District District { get; set; }

        public virtual Address Address { get; set; }
    }
}
