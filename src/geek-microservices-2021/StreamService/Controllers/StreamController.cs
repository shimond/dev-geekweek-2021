using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StreamService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        private readonly ILogger<StreamController> _logger;

        public StreamController(ILogger<StreamController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{name}")]
        public IActionResult GetFile(string name)
        {
            _logger.LogInformation("GetFileByName Invoked {name}", name);
            string root = Directory.GetCurrentDirectory();
            string path = Path.Combine(root, "wwwroot", "content", name + ".mp4");
            return PhysicalFile(path, "application/octet-stream", true);
        }


    }
}
