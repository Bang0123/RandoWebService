using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FSharpLib;


namespace example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathsController : ControllerBase
    {
        private readonly ILogger<MathsController> _logger;

        public MathsController(ILogger<MathsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("isEven")]
        public bool IsEven([FromQuery] int? num)
        {
            return Maths.IsEven(num ?? 0);
        }

        [HttpGet("isOdd")]
        public bool IsOdd([FromQuery] int? num)
        {
            return Maths.IsOdd(num ?? 0);
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
