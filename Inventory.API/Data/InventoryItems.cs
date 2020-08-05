using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class InventoryItems
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int ItemTypeId { get; set; }
    }
}
