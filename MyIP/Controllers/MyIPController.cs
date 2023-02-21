using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;

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
            string ipAddress = string.Empty; 
            IPAddress ip = Request.HttpContext.Connection.RemoteIpAddress;
            if (ip != null)
            {
                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    var name = Dns.GetHostName(); // get container id
                    ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
                }
                ipAddress = ip.ToString();
                _logger.LogInformation("Get Request From IP {0}", ipAddress);
            }
            return Ok(ipAddress);

        }
    }
}