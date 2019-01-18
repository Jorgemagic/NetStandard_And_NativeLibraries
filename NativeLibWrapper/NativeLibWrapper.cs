using System;
using System.Runtime.InteropServices;

namespace NativeLibWrapper
{
    public static class NativeLibWrapper
    {
        static NativeLibWrapper()
        {
            DLLRegister.RegisterNativePath();
        }

        [DllImport("NativeLib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Sum([In] int number1, [In] int number2, out int result);
    }
}
