using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MyIP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyIPController : ControllerBase
    {
       
        private readonly ILogger<MyIPController> _logger;

        public MyIPController(ILogger<MyIPController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "myip")]
        public IActionResult Get()
        {
            var remoteIpAddress = Request.HttpContext?.Connection?.RemoteIpAddress;
            remoteIpAddress = remoteIpAddress?.MapToIPv4();
            string parsip = remoteIpAddress?.ToString() ?? "UnKnown";
            _logger.LogInformation("Get Request From IP {0}", parsip);
         return  Ok(parsip);
        }
    }
}