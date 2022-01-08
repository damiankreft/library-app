using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class GenericResourceAuthor
    {
        public int GenericResourceId { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual GenericResource GenericResource { get; set; }
    }
}
