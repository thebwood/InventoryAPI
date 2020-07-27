using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class Inventory
    {
        public long Id { get; set; }
        public int OwnerId { get; set; }
        public bool IsSold { get; set; }
        public bool IsNew { get; set; }
        public bool IsOpen { get; set; }
        public bool? PurchaseDate { get; set; }
    }
}
