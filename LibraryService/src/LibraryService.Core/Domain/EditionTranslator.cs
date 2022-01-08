using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class EditionTranslator
    {
        public int EditionId { get; set; }
        public int TranslatorId { get; set; }

        public virtual Edition Edition { get; set; }
        public virtual Translator Translator { get; set; }
    }
}
