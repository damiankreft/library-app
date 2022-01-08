using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class GenericResource
    {
        public GenericResource()
        {
            Editions = new HashSet<Edition>();
            GenericresourceAuthors = new HashSet<GenericResourceAuthor>();
        }

        public int Id { get; set; }
        public int ResourceType { get; set; }
        public string GenericResourceName { get; set; }

        public virtual ResourceType ResourceTypeNavigation { get; set; }
        public virtual ICollection<Edition> Editions { get; set; }
        public virtual ICollection<GenericResourceAuthor> GenericresourceAuthors { get; set; }
    }
}
