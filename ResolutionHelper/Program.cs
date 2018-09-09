using System;
using System.Linq;
using System.Threading;

namespace ResolutionHelper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var monitorInfos = EnumDisplayDevicesProvider.GetMonitorInfo();
            var oldres = monitorInfos.Skip(1).Take(1).Single().CurrentDevMode;

            foreach (var monitorInfo in monitorInfos)
            {
                Console.WriteLine(monitorInfo);
                Console.WriteLine();
            }

            var a = EnumDisplayDevicesProvider.GetEnumDisplayDevices();

            var device = a.Skip(1).Take(1).Single();
            var res = EnumDisplayDevicesProvider.GetDeviceModes(device.DeviceName).Skip(3).Take(1).Single();
            EnumDisplayDevicesProvider.ChangeResolution(device.DeviceName, ref res);

            Thread.Sleep(3000);
            
            EnumDisplayDevicesProvider.ChangeResolution(device.DeviceName, ref oldres);

            Console.ReadKey();
        }
    }
}
