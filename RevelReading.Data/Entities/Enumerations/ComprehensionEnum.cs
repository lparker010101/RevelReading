using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data.Entities.Enumerations
{
    public enum ComprehensionEnum
    {
        [Display(Name = "Main Idea and Details")]
        MainIdeaAndDetails = 1, 

        [Display(Name = "Sequence Events")]
        SequenceEvents,

        [Display(Name = "Recall Questions")]
        RecallQuestions,

        [Display(Name = "Making Inferences and Predictions")]
        MakingInferencesAndPredictions,

        [Display(Name = "Identifying Unfamiliar Vocabulary")]
        IdentifyingUnfamiliarVocabulary
    }
}
