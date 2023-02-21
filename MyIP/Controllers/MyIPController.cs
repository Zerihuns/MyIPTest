using Microsoft.AspNetCore.Mvc;

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
            string parsedip = remoteIpAddress?.ToString();
            _logger.LogInformation("Get Request From IP {0}", parsedip);
         return  Ok(parsedip);
        }
    }
}