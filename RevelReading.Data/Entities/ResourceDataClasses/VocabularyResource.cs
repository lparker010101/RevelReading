using RevelReading.Data.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelReading.Data.Entities.ResourceDataClasses
{
    public class VocabularyResource : Resource
    {
        public VocabularyEnum Vocabulary { get; set; }
    }
}
