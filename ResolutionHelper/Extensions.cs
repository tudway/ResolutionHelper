namespace ResolutionHelper
{
    public static class Extensions
    {
        public static Resolution GetResolution(this NativeStructs.DEVMODE devMode)
        {
            return new Resolution { Width = devMode.dmPelsWidth, Height = devMode.dmPelsHeight };
        }
    }
}
