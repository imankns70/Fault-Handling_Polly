using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        //GET /api/response/1

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetResponse(int id)
        {
            Random rnd = new();
            var rdnInteger = rnd.Next(1, 101);

            if (rdnInteger >= id)
            {
                Console.WriteLine("--> Failure - Generate a Http 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("--> Success - Generate a Http 200");
            return Ok();
        }
    }
}
