using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TrayBin
{
    public class Bin
    {
        private SHQUERYRBINFO _info;
        private const ulong MAX_SIZE = (ulong)Bytes.GB * 5;
        public string TrashSize
        {
            get
            {
                string result = "";
                switch (_info.i64Size)
                {
                    case > (ulong)Bytes.GB:
                        result = $"{_info.i64Size / (ulong)Bytes.GB} GB\n";
                        break;
                    case > (ulong)Bytes.MB:
                        result = $"{_info.i64Size / (ulong)Bytes.MB} MB\n";
                        break;
                    case > (ulong)Bytes.KB:
                        result = $"{_info.i64Size / (ulong)Bytes.KB} KB\n";
                        break;
                    default:
                        result = $"{_info.i64Size} bytes\n";
                        break;
                }
                result += $"{_info.i64ItemCount} files";
                return result;
            }
        }

        public string PathImage
        {
            get
            {
                switch (_info.i64Size / (double)MAX_SIZE)
                {
                    case > 0.75:
                        return "img/full.ico";
                    case > 0.5:
                        return "img/75.ico";
                    case > 0.25:
                        return "img/50.ico";
                    case > 0:
                        return "img/25.ico";
                    case 0:
                    default:
                        return "img/empty.ico";
                }
            }
        }

        public Bin()
        {
            _info = new SHQUERYRBINFO();
            _info.cbSize = (uint)Marshal.SizeOf(typeof(SHQUERYRBINFO));
            UpdateInfo();
        }

        public void OpenBin(object? sender, EventArgs e)
        {
            Process.Start("explorer.exe", "shell:::{645FF040-5081-101B-9F08-00AA002F954E}");
            UpdateInfo();
        }

        public void CleanBin(object? sender, EventArgs e)
        {
            ExternalApi.SHEmptyRecycleBin(IntPtr.Zero, "", 0);
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            ExternalApi.SHQueryRecycleBin(null, ref _info);
        }
    }
}
