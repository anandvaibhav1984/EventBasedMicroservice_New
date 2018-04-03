using System;
using System.Collections.Generic;

namespace Services.Catalog.Api.Infrastructure
{
    public partial class Cart
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public Album Album { get; set; }
    }
}
