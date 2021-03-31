using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandoWebService.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        private readonly ILogger<JsonController> _logger;

        public JsonController(ILogger<JsonController> logger)
        {
            _logger = logger;
        }

        [HttpPost("JsonTest")]
        public IActionResult JsonTest([FromQuery] string str)
        {
            var jt = JToken.Parse(str);
            
            if (jt is JObject { } jo)
            {
                if (jo.TryGetValue("message", out var msg))
                {
                    Console.WriteLine(msg);
                }

                Console.WriteLine("This is an jobject");
            }

            if (jt is JArray { } ja)
            {
                Console.WriteLine("This is an jarray");
            }

            return Ok(jt.ToString());
        }
    }
}
