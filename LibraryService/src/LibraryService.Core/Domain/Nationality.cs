using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class Nationality
    {
        public Nationality()
        {
            AuthorNationalities = new HashSet<AuthorNationality>();
        }

        public int Id { get; set; }
        public string Country { get; set; }

        public virtual ICollection<AuthorNationality> AuthorNationalities { get; set; }
    }
}
