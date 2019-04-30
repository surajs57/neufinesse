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
    public class CartController : ControllerBase
    {
        private readonly IUserRepository<NeuFinesse.Data.Model.Cart> _dataRepository;

        public CartController(IUserRepository<NeuFinesse.Data.Model.Cart> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<NeuFinesse.Data.Model.Cart> carts = _dataRepository.GetAll();
            return Ok(carts);
        }

        [HttpGet("{id}", Name = "Cart")]
        public IActionResult Get(string id)
        {
            IEnumerable<NeuFinesse.Data.Model.Cart> cart = _dataRepository.GetAll(id);

            if (cart == null)
            {
                return Ok(0);
            }

            return Ok(cart);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NeuFinesse.Data.Model.Cart cart)
        {
            if (cart == null)
            {
                return BadRequest("Cart is null.");
            }

            _dataRepository.Add(cart);
            return Ok("Item successfully added to cart");
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = cart.UserId },
            //      cart);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] NeuFinesse.Data.Model.Cart cart)
        {
            if (cart == null)
            {
                return BadRequest("Cart is null.");
            }

            NeuFinesse.Data.Model.Cart cartToUpdate = _dataRepository.Get(id);
            if (cartToUpdate == null)
            {
                return NotFound("The cart record couldn't be found.");
            }

            _dataRepository.Update(cartToUpdate, cart);
            return NoContent();
        }
    }
}