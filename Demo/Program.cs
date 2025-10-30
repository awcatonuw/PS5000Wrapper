using System;
using System.IO;
using Wrapper;

namespace Demo
{
    class Program
    {
        const int BUFFER_SIZE = 1024;
        static readonly string blockFile = "block.txt";
        
        static void Main(string[] args)
        {
            short handle = 0;
            short maxADCValue = 0;
            
            // Open device
            var status = ApiWrapper.ps5000aOpenUnit(out handle, null, ApiWrapper.PS5000A_DEVICE_RESOLUTION.PS5000A_DR_8BIT);
            if (status != 0)
            {
                Console.WriteLine($"Unable to open device, error code: 0x{status:X8}");
                return;
            }

            try
            {
                // Get max ADC value
                ApiWrapper.ps5000aMaximumValue(handle, out maxADCValue);

                // Configure channels (A & B)
                for (int i = 0; i < 2; i++)
                {
                    ApiWrapper.ps5000aSetChannel(
                        handle,
                        (ApiWrapper.PS5000A_CHANNEL)i,  // Channel A = 0, B = 1
                        1,                              // enabled
                        ApiWrapper.PS5000A_COUPLING.PS5000A_DC, // DC coupling
                        ApiWrapper.PS5000A_RANGE.PS5000A_1V,    // ±1V range
                        0.0f                            // no offset
                    );
                }

                Console.WriteLine("Collecting block data...");
                
                // Set up data buffers
                short[][] buffers = new short[4][];  // 2 channels * 2 buffers per channel
                for (int i = 0; i < 2; i++)
                {
                    buffers[i * 2] = new short[BUFFER_SIZE];
                    buffers[i * 2 + 1] = new short[BUFFER_SIZE];
                    ApiWrapper.ps5000aSetDataBuffers(
                        handle,
                        (ApiWrapper.PS5000A_CHANNEL)i,
                        buffers[i * 2],
                        buffers[i * 2 + 1],
                        BUFFER_SIZE,
                        0,
                        ApiWrapper.PS5000A_RATIO_MODE.PS5000A_RATIO_MODE_NONE
                    );
                }

                // Configure timebase
                int timeInterval;
                int maxSamples;
                ApiWrapper.ps5000aGetTimebase(handle, 8, BUFFER_SIZE, out timeInterval, out maxSamples, 0);

                // Start collection
                int timeIndisposedMs;
                ApiWrapper.ps5000aRunBlock(handle, 0, BUFFER_SIZE, 8, out timeIndisposedMs, 0, null, IntPtr.Zero);
                System.Threading.Thread.Sleep(100);

                // Get data
                uint sampleCount = (uint)BUFFER_SIZE;
                ApiWrapper.ps5000aGetValues(handle, 0, out sampleCount, 1, ApiWrapper.PS5000A_RATIO_MODE.PS5000A_RATIO_MODE_NONE, 0, null);

                // Save data to file
                using (StreamWriter writer = new StreamWriter(blockFile))
                {
                    writer.WriteLine("Block Data log\n");
                    for (int i = 0; i < sampleCount; i++)
                    {
                        for (int ch = 0; ch < 2; ch++)
                        {
                            int mV = (buffers[ch * 2][i] * 1000) / maxADCValue;  // Convert to mV
                            writer.Write($"{mV} ");
                        }
                        writer.WriteLine();
                    }
                }

                Console.WriteLine($"Done. Data saved to {blockFile}");
            }
            finally
            {
                // Stop and close device
                ApiWrapper.ps5000aStop(handle);
                ApiWrapper.ps5000aCloseUnit(handle);
            }
        }
    }
}
