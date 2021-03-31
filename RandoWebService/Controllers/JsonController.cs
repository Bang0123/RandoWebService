using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandoWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
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
