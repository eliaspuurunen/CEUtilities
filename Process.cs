using System;
using System.Runtime.InteropServices;

namespace CEUtilities
{
    public class Process
    {
        /// <summary>
        /// Immediately kills this process.
        /// </summary>
        public static void Suicide()
        {
            var proc = System.Diagnostics.Process.GetCurrentProcess();
            proc.Kill();
        }
    }

}
