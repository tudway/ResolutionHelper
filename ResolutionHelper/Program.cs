using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ResolutionHelper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1 find current resolutions of monitors

            IEnumerable<NativeStructs.DISPLAY_DEVICE> devices = EnumDisplayDevicesProvider.GetDisplayDevices();

            //2 calculate display memory for monitors

            IList<MonitorInfo> monitors = devices.Select(d => EnumDisplayDevicesProvider.GetMonitorInfo(d.DeviceName)).ToList();
            var monitor1 = monitors[0].AvailableDevModes.Select(dm => dm.GetResolution());

            //3 work out the max resolution combination for the monitors we have (max limit is 65536KB maybe?)

            //4 change monitor resolutions

            //EnumDisplayDevicesProvider.ChangeResolution(device.DeviceName, ref res);


            //5 offer option to switch back

            //EnumDisplayDevicesProvider.ChangeResolution(device.DeviceName, ref res);
        }
    }
}
