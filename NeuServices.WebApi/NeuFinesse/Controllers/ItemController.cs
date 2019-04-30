using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeuFinesse.Data.Repository;

namespace NeuFinesse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IDataRepository<NeuFinesse.Data.Model.Item> _dataRepository;

        public ItemController(IDataRepository<NeuFinesse.Data.Model.Item> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<NeuFinesse.Data.Model.Item> item = _dataRepository.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}", Name = "Item")]
        public IActionResult Get(long id)
        {
            NeuFinesse.Data.Model.Item item = _dataRepository.Get(id);

            if (item == null)
            {
                return NotFound("The item record couldn't be found.");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NeuFinesse.Data.Model.Item item)
        {
            if (item == null)
            {
                return BadRequest("Item is null.");
            }

            _dataRepository.Add(item);
            return Ok("Item added successfully");
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = item.ItemId },
            //      item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] NeuFinesse.Data.Model.Item item)
        {
            if (item == null)
            {
                return BadRequest("Item is null.");
            }

            NeuFinesse.Data.Model.Item itemDetailToUpdate = _dataRepository.Get(id);
            if (itemDetailToUpdate == null)
            {
                return NotFound("The item record couldn't be found.");
            }

            _dataRepository.Update(itemDetailToUpdate, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            NeuFinesse.Data.Model.Item item = _dataRepository.Get(id);
            if (item == null)
            {
                return NotFound("The item record couldn't be found.");
            }

            _dataRepository.Delete(item);
            return NoContent();
        }
    }
}