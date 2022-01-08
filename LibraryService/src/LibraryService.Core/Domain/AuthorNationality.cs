using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class AuthorNationality
    {
        public int AuthorId { get; set; }
        public int NationalityId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Nationality Nationality { get; set; }
    }
}
