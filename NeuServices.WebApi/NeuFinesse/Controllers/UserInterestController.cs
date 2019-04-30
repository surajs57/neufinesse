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
    public class UserInterestController : ControllerBase
    {
        private readonly IUserRepository<NeuFinesse.Data.Model.UserInterest> _dataRepository;

        public UserInterestController(IUserRepository<NeuFinesse.Data.Model.UserInterest> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<NeuFinesse.Data.Model.UserInterest> userInterest = _dataRepository.GetAll();
            return Ok(userInterest);
        }

        [HttpGet("{id}", Name = "UserInterest")]
        public IActionResult Get(string id)
        {
            var userInterest = _dataRepository.GetAll(id);

            if (userInterest == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            return Ok(userInterest);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NeuFinesse.Data.Model.UserInterest userInterest)
        {
            if (userInterest == null)
            {
                return Ok(0);
            }

            _dataRepository.Add(userInterest);
            return Ok("Interest added successfully");
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = userInterest.UserId },
            //      userInterest);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] NeuFinesse.Data.Model.UserInterest userInterest)
        {
            if (userInterest == null)
            {
                return BadRequest("User is null.");
            }

            NeuFinesse.Data.Model.UserInterest userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The user record couldn't be found.");
            }

            _dataRepository.Update(userToUpdate, userInterest);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            NeuFinesse.Data.Model.UserInterest userInterest = _dataRepository.Get(id);
            if (userInterest == null)
            {
                return NotFound("The user record couldn't be found.");
            }

            _dataRepository.Delete(userInterest);
            return NoContent();
        }
    }
}