using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TomV.K8s.Showcase.Services;

namespace TomV.K8s.Showcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvController : ControllerBase
    {
        private readonly EnvService envService;

        public EnvController(EnvService envService)
        {
            this.envService = envService;
        }

        [HttpGet]
        public IActionResult Get(string filter = "")
        {
            var result = string.Join(",", envService.GetEnvironmentVariables(filter).Select(c => $"{c.Key}:{c.Value}"));
            return Content(result);
        }
    }
}