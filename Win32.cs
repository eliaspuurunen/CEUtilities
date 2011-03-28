using System;
using System.Runtime.InteropServices;

namespace CEUtilities
{
    /// <summary>
    /// Contains managed wrappers or implementations of Win32 structs, delegates,
    /// constants and PInvokes that are useful for this sample.
    ///
    /// See the documentation on MSDN for more information on the elements provided
    /// in this file.
    /// </summary>
    public sealed class Win32
    {
        /// <summary>
        /// A callback to a Win32 window procedure (wndproc)
        /// </summary>
        /// <param name="hwnd">The handle of the window receiving a message</param>
        /// <param name="msg">The message</param>
        /// <param name="wParam">The message's parameters (part 1)</param>
        /// <param name="lParam">The message's parameters (part 2)</param>
        /// <returns>A integer as described for the given message in MSDN</returns>
        public delegate int WndProc(IntPtr hwnd, uint msg, uint wParam, int lParam);

        [DllImport("coredll.dll")]
        public extern static int DefWindowProc(
            IntPtr hwnd, uint msg, uint wParam, int lParam);

        /// <summary>
        /// Retrieves information about the specified window. The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory. 
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs. </param>
        /// <param name="nIndex">The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra window memory, minus four; for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer. </param>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        public extern static IntPtr GetWindowLong(IntPtr hWnd, int nIndex);


        [DllImport("coredll.dll")]
        public extern static IntPtr SetWindowLong(
            IntPtr hwnd, int nIndex, IntPtr dwNewLong);

        public const int GWL_WNDPROC = -4;

        [DllImport("coredll.dll")]
        public extern static int CallWindowProc(
            IntPtr lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, int lParam);
    }
}
