using System.Runtime.InteropServices;

namespace Wrapper
{
    // C: typedef enum enPicoReadSelection
    public enum PICO_READ_SELECTION
    {
        PICO_READSELECTION_NONE = 0,
        PICO_TRIGGER_READ = 1,
        PICO_DATA_READ1 = 2,
        PICO_DATA_READ2 = 3,
        PICO_DATA_READ3 = 4,
    }

    // C: typedef enum enPicoClockReference
    public enum PICO_CLOCK_REFERENCE
    {
        PICO_INTERNAL_REF,
        PICO_EXTERNAL_REF
    }

    // C: typedef enum tPicoTemperatureReference
    public enum PICO_TEMPERATURE_REFERENCE
    {
        PICO_TEMPERATURE_UNINITIALISED,
        PICO_TEMPERATURE_NORMAL,
        PICO_TEMPERATURE_WARNING,
        PICO_TEMPERATURE_CRITICAL
    }

    // TODO: PICO_USER_PROBE_INTERACTIONS
    [StructLayout(LayoutKind.Sequential)]
    public struct PICO_USER_PROBE_INTERACTIONS
    {
        // 结构体内部字段（PICO_CHANNEL, PicoConnectProbe, PICO_COUPLING 等）在此处定义
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void PicoUpdateFirmwareProgress(
        short handle,
        ushort progress
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void PicoProbeInteractions(
        short handle,
        uint status, // PICO_STATUS (uint32_t)
        ref PICO_USER_PROBE_INTERACTIONS probes,
        uint nProbes
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void PicoDataReadyUsingReads(
        short handle,
        PICO_READ_SELECTION read,
        uint status, // PICO_STATUS (uint32_t)
        ulong fromSegmentIndex,
        ulong toSegmentIndex,
        IntPtr pParameter // PICO_POINTER
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void PicoExternalReferenceInteractions(
        short handle,
        uint status, // PICO_STATUS (uint32_t)
        PICO_CLOCK_REFERENCE reference
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void PicoAWGOverrangeInteractions(
        short handle,
        uint status // PICO_STATUS (uint32_t)
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void PicoTemperatureSensorInteractions(
        short handle,
        PICO_TEMPERATURE_REFERENCE temperatureStatus
    );
}
