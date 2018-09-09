using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ResolutionHelper
{
    public static class EnumDisplayDevicesProvider
    {
        public static IEnumerable<NativeStructs.DISPLAY_DEVICE> GetEnumDisplayDevices()
        {
            NativeStructs.DISPLAY_DEVICE displayDevice = new NativeStructs.DISPLAY_DEVICE();
            displayDevice.cb = Marshal.SizeOf(displayDevice);
            for (int i = 0; NativeMethods.EnumDisplayDevicesA(null, i, ref displayDevice, 1); i++)
            {
                if (displayDevice.StateFlags.HasFlag(NativeStructs.DisplayDeviceStateFlags.AttachedToDesktop))
                {
                    yield return displayDevice;
                }
            }
        }

        private static string GetMonitorName(string monitorId)
        {
            NativeStructs.DISPLAY_DEVICE displayDevice = new NativeStructs.DISPLAY_DEVICE();
            displayDevice.cb = Marshal.SizeOf(displayDevice);
            NativeMethods.EnumDisplayDevicesA(monitorId, 0, ref displayDevice, 1);

            return displayDevice.DeviceString;
        }

        public static IEnumerable<NativeStructs.DEVMODE> GetDeviceModes(string deviceName)
        {
            NativeStructs.DEVMODE devMode = new NativeStructs.DEVMODE();
            for (int i = 0;  NativeMethods.EnumDisplaySettingsA(deviceName, i, ref devMode); i++)
            {
                yield return devMode;
            }
        }

        public static Resolution GetCurrentResolution(string deviceName)
        {
            NativeStructs.DEVMODE devMode = new NativeStructs.DEVMODE();
            NativeMethods.EnumDisplaySettingsA(deviceName, -1, ref devMode);
            return new Resolution {Width = devMode.dmPelsWidth, Height = devMode.dmPelsHeight};
        }

        public static NativeStructs.DEVMODE GetCurrentDevMode(string deviceName)
        {
            NativeStructs.DEVMODE devMode = new NativeStructs.DEVMODE();
            NativeMethods.EnumDisplaySettingsA(deviceName, -1, ref devMode);
            return devMode;
        }

        public static long ChangeResolution(string deviceName, ref NativeStructs.DEVMODE devMode)
        {
            return NativeMethods.ChangeDisplaySettingsExA(deviceName, ref devMode, IntPtr.Zero, 1, IntPtr.Zero);
        }

        public static IEnumerable<MonitorInfo> GetMonitorInfo()
        {
            return GetEnumDisplayDevices().Select(d => new MonitorInfo
            {
                Name = d.DeviceName,
                Id = GetMonitorName(d.DeviceName),
                CurrentDevMode = GetCurrentDevMode(d.DeviceName),
                AvailableDevModes = GetDeviceModes(d.DeviceName),
                CurrentResolution = GetCurrentResolution(d.DeviceName),
                /*AvailableResolutions = GetDeviceModes(d.DeviceName).Select(m => new Resolution
                {
                    Width = m.dmPelsWidth,
                    Height = m.dmPelsHeight
                }).Distinct()*/
            });
        }
    }
}
