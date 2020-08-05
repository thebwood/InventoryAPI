using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class Orders
    {
        public long Id { get; set; }
        public long? OwnerId { get; set; }
        public int OrderTypesId { get; set; }
        public long? SupplierId { get; set; }
        public int InventoryConditionId { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
