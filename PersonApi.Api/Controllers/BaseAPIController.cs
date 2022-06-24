using PersonApi.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Api.Controllers
{
    public class BaseAPIController: ControllerBase
    {
        protected readonly PersonApiContext _context;

        public BaseAPIController()
        {
        }

        public BaseAPIController(PersonApiContext context)
        {
            _context = context;
        }
    }
}
