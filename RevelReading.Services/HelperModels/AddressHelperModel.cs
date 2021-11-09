using RevelReading.Data.Entities;
using RevelReading.Models.SchoolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Services.HelperModels
{
    public class AddressHelperModel // A helper is a reuseable component that includes code and markup
                                     // to perform a task that might be tedious or complex.
    {
        public Address CreateAddress(SchoolCreate model)
        {
            var address = new Address();

            address.StreetAddress = model.StreetAddress;
            address.City = model.City;
            address.State = model.State;
            address.Zipcode = model.ZipCode;

            return address;
        }
    }
}
