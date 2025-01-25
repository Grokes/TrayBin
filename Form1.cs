namespace TrayBin;

public partial class Form1 : Form
{
    private NotifyIcon _trayIcon;
    private ContextMenuStrip _trayMenu;
    private System.Threading.Timer timer;
    private Bin _bin = new Bin();

    public Form1()
    {
        InitializeComponent();
        HideWindow();

        _trayIcon = new NotifyIcon();
        _trayIcon.Icon = new System.Drawing.Icon(_bin.PathImage);
        _trayIcon.Visible = true;
        _trayIcon.MouseMove += TrayIcon_MouseMove;
        _trayIcon.MouseClick += TrayIcon_MouseClick;
        _trayIcon.DoubleClick += _bin.OpenBin;

        _trayMenu = new ContextMenuStrip();
        _trayMenu.Items.Add("Открыть", null, _bin.OpenBin);
        _trayMenu.Items.Add("Очистить", null, _bin.CleanBin);
        _trayMenu.Items.Add(new ToolStripSeparator());
        _trayMenu.Items.Add("Закрыть", null, OnExit);
        _trayMenu.ShowImageMargin = false;

        _trayIcon.ContextMenuStrip = _trayMenu;

        timer = new System.Threading.Timer((state) => Update(), null, 0, 1000);
    }

    private void TrayIcon_MouseMove(object? sender, MouseEventArgs e)
    {
        _bin.UpdateInfo();
        _trayIcon.Text = _bin.TrashSize;
        _trayIcon.Icon = new System.Drawing.Icon(_bin.PathImage);
    }

    private void HideWindow()
    {
        this.WindowState = FormWindowState.Minimized;
        this.ShowInTaskbar = false;
        this.Hide();
    }

    private void TrayIcon_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            _trayMenu.Show(Control.MousePosition.X + 15, Control.MousePosition.Y - 90);
        }
        _trayIcon.Icon = new System.Drawing.Icon(_bin.PathImage);
    }

    new private void Update()
    {
        _bin.UpdateInfo();
        _trayIcon.Icon = new System.Drawing.Icon(_bin.PathImage);
    }

    private void OnExit(object? sender, EventArgs e)
    {
        _trayIcon.Visible = false;
        Application.Exit();
    }


}
