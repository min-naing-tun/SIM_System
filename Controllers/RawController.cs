using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIM_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RawController : ControllerBase
    {
        ILogger<RawController> _logger;
        public RawController(ILogger<RawController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRawData()
        {
            var rawData = new List<object>
            {
                new
                {
                    id = 1,
                    name = "John Doe",
                    email = "9yK8d@example.com",
                },
                new
                {
                    id = 2,
                    name = "Jack Willian",
                    email = "t2s6W@example.com",
                },
                new
                {
                    id = 3,
                    name = "Bob Smith",
                    email = "t2s6W@example.com",
                },
                new
                {
                    id = 4,
                    name = "Alice Johnson",
                    email = "t2s6W@example.com",
                }
            };

            return Ok(rawData);
        }
    }
}
