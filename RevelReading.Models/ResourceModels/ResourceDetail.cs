using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models
{
    public class ResourceDetail
    {
        public int ResourceId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name ="School Grade Level")]
        public string SchoolGradeLevel { get; set;}

        [Display(Name ="Reading Category")]
        public string ReadingCategory { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset DateCreatedAndDownloaded { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedResource { get; set; }
    }
}
