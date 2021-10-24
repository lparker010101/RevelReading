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

        [Required]
        public string ResourceName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="The description must be 100 characters or less.")]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset DateCreatedAndDownloaded { get; set; }

        public bool IsDownloadable { get; set; }
        public int SchoolGradeLevel { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage ="The reading category must be 15 characters or less."), MinLength(5)]
        public string ReadingCategory { get; set; }

        [ForeignKey("Educator")]
        public string EducatorId { get; set; }
        public Educator Educator { get; set; }

        public DateTime AccessDate { get; set; }
        public int MyProperty { get; set; }

    }
}
