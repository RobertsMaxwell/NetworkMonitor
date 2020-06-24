using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace NetworkMonitor
{
    static class ProcessNetworkStats
    {

        //returns the one second difference between read and write bytes, respectively, in an array
        public static string[] GetBytePerSecond(string process)
        {
            var firstRead = new PerformanceCounter("Process", "IO Read Bytes/sec", process).RawValue;
            var firstWrite = new PerformanceCounter("Process", "IO Write Bytes/sec", process).RawValue;
            Thread.Sleep(1000);
            var secondRead = new PerformanceCounter("Process", "IO Read Bytes/sec", process).RawValue;
            var secondWrite = new PerformanceCounter("Process", "IO Write Bytes/sec", process).RawValue;

            return new string[] { Convert.ToString(secondRead - firstRead), Convert.ToString(secondWrite - firstWrite), process };
        }
    }
}
