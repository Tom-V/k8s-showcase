using System.Net;
using Microsoft.AspNetCore.Mvc;
using TomV.K8s.Showcase.Services;

namespace TomV.K8s.Showcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly HealthService healthService;

        public HealthController(HealthService healthService)
        {
            this.healthService = healthService;
        }

        public IActionResult Get()
        {
            if(healthService.IsDown())
            {
                return StatusCode((int)HttpStatusCode.TooManyRequests, "Down");
            }

            return Ok("Up");
        }

        [Route("downtime")]
        public IActionResult SetDowntime(int seconds)
        {
            healthService.MakeDown(seconds);
            return Ok("Starting downtime");
        }
    }
}