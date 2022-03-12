using Fixerr;
using Microsoft.AspNetCore.Mvc;

namespace FixerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixerController : ControllerBase
    {
        private readonly IFixerClient _fixerClient;

        public FixerController(IFixerClient fixerClient)
        {
            _fixerClient = fixerClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _fixerClient.GetLatestAsync();
            return Ok(response);
        }
    }
}
