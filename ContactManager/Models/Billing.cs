using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShoping.Models
{
    public partial class Billing
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorPersonId { get; set; }
    }
}
