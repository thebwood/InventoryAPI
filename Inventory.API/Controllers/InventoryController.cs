using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.API.Domain.Models;
using Inventory.API.Domain.Services.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IInventoryService _service;
        private readonly IMapper _mapper;
        public InventoryController(IInventoryService service, IMapper mapper)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(List<InventorySearchResultsModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<InventorySearchResultsModel>), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(List<InventorySearchResultsModel>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<InventorySearchResultsModel>), (int)HttpStatusCode.InternalServerError)]
        public IActionResult SearchInventory([FromBody] InventorySearchModel searchRequest)
        {
            try
            {
                var searchResults = _service.SearchInventory(searchRequest);

                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }

        }

        [HttpGet("{inventoryId}")]
        [ProducesResponseType(typeof(InventoryItemsModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InventoryItemsModel), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(InventoryItemsModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetInventory(long inventoryId)
        {
            try
            {
                var data = _service.GetInventory(inventoryId);

                var retVal = _mapper.Map<InventoryItemsModel>(data);

                if (retVal != null)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateInventory([FromBody] InventoryItemsModel inventory)
        {
            var errorList = new List<string>();

            try
            {

                errorList = _service.SaveDetail(inventory);
                if (errorList.Count > 0)
                {
                    return BadRequest(errorList);
                }
            }
            catch (Exception ex)
            {
                errorList = new List<string>() { "Error in saving" };
                return BadRequest(errorList);
            }

            return Ok(errorList);
        }



        [HttpGet("itemtypes")]
        [ProducesResponseType(typeof(ItemTypesModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ItemTypesModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ItemTypesModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetItemTypes()
        {
            try
            {
                var data = _service.GetItemTypes();

                var retVal = _mapper.Map<IEnumerable<ItemTypesModel>>(data);

                if (retVal.Count() > 0)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

    }
}
