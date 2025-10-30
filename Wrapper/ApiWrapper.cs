using System.Runtime.InteropServices;
using System.Text;

namespace Wrapper
{
    public static class ApiWrapper
    {
        public const short PS5000A_MAX_VALUE_8BIT = 32512;
        public const short PS5000A_MIN_VALUE_8BIT = -32512;

        public const short PS5000A_MAX_VALUE_16BIT = 32767;
        public const short PS5000A_MIN_VALUE_16BIT = -32767;

        public const short PS5000A_EXT_MAX_VALUE = 32767;
        public const short PS5000A_EXT_MIN_VALUE = -32767;

        public const int PS5X42A_MAX_SIG_GEN_BUFFER_SIZE = 16384;
        public const int PS5X43A_MAX_SIG_GEN_BUFFER_SIZE = 32768;
        public const int PS5X44A_MAX_SIG_GEN_BUFFER_SIZE = 49152;
        public const int PS5X4XD_MAX_SIG_GEN_BUFFER_SIZE = 32768;

        public const int MIN_SIG_GEN_BUFFER_SIZE = 1;
        public const int MIN_DWELL_COUNT = 3;
        public const int MAX_SWEEPS_SHOTS = (1 << 30) - 1;
        public const double AWG_DAC_FREQUENCY = 200e6;
        public const double PS5000AB_DDS_FREQUENCY = 200e6;
        public const double PS5000D_DDS_FREQUENCY = 100e6;
        public const double AWG_PHASE_ACCUMULATOR = 4294967296.0;

        public const float MAX_ANALOGUE_OFFSET_50MV_200MV = 0.250f;
        public const float MIN_ANALOGUE_OFFSET_50MV_200MV = -0.250f;
        public const float MAX_ANALOGUE_OFFSET_500MV_2V = 2.500f;
        public const float MIN_ANALOGUE_OFFSET_500MV_2V = -2.500f;
        public const float MAX_ANALOGUE_OFFSET_5V_20V = 20.0f;
        public const float MIN_ANALOGUE_OFFSET_5V_20V = -20.0f;

        public const int PS5244A_MAX_ETS_CYCLES = 500;
        public const int PS5244A_MAX_ETS_INTERLEAVE = 40;
        public const int PS5243A_MAX_ETS_CYCLES = 250;
        public const int PS5243A_MAX_ETS_INTERLEAVE = 20;
        public const int PS5242A_MAX_ETS_CYCLES = 125;
        public const int PS5242A_MAX_ETS_INTERLEAVE = 10;

        public const int PS5X44D_MAX_ETS_CYCLES = 500;
        public const int PS5X44D_MAX_ETS_INTERLEAVE = 80;
        public const int PS5X43D_MAX_ETS_CYCLES = 250;
        public const int PS5X43D_MAX_ETS_INTERLEAVE = 40;
        public const int PS5X42D_MAX_ETS_CYCLES = 125;
        public const int PS5X42D_MAX_ETS_INTERLEAVE = 5;

        public const uint PS5000A_SHOT_SWEEP_TRIGGER_CONTINUOUS_RUN = 0xFFFFFFFF;

        public const float PS5000A_SINE_MAX_FREQUENCY = 20000000.0f;
        public const float PS5000A_SQUARE_MAX_FREQUENCY = 20000000.0f;
        public const float PS5000A_TRIANGLE_MAX_FREQUENCY = 20000000.0f;
        public const float PS5000A_SINC_MAX_FREQUENCY = 20000000.0f;
        public const float PS5000A_RAMP_MAX_FREQUENCY = 20000000.0f;
        public const float PS5000A_HALF_SINE_MAX_FREQUENCY = 20000000.0f;
        public const float PS5000A_GAUSSIAN_MAX_FREQUENCY = 20000000.0f;
        public const float PS5000A_MIN_FREQUENCY = 0.03f;

        // Enums directly in namespace 
        public enum PS5000A_DEVICE_RESOLUTION
        {
            PS5000A_DR_8BIT,
            PS5000A_DR_12BIT,
            PS5000A_DR_14BIT,
            PS5000A_DR_15BIT,
            PS5000A_DR_16BIT
        }

        public enum PS5000A_EXTRA_OPERATIONS
        {
            PS5000A_ES_OFF,
            PS5000A_WHITENOISE,
            PS5000A_PRBS
        }

        public enum PS5000A_BANDWIDTH_LIMITER
        {
            PS5000A_BW_FULL,
            PS5000A_BW_20MHZ
        }

        public enum PS5000A_COUPLING
        {
            PS5000A_AC,
            PS5000A_DC
        }

        public enum PS5000A_CHANNEL
        {
            PS5000A_CHANNEL_A,
            PS5000A_CHANNEL_B,
            PS5000A_CHANNEL_C,
            PS5000A_CHANNEL_D,
            PS5000A_EXTERNAL,
            PS5000A_MAX_CHANNELS = PS5000A_EXTERNAL,
            PS5000A_TRIGGER_AUX,
            PS5000A_MAX_TRIGGER_SOURCES,
            PS5000A_DIGITAL_PORT0 = 0x80,
            PS5000A_DIGITAL_PORT1,
            PS5000A_DIGITAL_PORT2,
            PS5000A_DIGITAL_PORT3,
            PS5000A_PULSE_WIDTH_SOURCE = 0x10000000
        }

        public enum PS5000A_CHANNEL_FLAGS
        {
            PS5000A_CHANNEL_A_FLAGS = 1,
            PS5000A_CHANNEL_B_FLAGS = 2,
            PS5000A_CHANNEL_C_FLAGS = 4,
            PS5000A_CHANNEL_D_FLAGS = 8,

            PS5000A_PORT0_FLAGS = 65536,
            PS5000A_PORT1_FLAGS = 131072,
            PS5000A_PORT2_FLAGS = 262144,
            PS5000A_PORT3_FLAGS = 524288
        }

        public enum PS5000A_DIGITAL_CHANNEL
        {
            PS5000A_DIGITAL_CHANNEL_0,
            PS5000A_DIGITAL_CHANNEL_1,
            PS5000A_DIGITAL_CHANNEL_2,
            PS5000A_DIGITAL_CHANNEL_3,
            PS5000A_DIGITAL_CHANNEL_4,
            PS5000A_DIGITAL_CHANNEL_5,
            PS5000A_DIGITAL_CHANNEL_6,
            PS5000A_DIGITAL_CHANNEL_7,
            PS5000A_DIGITAL_CHANNEL_8,
            PS5000A_DIGITAL_CHANNEL_9,
            PS5000A_DIGITAL_CHANNEL_10,
            PS5000A_DIGITAL_CHANNEL_11,
            PS5000A_DIGITAL_CHANNEL_12,
            PS5000A_DIGITAL_CHANNEL_13,
            PS5000A_DIGITAL_CHANNEL_14,
            PS5000A_DIGITAL_CHANNEL_15,
            PS5000A_DIGITAL_CHANNEL_16,
            PS5000A_DIGITAL_CHANNEL_17,
            PS5000A_DIGITAL_CHANNEL_18,
            PS5000A_DIGITAL_CHANNEL_19,
            PS5000A_DIGITAL_CHANNEL_20,
            PS5000A_DIGITAL_CHANNEL_21,
            PS5000A_DIGITAL_CHANNEL_22,
            PS5000A_DIGITAL_CHANNEL_23,
            PS5000A_DIGITAL_CHANNEL_24,
            PS5000A_DIGITAL_CHANNEL_25,
            PS5000A_DIGITAL_CHANNEL_26,
            PS5000A_DIGITAL_CHANNEL_27,
            PS5000A_DIGITAL_CHANNEL_28,
            PS5000A_DIGITAL_CHANNEL_29,
            PS5000A_DIGITAL_CHANNEL_30,
            PS5000A_DIGITAL_CHANNEL_31,
            PS5000A_MAX_DIGITAL_CHANNELS
        }

        public enum PS5000A_DIGITAL_DIRECTION
        {
            PS5000A_DIGITAL_DONT_CARE,
            PS5000A_DIGITAL_DIRECTION_LOW,
            PS5000A_DIGITAL_DIRECTION_HIGH,
            PS5000A_DIGITAL_DIRECTION_RISING,
            PS5000A_DIGITAL_DIRECTION_FALLING,
            PS5000A_DIGITAL_DIRECTION_RISING_OR_FALLING,
            PS5000A_DIGITAL_MAX_DIRECTION
        }

        public enum PS5000A_RANGE
        {
            PS5000A_10MV,
            PS5000A_20MV,
            PS5000A_50MV,
            PS5000A_100MV,
            PS5000A_200MV,
            PS5000A_500MV,
            PS5000A_1V,
            PS5000A_2V,
            PS5000A_5V,
            PS5000A_10V,
            PS5000A_20V,
            PS5000A_50V,
            PS5000A_MAX_RANGES
        }

        public enum PS5000A_ETS_MODE
        {
            PS5000A_ETS_OFF,             // ETS disabled
            PS5000A_ETS_FAST,            // Return ready as soon as requested no of interleaves is available
            PS5000A_ETS_SLOW,            // Return ready every time a new set of no_of_cycles is collected
            PS5000A_ETS_MODES_MAX
        }

        public enum PS5000A_TIME_UNITS
        {
            PS5000A_FS,
            PS5000A_PS,
            PS5000A_NS,
            PS5000A_US,
            PS5000A_MS,
            PS5000A_S,
            PS5000A_MAX_TIME_UNITS
        }

        public enum PS5000A_SWEEP_TYPE
        {
            PS5000A_UP,
            PS5000A_DOWN,
            PS5000A_UPDOWN,
            PS5000A_DOWNUP,
            PS5000A_MAX_SWEEP_TYPES
        }

        public enum PS5000A_WAVE_TYPE
        {
            PS5000A_SINE,
            PS5000A_SQUARE,
            PS5000A_TRIANGLE,
            PS5000A_RAMP_UP,
            PS5000A_RAMP_DOWN,
            PS5000A_SINC,
            PS5000A_GAUSSIAN,
            PS5000A_HALF_SINE,
            PS5000A_DC_VOLTAGE,
            PS5000A_WHITE_NOISE,
            PS5000A_MAX_WAVE_TYPES
        }

        public enum PS5000A_CONDITIONS_INFO
        {
            PS5000A_CLEAR = 0x00000001,
            PS5000A_ADD = 0x00000002
        }

        public enum PS5000A_SIGGEN_TRIG_TYPE
        {
            PS5000A_SIGGEN_RISING,
            PS5000A_SIGGEN_FALLING,
            PS5000A_SIGGEN_GATE_HIGH,
            PS5000A_SIGGEN_GATE_LOW
        }

        public enum PS5000A_SIGGEN_TRIG_SOURCE
        {
            PS5000A_SIGGEN_NONE,
            PS5000A_SIGGEN_SCOPE_TRIG,
            PS5000A_SIGGEN_AUX_IN,
            PS5000A_SIGGEN_EXT_IN,
            PS5000A_SIGGEN_SOFT_TRIG
        }

        public enum PS5000A_INDEX_MODE
        {
            PS5000A_SINGLE,
            PS5000A_DUAL,
            PS5000A_QUAD,
            PS5000A_MAX_INDEX_MODES
        }

        public enum PS5000A_THRESHOLD_MODE
        {
            PS5000A_LEVEL,
            PS5000A_WINDOW
        }

        public enum PS5000A_THRESHOLD_DIRECTION
        {
            PS5000A_ABOVE,               //using upper threshold
            PS5000A_BELOW,               //using upper threshold 
            PS5000A_RISING,              //using upper threshold
            PS5000A_FALLING,             //using upper threshold
            PS5000A_RISING_OR_FALLING,   //using both threshold
            PS5000A_ABOVE_LOWER,         //using lower threshold
            PS5000A_BELOW_LOWER,         //using lower threshold
            PS5000A_RISING_LOWER,        //using lower threshold
            PS5000A_FALLING_LOWER,       //using lower threshold

            //Windowing using both thresholds
            PS5000A_INSIDE = PS5000A_ABOVE,
            PS5000A_OUTSIDE = PS5000A_BELOW,
            PS5000A_ENTER = PS5000A_RISING,
            PS5000A_EXIT = PS5000A_FALLING,
            PS5000A_ENTER_OR_EXIT = PS5000A_RISING_OR_FALLING,
            PS5000A_POSITIVE_RUNT = 9,
            PS5000A_NEGATIVE_RUNT,

            //no trigger set
            PS5000A_NONE = PS5000A_RISING
        }

        public enum PS5000A_TRIGGER_STATE
        {
            PS5000A_CONDITION_DONT_CARE,
            PS5000A_CONDITION_TRUE,
            PS5000A_CONDITION_FALSE,
            PS5000A_CONDITION_MAX
        }

        public enum PS5000A_TRIGGER_WITHIN_PRE_TRIGGER
        {
            PS5000A_DISABLE,
            PS5000A_ARM
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_TRIGGER_INFO
        {
            public uint status;
            public uint segmentIndex;
            public uint triggerIndex;
            public long triggerTime;
            public short timeUnits;
            public short reserved0;
            public ulong timeStampCounter;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_TRIGGER_CONDITIONS
        {
            public PS5000A_TRIGGER_STATE channelA;
            public PS5000A_TRIGGER_STATE channelB;
            public PS5000A_TRIGGER_STATE channelC;
            public PS5000A_TRIGGER_STATE channelD;
            public PS5000A_TRIGGER_STATE external;
            public PS5000A_TRIGGER_STATE aux;
            public PS5000A_TRIGGER_STATE pulseWidthQualifier;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_CONDITION
        {
            public PS5000A_CHANNEL source;
            public PS5000A_TRIGGER_STATE condition;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_DIRECTION
        {
            public PS5000A_CHANNEL source;
            public PS5000A_THRESHOLD_DIRECTION direction;
            public PS5000A_THRESHOLD_MODE mode;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_PWQ_CONDITIONS
        {
            public PS5000A_TRIGGER_STATE channelA;
            public PS5000A_TRIGGER_STATE channelB;
            public PS5000A_TRIGGER_STATE channelC;
            public PS5000A_TRIGGER_STATE channelD;
            public PS5000A_TRIGGER_STATE external;
            public PS5000A_TRIGGER_STATE aux;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_SCALING_FACTORS_VALUES
        {
            public PS5000A_CHANNEL source;
            public PS5000A_RANGE range;
            public short offset;
            public double scalingFactor;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_TRIGGER_CHANNEL_PROPERTIES
        {
            public short thresholdUpper;
            public ushort thresholdUpperHysteresis;
            public short thresholdLower;
            public ushort thresholdLowerHysteresis;
            public PS5000A_CHANNEL channel;
            public PS5000A_THRESHOLD_MODE thresholdMode;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_TRIGGER_CHANNEL_PROPERTIES_V2
        {
            public short thresholdUpper;
            public ushort thresholdUpperHysteresis;
            public short thresholdLower;
            public ushort thresholdLowerHysteresis;
            public PS5000A_CHANNEL channel;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PS5000A_DIGITAL_CHANNEL_DIRECTIONS
        {
            public PS5000A_DIGITAL_CHANNEL channel;
            public PS5000A_DIGITAL_DIRECTION direction;
        }

        public enum PS5000A_RATIO_MODE
        {
            PS5000A_RATIO_MODE_NONE = 0,
            PS5000A_RATIO_MODE_AGGREGATE = 1,
            PS5000A_RATIO_MODE_DECIMATE = 2,
            PS5000A_RATIO_MODE_AVERAGE = 4,
            PS5000A_RATIO_MODE_DISTRIBUTION = 8
        }

        public enum PS5000A_PULSE_WIDTH_TYPE
        {
            PS5000A_PW_TYPE_NONE,
            PS5000A_PW_TYPE_LESS_THAN,
            PS5000A_PW_TYPE_GREATER_THAN,
            PS5000A_PW_TYPE_IN_RANGE,
            PS5000A_PW_TYPE_OUT_OF_RANGE
        }

        public enum PS5000A_CHANNEL_INFO
        {
            PS5000A_CI_RANGES
        }

        // P/Invoke library name (framework/dylib/shared lib). Adjust if needed on other platforms.
        internal const string PS5000A = "libps5000a";

        // Callbacks (treat PICO_STATUS as uint)
        public delegate uint ps5000aBlockReady(short handle, uint status, IntPtr pParameter);
        public delegate void ps5000aStreamingReady(short handle, int noOfSamples, uint startIndex, short overflow, uint triggerAt, short triggered, short autoStop, IntPtr pParameter);
        public delegate uint ps5000aDataReady(short handle, uint status, uint noOfSamples, short overflow, IntPtr pParameter);

        // Selected API functions (PICO_STATUS -> uint)
        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "ps5000aOpenUnit")]
        public static extern uint ps5000aOpenUnit(out short handle, StringBuilder serial, PS5000A_DEVICE_RESOLUTION resolution);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "ps5000aOpenUnitAsync")]
        public static extern uint ps5000aOpenUnitAsync(out short status, StringBuilder serial, PS5000A_DEVICE_RESOLUTION resolution);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aOpenUnitProgress")]
        public static extern uint ps5000aOpenUnitProgress(out short handle, out short progressPercent, out short complete);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "ps5000aGetUnitInfo")]
        public static extern uint ps5000aGetUnitInfo(short handle, StringBuilder str, short stringLength, out short requiredSize, uint info /* PICO_INFO */);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aFlashLed")]
        public static extern uint ps5000aFlashLed(short handle, short start);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aIsLedFlashing")]
        public static extern uint ps5000aIsLedFlashing(short handle, out short status);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aCloseUnit")]
        public static extern uint ps5000aCloseUnit(short handle);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aMemorySegments")]
        public static extern uint ps5000aMemorySegments(short handle, uint nSegments, out int nMaxSamples);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetChannel")]
        public static extern uint ps5000aSetChannel(short handle, PS5000A_CHANNEL channel, short enabled, PS5000A_COUPLING type, PS5000A_RANGE range, float analogOffset);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetDigitalPort")]
        public static extern uint ps5000aSetDigitalPort(short handle, PS5000A_CHANNEL port, short enabled, short logicLevel);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetBandwidthFilter")]
        public static extern uint ps5000aSetBandwidthFilter(short handle, PS5000A_CHANNEL channel, PS5000A_BANDWIDTH_LIMITER bandwidth);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aGetTimebase")]
        public static extern uint ps5000aGetTimebase(short handle, uint timebase, int noSamples, out int timeIntervalNanoseconds, out int maxSamples, uint segmentIndex);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aGetTimebase2")]
        public static extern uint ps5000aGetTimebase2(short handle, uint timebase, int noSamples, out float timeIntervalNanoseconds, out int maxSamples, uint segmentIndex);


        // Stateless / siggen / trigger / ets / helpers etc.

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aNearestSampleIntervalStateless")]
        public static extern uint ps5000aNearestSampleIntervalStateless(
            short handle,
            PS5000A_CHANNEL_FLAGS enabledChannelOrPortFlags,
            double timeIntervalRequested,
            PS5000A_DEVICE_RESOLUTION resolution,
            ushort useEts,
            out uint timebase,
            out double timeIntervalAvailable);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aGetMinimumTimebaseStateless")]
        public static extern uint ps5000aGetMinimumTimebaseStateless(
            short handle,
            PS5000A_CHANNEL_FLAGS enabledChannelOrPortFlags,
            out uint timebase,
            out double timeInterval,
            PS5000A_DEVICE_RESOLUTION resolution);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aChannelCombinationsStateless")]
        public static extern uint ps5000aChannelCombinationsStateless(
            short handle,
            [Out] PS5000A_CHANNEL_FLAGS[] channelOrPortFlagsCombinations,
            out uint nChannelCombinations,
            PS5000A_DEVICE_RESOLUTION resolution,
            uint timebase,
            short hasDcPowerSupplyConnected);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetSigGenArbitrary")]
        public static extern uint ps5000aSetSigGenArbitrary(
            short handle,
            int offsetVoltage,
            uint pkToPk,
            uint startDeltaPhase,
            uint stopDeltaPhase,
            uint deltaPhaseIncrement,
            uint dwellCount,
            short[] arbitraryWaveform, // nullable if using IntPtr
            int arbitraryWaveformSize,
            PS5000A_SWEEP_TYPE sweepType,
            PS5000A_EXTRA_OPERATIONS operation,
            PS5000A_INDEX_MODE indexMode,
            uint shots,
            uint sweeps,
            PS5000A_SIGGEN_TRIG_TYPE triggerType,
            PS5000A_SIGGEN_TRIG_SOURCE triggerSource,
            short extInThreshold);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetSigGenBuiltIn")]
        public static extern uint ps5000aSetSigGenBuiltIn(
            short handle,
            int offsetVoltage,
            uint pkToPk,
            PS5000A_WAVE_TYPE waveType,
            float startFrequency,
            float stopFrequency,
            float increment,
            float dwellTime,
            PS5000A_SWEEP_TYPE sweepType,
            PS5000A_EXTRA_OPERATIONS operation,
            uint shots,
            uint sweeps,
            PS5000A_SIGGEN_TRIG_TYPE triggerType,
            PS5000A_SIGGEN_TRIG_SOURCE triggerSource,
            short extInThreshold);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetSigGenBuiltInV2")]
        public static extern uint ps5000aSetSigGenBuiltInV2(
            short handle,
            int offsetVoltage,
            uint pkToPk,
            PS5000A_WAVE_TYPE waveType,
            double startFrequency,
            double stopFrequency,
            double increment,
            double dwellTime,
            PS5000A_SWEEP_TYPE sweepType,
            PS5000A_EXTRA_OPERATIONS operation,
            uint shots,
            uint sweeps,
            PS5000A_SIGGEN_TRIG_TYPE triggerType,
            PS5000A_SIGGEN_TRIG_SOURCE triggerSource,
            short extInThreshold);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetSigGenPropertiesArbitrary")]
        public static extern uint ps5000aSetSigGenPropertiesArbitrary(
            short handle,
            uint startDeltaPhase,
            uint stopDeltaPhase,
            uint deltaPhaseIncrement,
            uint dwellCount,
            PS5000A_SWEEP_TYPE sweepType,
            uint shots,
            uint sweeps,
            PS5000A_SIGGEN_TRIG_TYPE triggerType,
            PS5000A_SIGGEN_TRIG_SOURCE triggerSource,
            short extInThreshold);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetSigGenPropertiesBuiltIn")]
        public static extern uint ps5000aSetSigGenPropertiesBuiltIn(
            short handle,
            double startFrequency,
            double stopFrequency,
            double increment,
            double dwellTime,
            PS5000A_SWEEP_TYPE sweepType,
            uint shots,
            uint sweeps,
            PS5000A_SIGGEN_TRIG_TYPE triggerType,
            PS5000A_SIGGEN_TRIG_SOURCE triggerSource,
            short extInThreshold);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSigGenFrequencyToPhase")]
        public static extern uint ps5000aSigGenFrequencyToPhase(
            short handle,
            double frequency,
            PS5000A_INDEX_MODE indexMode,
            uint bufferLength,
            out uint phase);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSigGenArbitraryMinMaxValues")]
        public static extern uint ps5000aSigGenArbitraryMinMaxValues(
            short handle,
            out short minArbitraryWaveformValue,
            out short maxArbitraryWaveformValue,
            out uint minArbitraryWaveformSize,
            out uint maxArbitraryWaveformSize);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSigGenSoftwareControl")]
        public static extern uint ps5000aSigGenSoftwareControl(short handle, short state);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetEts")]
        public static extern uint ps5000aSetEts(
            short handle,
            PS5000A_ETS_MODE mode,
            short etsCycles,
            short etsInterleave,
            out int sampleTimePicoseconds);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetTriggerChannelPropertiesV2")]
        public static extern uint ps5000aSetTriggerChannelPropertiesV2(
            short handle,
            [In] PS5000A_TRIGGER_CHANNEL_PROPERTIES_V2[] channelProperties,
            short nChannelProperties,
            short auxOutputEnable);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetAutoTriggerMicroSeconds")]
        public static extern uint ps5000aSetAutoTriggerMicroSeconds(short handle, ulong autoTriggerMicroseconds);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetTriggerChannelConditionsV2")]
        public static extern uint ps5000aSetTriggerChannelConditionsV2(
            short handle,
            [In] PS5000A_CONDITION[] conditions,
            short nConditions,
            PS5000A_CONDITIONS_INFO info);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetTriggerChannelDirectionsV2")]
        public static extern uint ps5000aSetTriggerChannelDirectionsV2(
            short handle,
            [In] PS5000A_DIRECTION[] directions,
            ushort nDirections);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetSimpleTrigger")]
        public static extern uint ps5000aSetSimpleTrigger(
            short handle,
            short enable,
            PS5000A_CHANNEL channel,
            short threshold,
            PS5000A_THRESHOLD_DIRECTION direction,
            uint delay,
            short autoTrigger_ms);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetTriggerDigitalPortProperties")]
        public static extern uint ps5000aSetTriggerDigitalPortProperties(
            short handle,
            [In] PS5000A_DIGITAL_CHANNEL_DIRECTIONS[] directions,
            short nDirections);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetPulseWidthDigitalPortProperties")]
        public static extern uint ps5000aSetPulseWidthDigitalPortProperties(
            short handle,
            [In] PS5000A_DIGITAL_CHANNEL_DIRECTIONS[] directions,
            short nDirections);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ps5000aSetTriggerDelay")]
        public static extern uint ps5000aSetTriggerDelay(short handle, uint delay);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetPulseWidthQualifierProperties(
            short handle,
            uint lower,
            uint upper,
            PS5000A_PULSE_WIDTH_TYPE type);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetPulseWidthQualifierConditions(
            short handle,
            [In] PS5000A_CONDITION[] conditions,
            short nConditions,
            PS5000A_CONDITIONS_INFO info);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetPulseWidthQualifierDirections(
            short handle,
            [In] PS5000A_DIRECTION[] directions,
            short nDirections);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aIsTriggerOrPulseWidthQualifierEnabled(
            short handle,
            out short triggerEnabled,
            out short pulseWidthQualifierEnabled);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetTriggerTimeOffset(
            short handle,
            out uint timeUpper,
            out uint timeLower,
            out PS5000A_TIME_UNITS timeUnits,
            uint segmentIndex);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetTriggerTimeOffset64(
            short handle,
            out long time,
            out PS5000A_TIME_UNITS timeUnits,
            uint segmentIndex);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetValuesTriggerTimeOffsetBulk(
            short handle,
            [Out] uint[] timesUpper,
            [Out] uint[] timesLower,
            [Out] PS5000A_TIME_UNITS[] timeUnits,
            uint fromSegmentIndex,
            uint toSegmentIndex);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetValuesTriggerTimeOffsetBulk64(
            short handle,
            [Out] long[] times,
            [Out] PS5000A_TIME_UNITS[] timeUnits,
            uint fromSegmentIndex,
            uint toSegmentIndex);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetDataBuffers(
            short handle,
            PS5000A_CHANNEL source,
            short[] bufferMax,
            short[] bufferMin,
            int bufferLth,
            uint segmentIndex,
            PS5000A_RATIO_MODE mode);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetDataBuffer(
            short handle,
            PS5000A_CHANNEL source,
            short[] buffer,
            int bufferLth,
            uint segmentIndex,
            PS5000A_RATIO_MODE mode);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetUnscaledDataBuffers(
            short handle,
            PS5000A_CHANNEL source,
            byte[] bufferMax,
            byte[] bufferMin,
            int bufferLth,
            uint segmentIndex,
            PS5000A_RATIO_MODE mode);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetEtsTimeBuffer(
            short handle,
            long[] buffer,
            int bufferLth);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetEtsTimeBuffers(
            short handle,
            uint[] timeUpper,
            uint[] timeLower,
            int bufferLth);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aIsReady(
            short handle,
            out short ready);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aRunBlock(
            short handle,
            int noOfPreTriggerSamples,
            int noOfPostTriggerSamples,
            uint timebase,
            out int timeIndisposedMs,
            uint segmentIndex,
            ps5000aBlockReady lpReady,
            IntPtr pParameter);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aRunStreaming(
            short handle,
            out uint sampleInterval,
            PS5000A_TIME_UNITS sampleIntervalTimeUnits,
            uint maxPreTriggerSamples,
            uint maxPostTriggerSamples,
            short autoStop,
            uint downSampleRatio,
            PS5000A_RATIO_MODE downSampleRatioMode,
            uint overviewBufferSize);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetStreamingLatestValues(
            short handle,
            ps5000aStreamingReady lpPs5000aReady,
            IntPtr pParameter);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aNoOfStreamingValues(
            short handle,
            out uint noOfValues);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetMaxDownSampleRatio(
            short handle,
            uint noOfUnaggreatedSamples,
            out uint maxDownSampleRatio,
            PS5000A_RATIO_MODE downSampleRatioMode,
            uint segmentIndex);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetValues(
            short handle,
            uint startIndex,
            out uint noOfSamples,
            uint downSampleRatio,
            PS5000A_RATIO_MODE downSampleRatioMode,
            uint segmentIndex,
            short[] overflow);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetValuesAsync(
            short handle,
            uint startIndex,
            uint noOfSamples,
            uint downSampleRatio,
            PS5000A_RATIO_MODE downSampleRatioMode,
            uint segmentIndex,
            IntPtr lpDataReady,
            IntPtr pParameter);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetValuesBulk(
            short handle,
            out uint noOfSamples,
            uint fromSegmentIndex,
            uint toSegmentIndex,
            uint downSampleRatio,
            PS5000A_RATIO_MODE downSampleRatioMode,
            short[] overflow);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetValuesOverlapped(
            short handle,
            uint startIndex,
            out uint noOfSamples,
            uint downSampleRatio,
            PS5000A_RATIO_MODE downSampleRatioMode,
            uint segmentIndex,
            short[] overflow);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetValuesOverlappedBulk(
            short handle,
            uint startIndex,
            out uint noOfSamples,
            uint downSampleRatio,
            PS5000A_RATIO_MODE downSampleRatioMode,
            uint fromSegmentIndex,
            uint toSegmentIndex,
            short[] overflow);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aTriggerWithinPreTriggerSamples(
            short handle,
            PS5000A_TRIGGER_WITHIN_PRE_TRIGGER state);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetTriggerInfoBulk(
            short handle,
            [Out] PS5000A_TRIGGER_INFO[] triggerInfo,
            uint fromSegmentIndex,
            uint toSegmentIndex);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aEnumerateUnits(
            out short count,
            StringBuilder serials,
            out short serialLth);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetChannelInformation(
            short handle,
            PS5000A_CHANNEL_INFO info,
            int probe,
            [Out] int[] ranges,
            out int length,
            int channels);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aMaximumValue(
            short handle,
            out short value);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aMinimumValue(
            short handle,
            out short value);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetAnalogueOffset(
            short handle,
            PS5000A_RANGE range,
            PS5000A_COUPLING coupling,
            out float maximumVoltage,
            out float minimumVoltage);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetMaxSegments(short handle, out uint maxSegments);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aChangePowerSource(short handle, uint powerState);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aCurrentPowerSource(short handle);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aStop(short handle);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aPingUnit(short handle);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetNoOfCaptures(short handle, uint nCaptures);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetNoOfCaptures(short handle, out uint nCaptures);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetNoOfProcessedCaptures(short handle, out uint nProcessedCaptures);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetDeviceResolution(short handle, PS5000A_DEVICE_RESOLUTION resolution);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetDeviceResolution(short handle, out PS5000A_DEVICE_RESOLUTION resolution);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aQueryOutputEdgeDetect(short handle, out short state);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aSetOutputEdgeDetect(short handle, short state);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aGetScalingValues(
            short handle,
            [Out] PS5000A_SCALING_FACTORS_VALUES[] scalingValues,
            short nChannels);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aCheckForUpdate(
            short handle,
            out PICO_VERSION current,
            out PICO_VERSION update,
            out ushort updateRequired);

        [DllImport(PS5000A, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ps5000aStartFirmwareUpdate(
            short handle,
            PicoUpdateFirmwareProgress progress);
    }
}
