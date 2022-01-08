using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class Lease
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int LibrarianId { get; set; }
        public string ResourceInstanceId { get; set; }
        public DateTime LeaseStart { get; set; }
        public DateTime? LeaseEnd { get; set; }
        public string LeaseDuration { get; set; }

        public virtual Account Account { get; set; }
        public virtual Librarian Librarian { get; set; }
        public virtual ResourceInstance ResourceInstance { get; set; }
    }
}
