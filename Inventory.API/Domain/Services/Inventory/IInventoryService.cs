using Inventory.API.Data;
using Inventory.API.Domain.Models;
using System.Collections.Generic;

namespace Inventory.API.Domain.Services.Inventory
{
    public interface IInventoryService
    {
        List<InventorySearchResultsModel> SearchInventory(InventorySearchModel searchRequest);
        InventoryItems GetInventory(long inventoryId);
        List<string> SaveDetail(InventoryItemsModel inventory);
        List<ItemTypes> GetItemTypes();
    }
}