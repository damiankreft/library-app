using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class Edition
    {
        public Edition()
        {
            Editionholds = new HashSet<EditionHold>();
            Resourceinstances = new HashSet<ResourceInstance>();
        }

        public int Id { get; set; }
        public int GenericResourceId { get; set; }
        public decimal? Recompense { get; set; }
        public bool? Leaseable { get; set; }
        public string Isbn13 { get; set; }
        public short? DatePublished { get; set; }

        public virtual GenericResource GenericResource { get; set; }
        public virtual ICollection<EditionHold> Editionholds { get; set; }
        public virtual ICollection<ResourceInstance> Resourceinstances { get; set; }
    }
}
