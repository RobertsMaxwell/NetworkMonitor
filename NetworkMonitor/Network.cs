using System;
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
        static List<string> processNames = new List<string>();
        static List<string[]> netStatsResults = new List<string[]>();
        static List<Thread> threads = new List<Thread>();

        public static string[][] Usage()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                try
                {
                    if (!processNames.Contains(proc.ProcessName))
                    {
                        processNames.Add(proc.ProcessName);
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine("!\n" + e.Message + "\n!");
                }
            }

            foreach (string name in processNames)
            {
                var thread = new Thread(delegate() { PopulateResult(name); });
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                while (thread.IsAlive)
                {
                    Thread.Sleep(100);
                }
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
            
            Thread.CurrentThread.Abort();
        }
    }
}