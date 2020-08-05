using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Domain.Models
{
    public class InventorySearchResultsModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public bool IsOpen { get; set; }
        public int? InventoryConditionId { get; set; }
    }
}
