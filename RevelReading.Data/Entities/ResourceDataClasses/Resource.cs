using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreatedAndDownloaded { get; set; }
        public bool isDownloadable { get; set; }
        public int SchoolGradeLevel { get; set; }
        public string ReadingCategory { get; set; }

        [ForeignKey("Educator")]
        public string EducatorId { get; set; }
        public Educator Educator { get; set; }

        public DateTime AccessDate { get; set; }
        public int MyProperty { get; set; }

    }
}
