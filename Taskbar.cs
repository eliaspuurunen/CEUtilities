using System;
using System.Windows.Forms;

namespace CEUtilities
{
    public class Taskbar
    {
        public static int TaskbarHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;

        public static void HideTaskbar()
        {
            IntPtr handle;
            try
            {
                // Find the handle to the Start Bar
                handle = CoreDll.FindWindow("HHTaskBar", null);

                // If the handle is found then hide the start bar
                if (handle != IntPtr.Zero)
                {
                    // Hide the start bar
                    CoreDll.SetWindowPos(handle, 0, 0, 0, 0, 0, CoreDll.SWP.SWP_HIDEWINDOW);
                }
            }
            catch
            {
                MessageBox.Show("Could not hide Start Bar.");
            }
        }

        public static void UnhideTaskbar()
        {
            IntPtr handle;
            try
            {
                // Find the handle to the Start Bar
                handle = CoreDll.FindWindow("HHTaskBar", null);

                // If the handle is found then show the start bar
                if (handle != IntPtr.Zero)
                {
                    // Show the start bar
                    int screenWidth = CoreDll.GetSystemMetrics(CoreDll.SYSTEM_METRICS.SM_CXSCREEN);
                    CoreDll.SetWindowPos(handle, 0, 0, 0, screenWidth, TaskbarHeight, CoreDll.SWP.SWP_SHOWWINDOW);
                }
            }
            catch
            {
                MessageBox.Show("Could not show Start Bar.");
            }
        }


    }
}
