using System.Runtime.InteropServices;

namespace TrayBin
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SHQUERYRBINFO
    {
        public uint cbSize;
        public ulong i64Size;
        public uint i64ItemCount;
    }
}
