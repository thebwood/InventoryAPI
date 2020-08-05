using AutoMapper;
using Inventory.API.Domain.Models;
using Inventory.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Domain.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryItemsModel, InventoryItems>();
            CreateMap<InventoryItems, InventoryItemsModel>();
        }
    }
}
