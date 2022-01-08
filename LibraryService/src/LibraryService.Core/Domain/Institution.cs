using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class Institution
    {
        public Institution()
        {
            Resourceinstances = new HashSet<ResourceInstance>();
        }

        public int Id { get; set; }
        public string InstitutionName { get; set; }

        public virtual ICollection<ResourceInstance> Resourceinstances { get; set; }
    }
}
