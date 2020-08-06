using Inventory.API.Data;
using Inventory.API.Domain.Models;
using System.Collections.Generic;

namespace Inventory.API.Domain.Services.Inventory
{
    public interface IInventoryRepository
    {
        List<InventorySearchResultsModel> SearchInventory(InventorySearchModel searchRequest);
        InventoryItems GetInventory(long inventoryId);
        void SaveDetail(InventoryItems existingPerson);
        List<ItemTypes> GetItemTypes();
    }
}