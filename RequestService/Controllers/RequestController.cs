using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        public RequestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        //Get api/request

        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            //HttpClient client = new();


            var client = _clientFactory.CreateClient("Test");

            var response = await client.GetAsync("http://localhost:5191/api/response/25");

            //var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
            //    () => client.GetAsync("http://localhost:5191/api/response/25"));

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> ResponseService returned Success");
                return Ok();
            }
            Console.WriteLine("--> ResponseService returned Failure");


            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
