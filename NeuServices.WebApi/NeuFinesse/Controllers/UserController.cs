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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository<NeuFinesse.Data.Model.User> _userRepository;

        public UserController(IUserRepository<NeuFinesse.Data.Model.User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
           IEnumerable<NeuFinesse.Data.Model.User> users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            NeuFinesse.Data.Model.User user = _userRepository.Get(id);

            if (user == null)
            {
                return Ok(0);
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NeuFinesse.Data.Model.User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            _userRepository.Add(user);
            return Ok("User added successfully");
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = user.UserId },
            //      user);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] NeuFinesse.Data.Model.User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            NeuFinesse.Data.Model.User userToUpdate = _userRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The user record couldn't be found.");
            }

            _userRepository.Update(userToUpdate, user);
            return NoContent();
        }
    }
}