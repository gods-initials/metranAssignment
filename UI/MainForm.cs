using LongRunningTest;
using System.Threading;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace UI
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cts = null;
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
            switch (cmbTests.SelectedIndex)
            {
                case 0:
                    currentTest = new TestOneOut();
                    break;
                case 1:
                    currentTest = new TestTwoOut();
                    break;
                case 2:
                    currentTest = new TestThreeOut();
                    break;
            }
            cts = new CancellationTokenSource();
            try
            {
                await Task.Run(() => currentTest.Run(), cts.Token);
                Dictionary<string, string> results = currentTest.ReturnResults();
                using (StreamWriter outputFile = new StreamWriter($"{productId}.txt"))
                {
                    if (results["testSuccessful"] == "True")
                    {
                        foreach (string key in results.Keys.Skip(2))
                        {
                            outputFile.WriteLine($"{key}: {results[key]}");
                        }
                    }
                    else if (results["testSuccessful"] == "False")
                    {
                        outputFile.WriteLine($"error: {results["error"]}");
                    }
                    lblStatus.Text = "Статус: тест завершён. Результаты сохранены.";
                }
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Статус: выполнение теста приостановлено";
            }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                cts = null;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            if (cts != null)
            {
                cts.Cancel();
            }
        }
    }
}