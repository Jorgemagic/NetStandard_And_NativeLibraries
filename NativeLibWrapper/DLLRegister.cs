using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NativeLibWrapper
{
    public static class DLLRegister
    {
        [DllImport("kernel32", SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        public static void RegisterNativePath()
        {
            string path = string.Empty;
            string currentValue = string.Empty;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                    path = Path.Combine("binaries", "win", Environment.Is64BitProcess ? "x64" : "x86");
                    SetDllDirectory(path);
                    break;               
            }
        }
    }
}
