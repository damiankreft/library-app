using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class Translator
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
    }
}
