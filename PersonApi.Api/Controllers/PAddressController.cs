using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Business.InterfFace;
using PersonApi.Module.Module;
using System.Threading.Tasks;

namespace PersonApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAddressController : BaseAPIController
    {
        private IPAddress _Adress;

        public PAddressController(IPAddress Address)
        {
            _Adress = Address;
        }

     

        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddressn(PersonAddressModel model)
        {
            var result = await _Adress.AddAddressn(model);
            return Ok(result);
        }

        [HttpGet("GetAddress")]
        public async Task<IActionResult> GetAddress()
        {
            var result = await _Adress.GetAddress();
            return Ok(result);
        }

        [HttpPost("DeletAddress")]
        public async Task<IActionResult> DeletAddress(PersonAddressModel model)
        {
            var result = await _Adress.DeletAddress(model);
            return Ok(result);
        }


    [HttpPost("GetAddressById{Key}")]
    public async Task<IActionResult> GetAddressById(int Key)
    {
        var result = await _Adress.GetAddressById(Key);
        return Ok(result);
    }
        [HttpPost("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(PersonAddressModel model)
        {
            var result = await _Adress.UpdateAddress(model);
            return Ok(result);
        }
    }
}
