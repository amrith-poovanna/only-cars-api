using System;
using System.Collections.Generic;

namespace Auto.Entities
{
    public partial class Gallery
    {
        public Guid GalleryId { get; set; }
        public Guid? CarId { get; set; }
        public string? ImageType { get; set; }
        public string? Image { get; set; }

        public virtual Car? Car { get; set; }
    }
}
