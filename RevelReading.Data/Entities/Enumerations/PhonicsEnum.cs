using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data.Entities.Enumerations
{
    public enum PhonicsEnum
    {
        [Display(Name = "Consonants and Short Vowel Sounds")]
        ConsonantsAndShortVowelSounds = 1, 

        [Display(Name = "Consonant Digraphs and Blends")]
        ConsonantDigraphsAndBlends,

        [Display(Name = "Long Vowel Final e")]
        LongVowelFinalE,

        [Display(Name = "Long Vowel Digraphs")]
        LongVowelDigraphs,

        [Display(Name = "Syllable Patterns")]
        SyllablePatterns,

        [Display(Name = "Affixes")]
        Affixes
    }
}
