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
    public class SellerDetailController : ControllerBase
    {
        private readonly IUserRepository<NeuFinesse.Data.Model.SellerDetail> _dataRepository;

        public SellerDetailController(IUserRepository<NeuFinesse.Data.Model.SellerDetail> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<NeuFinesse.Data.Model.SellerDetail> sellerDetails = _dataRepository.GetAll();
            return Ok(sellerDetails);
        }

        [HttpGet("{id}", Name = "SellerDetail")]
        public IActionResult Get(string id)
        {
            NeuFinesse.Data.Model.SellerDetail sellerDetail = _dataRepository.Get(id);

            if (sellerDetail == null)
            {
                return Ok(0);
            }

            return Ok(sellerDetail);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NeuFinesse.Data.Model.SellerDetail sellerDetail)
        {
            if (sellerDetail == null)
            {
                return BadRequest("User is null.");
            }

            _dataRepository.Add(sellerDetail);
            return Ok("Seller Details posted successfully");
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = sellerDetail.UserId },
            //      sellerDetail);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] NeuFinesse.Data.Model.SellerDetail sellerDetail)
        {
            if (sellerDetail == null)
            {
                return BadRequest("User is null.");
            }

            NeuFinesse.Data.Model.SellerDetail sellerDetailToUpdate = _dataRepository.Get(id);
            if (sellerDetailToUpdate == null)
            {
                return NotFound("The user record couldn't be found.");
            }

            _dataRepository.Update(sellerDetailToUpdate, sellerDetail);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            NeuFinesse.Data.Model.SellerDetail itemDetail = _dataRepository.Get(id);
            if (itemDetail == null)
            {
                return NotFound("The user record couldn't be found.");
            }

            _dataRepository.Delete(itemDetail);
            return NoContent();
        }
    }
}