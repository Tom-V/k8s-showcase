using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TomV.K8s.Showcase.Services;

namespace TomV.K8s.Showcase
{
    public class EnvModel : PageModel
    {
        private readonly EnvService envService;

        public EnvModel(EnvService envService)
        {
            this.envService = envService;
        }

        public Dictionary<string, string> EnvironmentVariables { get; private set; }

        public void OnGet(string filter = "")
        {
            EnvironmentVariables = envService.GetEnvironmentVariables(filter);
        }
    }
}