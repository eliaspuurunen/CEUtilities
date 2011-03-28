using System;
using System.Runtime.InteropServices;

namespace CEUtilities
{
    /// <summary>
    /// Contains managed wrappers or implementations of coredll's structs, delegates,
    /// constants and PInvokes that are useful for this sample.
    ///
    /// See the documentation on MSDN for more information on the elements provided
    /// in this file.
    /// </summary>
    public sealed class CoreDll
    {
        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is IntPtr.Zero, GetDC retrieves the DC for the entire screen.</param>
        /// <returns>If the function succeeds, the return value is a handle to the DC for the specified window's client area. If the function fails, the return value is IntPtr.Zero.</returns>
        [DllImport("coredll.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// This function creates a logical brush that has the specified solid color. 
        /// </summary>
        /// <param name="crColor">Specifies the color of the brush. The format is 0x00bbggrr.</param>
        /// <returns>A handle that identifies a logical brush indicates success. IntPtr.Zero indicates failre.</returns>
        [DllImport("coredll.dll")]
        public static extern IntPtr CreateSolidBrush(uint crColor);

        /// <summary>
        /// This function selects an object into a specified device context. The new object replaces the previous object of the same type. 
        /// </summary>
        /// <param name="hdc">Handle to the device context.</param>
        /// <param name="hgdiobj">Handle to the object to be selected.</param>
        /// <returns>If the selected object is not a region, the handle of the object being replaced indicates success.</returns>
        [DllImport("coredll.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        /// <summary>
        /// This function draws a rectangle. The current pen outlines the rectangle and the current brush fills it.
        /// </summary>
        /// <param name="hdc">Handle to the device context.</param>
        /// <param name="nLeftRet">Specifies the logical x-coordinate of the upper left corner of the rectangle. </param>
        /// <param name="nTopRect">Specifies the logical y-coordinate of the upper left corner of the rectangle. </param>
        /// <param name="nRightRect">Specifies the logical x-coordinate of the lower right corner of the rectangle. </param>
        /// <param name="nBottomRect">Specifies the logical y-coordinate of the lower right corner of the rectangle. </param>
        /// <returns>Nonzero indicates success. Zero indicates failure.</returns>
        [DllImport("coredll.dll")]
        public static extern Boolean Rectangle(IntPtr hdc, int nLeftRet, int nTopRect, int nRightRect, int nBottomRect);

        /// <summary>
        /// This function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. After the object is deleted, the specified handle is no longer valid.
        /// </summary>
        /// <param name="hObject">Handle to a logical pen, brush, font, bitmap, region, or palette. </param>
        /// <returns>True indicates success, false otherwise.</returns>
        [DllImport("coredll.dll")]
        public static extern Boolean DeleteObject(IntPtr hObject);

        /// <summary>
        /// This function releases a device context (DC), freeing it for use by other applications. The effect of ReleaseDC depends on the type of device context. 
        /// </summary>
        /// <param name="hWnd">Handle to the window whose device context is to be released.</param>
        /// <param name="hDC">Handle to the device context to be released.</param>
        /// <returns>True indicates success, false otherwise.</returns>
        [DllImport("coredll.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// This function adds a rectangle to the specified window's update region. The update region represents the portion of the window's client area that must be redrawn.
        /// </summary>
        /// <param name="hWnd">Handle to the window whose update region has changed.
        /// If you pass a NULL value for this parameter InvalidateRect takes no action and returns FALSE.</param>
        /// <param name="lpRect">Pointer to a RECT structure that contains the client coordinates of the rectangle to be added to the update region. If this parameter is NULL, the entire client area is added to the update region.</param>
        /// <param name="bErase">Boolean that specifies whether the background within the update region is to be erased when the update region is processed. </param>
        /// <returns>Returns true on success, false otherwise.</returns>
        [DllImport("coredll.dll")]
        public static extern Boolean InvalidateRect(IntPtr hWnd, IntPtr lpRect, Boolean bErase);

        /// <summary>
        /// Retrieves the window handle to the active window attached to the calling thread's message queue. 
        /// </summary>
        /// <returns>The return value is the handle to the active window attached to the calling thread's message queue. Otherwise, the return value is IntPtr.Zero.</returns>
        /// <remarks>Note that this method appears to return IntPtr.Zero if you call it from a background thread.</remarks>
        [DllImport("coredll.dll")]
        public static extern IntPtr GetActiveWindow();

        /// <summary>
        /// This function retrieves the dimensions — widths and heights — of Windows display elements and system configuration settings. All dimensions retrieved by GetSystemMetrics are in pixels. The RAPI version is CeGetSystemMetrics (RAPI) for versions 2.0 and later.
        /// </summary>
        /// <param name="nIndex">Specifies the system metric or configuration setting to retrieve. All SM_CX* values are widths. All SM_CY* values are heights. </param>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        public static extern int GetSystemMetrics(SYSTEM_METRICS nIndex);

        [DllImport("CoreDll.dll", EntryPoint = "PlaySound", SetLastError = true)]
        public extern static int PlaySound(string szSound, IntPtr hMod, int flags);

        // Some of the following functions were totally ripped off of Nikolko's Craft blog:
        // http://nikolkos.blogspot.com/2008/03/trick-hide-taskbar-on-windows-mobile.html
        // The rest, I can't remember where. If it's originally your code, feel free
        // to add credits for yourself.

        [DllImport("aygshell.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SHFullScreen(IntPtr hwndRequester, SHFS dwState);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string _ClassName, string _WindowName);

        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hwnd, int hwnd2, int x, int y, int cx, int cy, SWP uFlags);

        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [Flags()]
        public enum SHFS
        {
            SHOWTASKBAR = 0x0001,
            HIDETASKBAR = 0x0002,
            SHOWSIPBUTTON = 0x0004,
            HIDESIPBUTTON = 0x0008,
            SHOWSTARTICON = 0x0010,
            HIDESTARTICON = 0x0020,
        }

        public enum SND
        {
            SYNC = 0x0000,
            ASYNC = 0x0001,
            NODEFAULT = 0x0002,
            MEMORY = 0x0004,
            LOOP = 0x0008,
            NOSTOP = 0x0010,
            NOWAIT = 0x00002000,
            ALIAS = 0x00010000,
            ALIAS_ID = 0x00110000,
            FILENAME = 0x00020000,
            RESOURCE = 0x00040004
        }
        
        [Flags()]
        public enum SWP
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_FRAMECHANGED = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040
        }

        public enum SYSTEM_METRICS : int
        {
            SM_CXSCREEN = 0,
            SM_CYSCREEN = 1,
            SM_CXVSCROLL = 2,
            SM_CYHSCROLL = 3,
            SM_CYCAPTION = 4,
            SM_CXBORDER = 5,
            SM_CYBORDER = 6,
            SM_CXDLGFRAME = 7,
            SM_CYDLGFRAME = 8,
            SM_CXICON = 11,
            SM_CYICON = 12,
            SM_CYMENU = 15,
            SM_CXFULLSCREEN = 16,
            SM_CYFULLSCREEN = 17,
            SM_MOUSEPRESENT = 19,
            SM_CYVSCROLL = 20,
            SM_CXHSCROLL = 21,
            SM_DEBUG = 22,
            SM_CXDOUBLECLK = 36,
            SM_CYDOUBLECLK = 37,
            SM_CXICONSPACING = 38,
            SM_CYICONSPACING = 39,
            SM_CXEDGE = 45,
            SM_CYEDGE = 46,
            SM_CXSMICON = 49,
            SM_CYSMICON = 50,
            SM_XVIRTUALSCREEN = 76,
            SM_YVIRTUALSCREEN = 77,
            SM_CXVIRTUALSCREEN = 78,
            SM_CYVIRTUALSCREEN = 79,
            SM_CMONITORS = 80,
            SM_SAMEDISPLAYFORMAT = 81,
            SM_CXFIXEDFRAME = 7,
            SM_CYFIXEDFRAME = 8
        }

    }
}
