using System;

namespace TomV.K8s.Showcase.Services
{
    public class HealthService
    {
        private DateTime? downUntil;

        public bool IsDown()
        {
            return  downUntil != null && downUntil > DateTime.UtcNow;
        }


        public void MakeDown(int seconds)
        {
            downUntil = DateTime.UtcNow.AddSeconds(seconds);
        }
    }
}
