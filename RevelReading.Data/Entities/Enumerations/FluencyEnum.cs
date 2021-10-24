using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data.Entities.Enumerations
{
    public enum FluencyEnum
    {
        [Display(Name = "Ideas for Teaching About Accuracy")]
        AccuracyIdeas = 1, 

        [Display(Name = "Ideas for Teaching About Rate")]
        RateActivities,

        [Display(Name = "Ideas and Activities for Teaching Expression")]
        ExpressionActivities
    }
}
