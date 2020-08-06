using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Domain.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public InventoryService() { }
        public InventoryService(IInventoryRepository repo, IMapper mapper)
        {
            _inventoryRepository = repo;
            _mapper = mapper;
        }


        public List<InventorySearchResultsModel> SearchInventory(InventorySearchModel searchRequest) => _inventoryRepository.SearchInventory(searchRequest);
        public InventoryItems GetInventory(long inventoryId) => _inventoryRepository.GetInventory(inventoryId);
        public List<string> SaveDetail(InventoryItemsModel inventory)
        {
            var errors = ValidateInventory(inventory);
            if (errors.Count == 0)
            {
                var existingPerson = new InventoryItems();
                if (inventory.Id > 0)
                    existingPerson = _inventoryRepository.GetInventory(inventory.Id);

                _mapper.Map<InventoryItemsModel, InventoryItems>(inventory, existingPerson);
                _inventoryRepository.SaveDetail(existingPerson);
            }

            return errors;
        }

        private List<string> ValidateInventory(InventoryItemsModel inventory)
        {
            var errors = new List<string>();

            if (String.IsNullOrWhiteSpace(inventory.Description))
            {
                errors.Add("Description is required");
            }
            if (inventory.ItemTypeId <= 0)
            {
                errors.Add("Item Type is required");
            }


            return errors;
        }

        public List<ItemTypes> GetItemTypes() => _inventoryRepository.GetItemTypes();

    }
}
