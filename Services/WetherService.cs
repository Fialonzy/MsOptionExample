using System;
using Microsoft.Extensions.Options;
using MsOptionExample.Options;

namespace MsOptionExample.Services
{
    public class WetherService
    {
        public IOptionsMonitor<LocationOptions> City { get; set; }

        public WetherService(IOptionsMonitor<LocationOptions> options)
        {
            City = options;
        }

        public string GetWetherToday()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            var val = rnd.Next(0, 50) - 25; 
            return $"Today({DateTime.Now.ToShortDateString()}) in {City.CurrentValue.City} is {(val > 0 ? "+" : "")}{val}";
        }
    }
}