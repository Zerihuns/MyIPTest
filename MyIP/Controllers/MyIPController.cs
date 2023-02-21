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
            _logger.LogInformation("Get Request From IP {0}", Request.HttpContext.Connection.RemoteIpAddress.ToString());
         return  Ok(Request.HttpContext.Connection.RemoteIpAddress.ToString());
        }
    }
}