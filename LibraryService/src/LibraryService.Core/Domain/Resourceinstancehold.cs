using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class ResourceInstanceHold
    {
        public string ResourceInstanceId { get; set; }
        public DateTime ResourceReservationDate { get; set; }

        public virtual ResourceInstance ResourceInstance { get; set; }
    }
}
