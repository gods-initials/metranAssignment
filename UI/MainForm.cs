using LongRunningTest;

namespace UI;
public partial class MainForm : Form
{
    private CancellationTokenSource cts;
    private Test currentTest;

    public MainForm()
    {
        InitializeComponent();
    }

    private async void btnStart_Click(object sender, EventArgs e)
    {

    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        
    }
}
