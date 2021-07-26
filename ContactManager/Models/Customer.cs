using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShoping.Models
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorPersonId { get; set; }
    }
}
