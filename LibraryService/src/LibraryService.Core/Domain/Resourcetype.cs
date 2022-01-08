using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class ResourceType
    {
        public ResourceType()
        {
            Genericresources = new HashSet<GenericResource>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<GenericResource> Genericresources { get; set; }
    }
}
