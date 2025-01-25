namespace TrayBin.Externals
{
    [Flags]
    public enum SHERB : uint
    {
        SHERB_NOCONFIRMATION = 0x00000001, // Не запрашивать подтверждение
        SHERB_NOPROGRESSUI = 0x00000002, // Не показывать индикатор выполнения
        SHERB_NOSOUND =
            0x00000004 // Не воспроизводить звуковое уведомление
        ,
    }
}
