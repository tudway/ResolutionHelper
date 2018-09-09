using System;
using System.Runtime.InteropServices;

namespace ResolutionHelper
{
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayDevicesA(string lpDevice, int iDevNum, ref NativeStructs.DISPLAY_DEVICE lpDisplayDevice, int dwFlags);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettingsA(string lpszDeviceName, int iModelNum, ref NativeStructs.DEVMODE lpDevMode);

        [DllImport("user32.dll")]
        public static extern long ChangeDisplaySettingsExA(string lpszDeviceName, ref NativeStructs.DEVMODE lpDevMode, IntPtr hwnd, int dwFlags, IntPtr lParam);
    }
}
