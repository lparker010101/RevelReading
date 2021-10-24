using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data.Entities.Enumerations
{
    public enum PhonemicAwareness
    {
        [Display(Name = "Rhyming Visuals")]
        RhymingVisuals = 1, 

        [Display(Name = "Rhyming Think Sheets")]
        RhymingThinkSheets, 

        [Display(Name = "Oral Blending Lessons and Activities")]
        OralBlendingActivities, 

        [Display(Name = "Oral Substitution Lessons and Activities")]
        OralSubstitution, 

        [Display(Name = "Oral Deletion Lessons and Activities")]
        OralDeletion
    }
}
