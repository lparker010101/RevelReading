using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Models
{
    public class EducatorListItem
    {
        public int EducatorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }


        public EducatorListItem() { }

        public EducatorListItem(int educatorId, string firstName, string lastName, string emailAddress)
        {
            EducatorId = educatorId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }
    }
}
