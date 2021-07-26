using System;
using System.Collections.Generic;

#nullable disable

namespace MonitorAPI.Models
{
    public partial class Monitor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorPersonId { get; set; }
    }
}
