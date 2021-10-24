using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data
{
    public class School : District
    {
        [Key]
        public int SchoolId { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string SchoolAddress { get; set; }

        [Required]
        public string SchoolCity { get; set; }

        [Required]
        public string SchoolZipcode { get; set; }
        public int SchoolGradeLevels { get; set; }
        public int LowestGradeLevel { get; set; }
        public int HighestGradeLevel { get; set; }
        public List<Educator> Educators { get; set; } = new List<Educator>();
    }
}
