using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class Suppliers
    {
        public long Id { get; set; }
        public string Supplier { get; set; }
        public bool IsActive { get; set; }
    }
}
