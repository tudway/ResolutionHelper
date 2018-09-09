using System.Collections.Generic;
using System.Linq;

namespace ResolutionHelper
{
    public class MonitorInfo
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public NativeStructs.DEVMODE CurrentDevMode { get; set; }

        public IEnumerable<NativeStructs.DEVMODE> AvailableDevModes { get; set; }
        public Resolution CurrentResolution { get; set; }
        //public IEnumerable<Resolution> AvailableResolutions { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Id: {Id}, Current resolution: {CurrentDevMode.GetResolution()}, Available Resolutions: {string.Join(", ", AvailableDevModes.Select(d => d.GetResolution()))}";
        }
    }
}
