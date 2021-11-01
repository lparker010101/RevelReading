using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data
{
    [Table("Resource")]
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
        public DateTimeOffset DateCreatedAndDownloaded { get; set; } // DateTimeOffset is a value type, they can't be null.  It is good to 
                                                                     // to store dates with DateTimeOffset, this way it will account for time zones.

        public DateTimeOffset? ModifiedResource { get; set; } // Adding the ? null-conditional operator on the ModifiedResource. It allows a value type to be null.

        public bool IsDownloadable { get; set; }
        public string SchoolGradeLevel { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage ="The reading category must be 15 characters or less."), MinLength(5)]
        public string ReadingCategory { get; set; }

        [ForeignKey("Educator")]
        public int EducatorId { get; set; }
        public Educator Educator { get; set; }

        public DateTime AccessDate { get; set; }
        public int MyProperty { get; set; }
    }
}
