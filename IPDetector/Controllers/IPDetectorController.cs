using Microsoft.AspNetCore.Mvc;
using IPDetector.Service;
using Microsoft.AspNetCore.Cors;
using IPDetector.Models;

namespace IPDetector.Controllers
{
    [ApiController]
    [EnableCors("default")]
    [Route("api/[controller]")]
    public class IPDetectorController : ControllerBase
    {
        [HttpGet("GetResult")]
        public string GetIPinfo()
        {
            // Retrieve client IP address through HttpContext.Connection
            IPDetectorModel IPInfo = new IPDetectorModel();
            IPDetectorService IPService = new IPDetectorService();
            IPInfo.IP = HttpContext.Connection.RemoteIpAddress?.ToString();
            if (IPInfo.IP != null)
            {
                return IPInfo.IP;
            }
            else
            {
                return "error";
            }
        }
    }
}