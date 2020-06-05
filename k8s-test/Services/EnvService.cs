using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomV.K8s.Showcase.Services
{
    public class EnvService
    {
        public Dictionary<string, string> GetEnvironmentVariables(string filter)
        {
            var env = Environment.GetEnvironmentVariables();
            return env.Keys.Cast<string>()
                .Where(e => filter == null ||  e.ToLowerInvariant().StartsWith(filter.ToLowerInvariant()))
                .OrderBy(e => e)
                .ToDictionary(k => k, k => (string)env[k]);
        }

    }
}
