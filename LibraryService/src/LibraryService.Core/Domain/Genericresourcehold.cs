using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class GenericResourceHold
    {
        public int GenericResourceId { get; set; }
        public DateTime ResourceReservationDate { get; set; }

        public virtual GenericResource GenericResource { get; set; }
    }
}
