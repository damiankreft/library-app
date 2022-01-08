using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class ResourceInstance
    {
        public ResourceInstance()
        {
            Leases = new HashSet<Lease>();
        }

        public string ResourceCode { get; set; }
        public int EditionId { get; set; }
        public int InstitutionId { get; set; }

        public virtual Edition Edition { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
    }
}
