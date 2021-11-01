using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models
{
    public class ResourceListItem
    {
        public int ResourceId { get; set; }
        
        [Display(Name = "Title")]
        public string ResourceName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Resource Created")]
        public DateTimeOffset DateCreatedAndDownloaded { get; set; }

        [Display(Name = "Resource Modified")]
        public DateTimeOffset? ModifiedResource { get; set; }

        [Display(Name = "School Grade Levels")]
        public string SchoolGradeLevel { get; set; }

        [Display(Name = "Reading Category")]
        public string ReadingCategory { get; set; }

        public byte[] ResourceImage { get; set; }
        public string Content { get; set; }


        public ResourceListItem() { }

        public ResourceListItem(int resourceId, string resourceName, string description, DateTimeOffset dateCreatedAndDownloaded, DateTimeOffset? modifiedResource, string schoolGradeLevel, string readingCategory, byte[] resourceImage, string content)
        {
            this.ResourceId = resourceId;
            this.ResourceName = resourceName;
            this.Description = description;
            this.DateCreatedAndDownloaded = dateCreatedAndDownloaded;
            this.ModifiedResource = modifiedResource;
            this.SchoolGradeLevel = schoolGradeLevel;
            this.ReadingCategory = readingCategory;
            this.ResourceImage = resourceImage;
            this.Content = content;
        }
    }
}
