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
    public class InterestController : ControllerBase
    {
        private readonly IDataRepository<NeuFinesse.Data.Model.Interest> _dataRepository;

        public InterestController(IDataRepository<NeuFinesse.Data.Model.Interest> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<NeuFinesse.Data.Model.Interest> interests = _dataRepository.GetAll();
            return Ok(interests);
        }

        [HttpGet("{id}", Name = "Interest")]
        public IActionResult Get(long id)
        {
            NeuFinesse.Data.Model.Interest interest = _dataRepository.Get(id);

            if (interest == null)
            {
                return NotFound("The Interest record couldn't be found.");
            }

            return Ok(interest);
        }
    }
}