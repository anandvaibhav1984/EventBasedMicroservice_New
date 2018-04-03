using System;
using System.Collections.Generic;

namespace Services.Catalog.Api.Infrastructure
{
    public partial class Album
    {
        public Album()
        {
            Cart = new HashSet<Cart>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }

        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Cart> Cart { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
       
    }
}
