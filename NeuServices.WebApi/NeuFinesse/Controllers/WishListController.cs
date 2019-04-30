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
    public class WishListController : ControllerBase
    {
        private readonly IUserRepository<NeuFinesse.Data.Model.WishList> _dataRepository;

        public WishListController(IUserRepository<NeuFinesse.Data.Model.WishList> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<NeuFinesse.Data.Model.WishList> wishLists = _dataRepository.GetAll();
            return Ok(wishLists);
        }

        [HttpGet("{id}", Name = "WishList")]
        public IActionResult Get(string id)
        {
            IEnumerable<NeuFinesse.Data.Model.WishList> wishList = _dataRepository.GetAll(id);

            if (wishList == null)
            {
                return Ok(0);
            }

            return Ok(wishList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NeuFinesse.Data.Model.WishList wishList)
        {
            if (wishList == null)
            {
                return BadRequest("Wish List is null.");
            }

            _dataRepository.Add(wishList);
            return Ok("Item added to wish list successfully");
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = wishList.UserId },
            //      wishList);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] NeuFinesse.Data.Model.WishList wishList)
        {
            if (wishList == null)
            {
                return BadRequest("Wish list is null.");
            }

            NeuFinesse.Data.Model.WishList userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The wish list record couldn't be found.");
            }

            _dataRepository.Update(userToUpdate, wishList);
            return NoContent();
        }
    }
}