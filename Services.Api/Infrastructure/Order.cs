using System;
using System.Collections.Generic;

namespace Services.Catalog.Api.Infrastructure
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
