using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models
{
    public class ResourceCreate

    {
        public int EducatorId { get; set; }
        //public int ResourceId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }

        [MaxLength(10)]
        public string SchoolGradeLevel { get; set; }

        public string ReadingCategory { get; set; }

       // public DateTimeOffset DateCreatedAndDownloaded { get; set; }
    }
}
