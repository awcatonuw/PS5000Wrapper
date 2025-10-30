using System.Runtime.InteropServices;

namespace Wrapper
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PICO_VERSION
    {
        public short major_;
        public short minor_;
        public short revision_;
        public short build_;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PICO_FIRMWARE_INFO
    {
        public uint firmwareType; 
        public PICO_VERSION currentVersion;
        
        public PICO_VERSION updateVersion;
        public ushort updateRequired;
    }
}
