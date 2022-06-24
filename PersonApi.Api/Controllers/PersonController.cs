using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Business.InterfFace;
using PersonApi.Module.Module;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using ChampionReview.Module.Helper;

namespace PersonApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseAPIController
    {
        private IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }

        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson(PersonModel model)
        {
            var result = await _person.AddPerson(model);
            return Ok(result);
        }

        [HttpGet("GetPerson")]
        public async Task<IActionResult> GetPerson()
        {
            var result = await _person.GetPerson();
            return Ok(result);
        }
        [HttpGet("GetPersonAdress")]
        public async Task<IActionResult> GetPersonAdress()
        {
            var result = await _person.GetPersonAdress();
            return Ok(result);
        }

        [HttpGet("GetPerson{Key}")]
        public async Task<IActionResult> GetPersonById(int Key)
        {
            var result = await _person.GetPersonById(Key);
            return Ok(result);
        }

        [HttpPost("DeletPerson")]
        public async Task<IActionResult> PersonModel(PersonModel model)
        {
            var result = await _person.DeletPerson(model);
            return Ok(result);
        }

        [HttpPost("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson(PersonModel model)
        {
            var result = await _person.UpdatePerson(model);
            return Ok(result);
        }

    }
}
