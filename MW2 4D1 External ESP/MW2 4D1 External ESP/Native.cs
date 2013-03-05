using System;
using System.Runtime.InteropServices;

namespace MW2_4D1_External_ESP
{
    /// <summary>
    /// Managed functions from User32, Kernel32 & DwmAPI dlls as
    /// well as some structs from the mentioned dlls
    /// </summary>
    public class Native
    {
        #region Native functions
        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("Kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern uint GetWindowLong(IntPtr hWnd, int index);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int index, uint newStyle);

        [DllImport("Kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, UIntPtr dwSize, out UIntPtr lpNumberOfBytesRead);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ClientToScreen(IntPtr hWnd, out System.Drawing.Point lpPoint);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, [MarshalAs(UnmanagedType.Bool)] bool bRepaint);

        [DllImport("DwmAPI.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMargins);
        #endregion

        #region Constants
        public const uint PROCESS_VM_READ = 0x000010;

        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;

        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_MAXIMIZE = 0x01000000;

        public const uint WS_EX_TOPMOST = 0x8;
        public const uint WS_EX_LAYERED = 0x800000;
        public const uint WS_EX_TRANSPARENT = 0x20;

        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;
        #endregion

        #region Native structs
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;

            public static bool operator ==(RECT r1, RECT r2)
            {
                return r1.left == r2.left && r1.top == r2.top && r1.right == r2.right && r1.bottom == r2.bottom;
            }

            public static bool operator !=(RECT r1, RECT r2)
            {
                return r1.left != r2.left && r1.top != r2.top && r1.right != r2.right && r1.bottom != r2.bottom;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Margins
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }
        #endregion
    }
}
