using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class InventoryGame
    {
        public long Id { get; set; }
        public long InventoryId { get; set; }
        public long GamesGameFormatsId { get; set; }
        public bool OwnerId { get; set; }
        public bool IsNew { get; set; }
        public bool IsDigital { get; set; }
        public bool? PurchaseDate { get; set; }
    }
}
