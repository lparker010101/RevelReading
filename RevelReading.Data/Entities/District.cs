using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }

        [Required]
        public string DistrictName { get; set; }
    }
}
