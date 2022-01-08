using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class Author
    {
        public Author()
        {
            AuthorNationalities = new HashSet<AuthorNationality>();
            GenericresourceAuthors = new HashSet<GenericResourceAuthor>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }

        public virtual ICollection<AuthorNationality> AuthorNationalities { get; set; }
        public virtual ICollection<GenericResourceAuthor> GenericresourceAuthors { get; set; }
    }
}
