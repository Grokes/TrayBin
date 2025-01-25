using System.Runtime.InteropServices;
using TrayBin.Externals;

namespace TrayBin
{
    public class ExternalApi
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SHQueryRecycleBin(
            string? pszRootPath,
            ref SHQUERYRBINFO pSHQueryRBInfo
        );

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern void SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, SHERB dwFlags);
    }
}