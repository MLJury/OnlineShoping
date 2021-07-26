using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShoping.Models
{
    public partial class AllInOne
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorPersonId { get; set; }
    }
}
