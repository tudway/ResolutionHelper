namespace ResolutionHelper
{
    public static class Extensions
    {
        public static Resolution GetResolution(this NativeStructs.DEVMODE devMode)
        {
            return new Resolution
            {
                Width = devMode.dmPelsWidth,
                Height = devMode.dmPelsHeight,
                DisplayMemoryKb = devMode.CalculateDisplayMemory()
            };
        }

        private static int CalculateDisplayMemory(this NativeStructs.DEVMODE devMode)
        {
            return devMode.dmPelsHeight * devMode.dmPelsWidth * devMode.dmBitsPerPel / 8192; //magic (8 bits to bytes) * (1024 bytes in a kilobyte)
        }
    }
}
