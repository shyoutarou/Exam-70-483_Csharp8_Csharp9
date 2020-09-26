using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace C9_FunctionPointers
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class UnmanagedCallersOnlyAttribute : Attribute
    {
        public UnmanagedCallersOnlyAttribute() { }
        public Type[]? CallConvs;
        public string? EntryPoint;
    }

    class Program
    {
        private static void Callback(int i)
        {
            throw new NotImplementedException();
        }

        private delegate void CallbackDelegate(int i);
        private static CallbackDelegate s_callback = new CallbackDelegate(Callback);

        static void Main(string[] args)
        {
            IntPtr callback = Marshal.GetFunctionPointerForDelegate(s_callback);
            NativeFunctionWithCallback(callback);

            unsafe {
                // The extra cast is a temporary workaround for Preview 8. It won't be required in the final version.
                // The syntax will also be updated to use the 'unmanaged' keyword
                // delegate* unmanaged[Cdecl]<int, int> unmanagedPtr = &Callback;
                delegate* cdecl<int, int> unmanagedPtr = (delegate* cdecl<int, int>)(delegate*<int, int>)&CallbackPtr;
                NativeFunctionWithCallback(unmanagedPtr);

                //delegate*<int, void> f = &M;
            }
        }

        //static void M(int num) => Console.WriteLine("numero:" + num);




        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        public static int CallbackPtr(int i)
        {
            return 0;
            // ...
        }


    //    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    //    static extern uint GetShortPathName([MarshalAs(UnmanagedType.LPTStr)] string lpszLongPath,
    //[MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszShortPath, uint cchBuffer);

        [DllImport("NativeLib")]
        private static extern unsafe void NativeFunctionWithCallback(delegate* cdecl<int, int> unmanagedPtr);

        [DllImport("NativeLib")]
        private static extern void NativeFunctionWithCallback(IntPtr callback);
    }
}
