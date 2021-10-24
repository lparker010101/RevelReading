using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data.Entities.Enumerations
{
    public enum VocabularyEnum
    {
        [Display(Name = "Word Connection Activities")]
        WordConnection = 1, 

        [Display(Name = "Significance Activities")]
        Significance, 

        [Display(Name = "Context Clues Activities")]
        ContextClues,

        [Display(Name = "Word Rich Environment Ideas")]
        WordRichEnvironment,

        [Display(Name = "Visual Representations")]
        VisualRepresentations
    }
}
