﻿using Services.Catalog.Api.Exceptions;
using Services.Catalog.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Catalog.Api.Model
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }

        public Artist Artist { get; set; }
        public Genre Genre { get; set; }


        // Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
     //   public int MaxStockThreshold { get; set; }

        /// <summary>
        /// True if item is on reorder
        /// </summary>
      //  public bool OnReorder { get; set; }

        public Album() { }


        /// <summary>
        /// Decrements the quantity of a particular item in inventory and ensures the restockThreshold hasn't
        /// been breached. If so, a RestockRequest is generated in CheckThreshold. 
        /// 
        /// If there is sufficient stock of an item, then the integer returned at the end of this call should be the same as quantityDesired. 
        /// In the event that there is not sufficient stock available, the method will remove whatever stock is available and return that quantity to the client.
        /// In this case, it is the responsibility of the client to determine if the amount that is returned is the same as quantityDesired.
        /// It is invalid to pass in a negative number. 
        /// </summary>
        /// <param name="quantityDesired"></param>
        /// <returns>int: Returns the number actually removed from stock. </returns>
        /// 
        //public int RemoveStock(int quantityDesired)
        //{
        //    if (AvailableStock == 0)
        //    {
        //        throw new CatalogDomainException($"Empty stock, product item {Name} is sold out");
        //    }

        //    if (quantityDesired <= 0)
        //    {
        //        throw new CatalogDomainException($"Item units desired should be greater than cero");
        //    }

        //    int removed = Math.Min(quantityDesired, this.AvailableStock);

        //    this.AvailableStock -= removed;

        //    return removed;
        //}

        /// <summary>
        /// Increments the quantity of a particular item in inventory.
        /// <param name="quantity"></param>
        /// <returns>int: Returns the quantity that has been added to stock</returns>
        /// </summary>
        //public int AddStock(int quantity)
        //{
        //    int original = this.AvailableStock;

        //    // The quantity that the client is trying to add to stock is greater than what can be physically accommodated in the Warehouse
        //    if ((this.AvailableStock + quantity) > this.MaxStockThreshold)
        //    {
        //        // For now, this method only adds new units up maximum stock threshold. In an expanded version of this application, we
        //        //could include tracking for the remaining units and store information about overstock elsewhere. 
        //        this.AvailableStock += (this.MaxStockThreshold - this.AvailableStock);
        //    }
        //    else
        //    {
        //        this.AvailableStock += quantity;
        //    }

        //    this.OnReorder = false;

        //    return this.AvailableStock - original;
        //}
    }
}
