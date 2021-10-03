using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FSharpLib;

namespace example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MathsController : ControllerBase
    {
        private readonly ILogger<MathsController> _logger;

        public MathsController(ILogger<MathsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("isEven")]
        public IActionResult IsEven([FromQuery] int? num)
        {
            return Ok(Maths.IsEven(num ?? 0));
        }

        [HttpGet("isOdd")]
        public IActionResult IsOdd([FromQuery] int? num)
        {
            return Ok(Maths.IsOdd(num ?? 0));
        }

        [HttpGet("addInts")]
        public IActionResult Add([FromQuery] int? num1, int? num2)
        {
            if(!num1.HasValue || !num2.HasValue)
            {
                return BadRequest();
            }
            return Ok(Maths.Add(num1.Value, num2.Value));
        }
    }
}
