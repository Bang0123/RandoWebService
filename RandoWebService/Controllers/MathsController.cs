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

        [HttpGet]
        public bool Get()
        {
            Maths m = new Maths();


            return false;
        }
    }
}
