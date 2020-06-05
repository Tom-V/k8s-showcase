using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace TomV.K8s.Showcase
{
    public class StopModel : PageModel
    {
        private readonly IHostApplicationLifetime hostApplicationLifetime;
        public StopModel(IHostApplicationLifetime hostApplicationLifetime)
        {
            this.hostApplicationLifetime = hostApplicationLifetime;

        }

        public IActionResult OnGet()
        {
            hostApplicationLifetime.StopApplication();

            return RedirectToPage("env", new { filter = "k8s" });
        }
    }
}