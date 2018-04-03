using System;
using System.Collections.Generic;

namespace Services.Catalog.Api.Infrastructure
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Album Album { get; set; }
        public Order Order { get; set; }
    }
}
