using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class EditionHold
    {
        public int Id { get; set; }
        public int EditionId { get; set; }
        public DateTime ResourceReservationDate { get; set; }

        public virtual Edition Edition { get; set; }
    }
}
