using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class OrderTypes
    {
        public int Id { get; set; }
        public string OrderType { get; set; }
        public int? OrderRank { get; set; }
    }
}
