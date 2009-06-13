using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MrJack
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool createdNew = true;
            using(Mutex mutex = new Mutex(true, "Mr.JackOnline", out createdNew)) {
                //if(createdNew) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
                //} else {
                //    Process current = Process.GetCurrentProcess();
                //    foreach(Process process in Process.GetProcessesByName(current.ProcessName)) {
                //        if(process.Id != current.Id) {
                //            SetForegroundWindow(process.MainWindowHandle);
                //            ShowWindowAsync(process.MainWindowHandle, SW_RESTORE);
                //            break;
                //        }
                //    }
                //}
            }
        }
    }
}