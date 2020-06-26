﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;

namespace NetworkMonitor
{
    class Network
    {
        static List<string> processNames;
        static List<string[]> netStatsResults;
        static List<Thread> threads;

        public static string[][] Usage()
        {
            processNames = new List<string>();
            netStatsResults = new List<string[]>();
            threads = new List<Thread>();
            
            foreach (Process proc in Process.GetProcesses())
            {
                try
                {
                    if (!processNames.Contains(proc.ProcessName))
                    {
                        processNames.Add(proc.ProcessName);
                    }
                }
                catch (Exception) { }
            }

            foreach (string name in processNames)
            {
                var thread = new Thread(delegate() { PopulateResult(name); });
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                while (thread.IsAlive) { }
                thread.Abort();
            }

            return netStatsResults.ToArray();
        }

        public static void PopulateResult(string name)
        {
            try
            {
                var result = ProcessNetworkStats.GetBytePerSecond(name);
                netStatsResults.Add(result);
            }
            catch (Exception) { }

        }

        public static long[] GetTotalNetworkBytes()
        {
            IPv4InterfaceStatistics netAdapterStats = NetworkInterface.GetAllNetworkInterfaces().Where(x => x.OperationalStatus == OperationalStatus.Up).Select(x => x.GetIPv4Statistics()).ToArray()[0];
            return new long[] { netAdapterStats.BytesReceived , netAdapterStats.BytesSent};
        }
    }
}
