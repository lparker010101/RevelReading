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
        [Key]
        public int SchoolId { get; set; }

        [Required]
        public string SchoolName { get; set; }

        public byte[] SchoolPhoto { get; set; }
        public string SchoolGradeLevels { get; set; }
        public string LowestGradeLevel { get; set; }
        public int HighestGradeLevel { get; set; }
        public List<Educator> Educators { get; set; } = new List<Educator>();
        
        [ForeignKey("District")]
        public int DistrictId { get; set; }
        public District District { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
