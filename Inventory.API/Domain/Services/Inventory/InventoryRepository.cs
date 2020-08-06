using Inventory.API.Data;
using Inventory.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Domain.Services.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        private InventoryContext _context;

        public InventoryRepository(InventoryContext context) => _context = context;


        public InventoryItems GetInventory(long inventoryId) => _context.InventoryItems.Where(x => x.Id == inventoryId).SingleOrDefault();
        
        public void SaveDetail(InventoryItems inventory)
        {
            if (inventory.Id > 0)
                _context.InventoryItems.Update(inventory);
            else
                _context.InventoryItems.Add(inventory);
            _context.SaveChanges();
        }



        public List<InventorySearchResultsModel> SearchInventory(InventorySearchModel searchRequest)
        {
            var results =
                    (from i in _context.InventoryItems
                     join it in _context.ItemTypes on i.ItemTypeId equals it.Id into iit
                     from it in iit.DefaultIfEmpty()
                     where ((string.IsNullOrWhiteSpace(searchRequest.Description) || i.Description.Contains(searchRequest.Description)) &&
                     (searchRequest.ItemTypeId == null || i.ItemTypeId == searchRequest.ItemTypeId) &&
                     (searchRequest.Id == null || i.Id == searchRequest.Id)
                     )
                     select new InventorySearchResultsModel
                     {
                         Id = i.Id,
                         Description = i.Description,
                         ItemType = it.ItemType,
                     })
                    .OrderByDescending(a => a.Id)
                    .Take(1000)
                    .ToList();

            return results;
        }

        public List<ItemTypes> GetItemTypes() => _context.ItemTypes.ToList();
    }
}
