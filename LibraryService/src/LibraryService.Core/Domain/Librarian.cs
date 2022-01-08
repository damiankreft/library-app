using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class Librarian
    {
        public Librarian()
        {
            Leases = new HashSet<Lease>();
        }

        public int AccountId { get; set; }
        public sbyte AccessLevel { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
    }
}
