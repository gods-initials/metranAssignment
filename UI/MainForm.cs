using LongRunningTest;
using System.Threading;
using System;
using System.Windows.Forms;

namespace UI
{
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
            string productId = txtProductId.Text.Trim();
            if (string.IsNullOrEmpty(productId))
            {
                MessageBox.Show("Введите идентификатор изделия.");
                return;
            }
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "Статус: выполняется тест";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}