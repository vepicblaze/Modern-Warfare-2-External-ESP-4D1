using System;
using System.Runtime.InteropServices;

namespace MW2_4D1_External_ESP
{
    public static class ProcessMemory
    {
        public static T Read<T>(IntPtr hProcess, IntPtr address) where T : struct
        {
            UIntPtr bytesRead;

            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
            Native.ReadProcessMemory(hProcess, address, buffer, (UIntPtr)buffer.Length, out bytesRead);

            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T value = (T)Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), typeof(T));
            gcHandle.Free();

            return value;
        }

        public static T[] ReadArray<T>(IntPtr hProcess, IntPtr address, int count, int size) where T : struct
        {
            UIntPtr bytesRead;

            byte[] buffer = new byte[size * count];
            Native.ReadProcessMemory(hProcess, address, buffer, (UIntPtr)buffer.Length, out bytesRead);

            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            IntPtr pinnedAddress = gcHandle.AddrOfPinnedObject();
            T[] array = new T[count];
            for (int i = 0; i < count; i++) {
                array[i] = (T)Marshal.PtrToStructure(pinnedAddress, typeof(T));
                pinnedAddress = (IntPtr)(pinnedAddress.ToInt64() + size);
            }
            gcHandle.Free();

            return array;
        }
    }
}
