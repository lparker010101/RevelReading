using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models.SchoolModels
{
    public class SchoolEdit
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolGradeLevels { get; set; }
        public string LowestGradeLevel { get; set; }
        public string HighestGradeLevel { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
