using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Tesseract;
using F23.StringSimilarity;

namespace dqxEnthuse
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        bool ok = false;
        private TesseractEngine engine;

        private TextForm text1;
        private string prevText = string.Empty;

        public Form1()
        {
            InitializeComponent();
            engine = new TesseractEngine(@"./tessdata", "jpn", EngineMode.Default);
            text1 = new TextForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ok = true;
            WindowState = FormWindowState.Minimized;
        }

        private async void Form1_Resize(object sender, EventArgs e)
        {
            if (ok && WindowState == FormWindowState.Minimized)
            {
                ok = false;
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                await Task.Delay(500);
                var win = new FullWindow(this);
                if (win.ShowDialog() == DialogResult.Cancel)
                {
                    WindowState = FormWindowState.Normal;
                    return;
                }
                rect = win.Rect;
                await Task.Delay(500);
                text1.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap image = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(image);
            var levenshtein = new Levenshtein();
            while (!backgroundWorker1.CancellationPending)
            {
                try
                {
                    g.CopyFromScreen(rect.Location, System.Drawing.Point.Empty, rect.Size);

                    using (var page = engine.Process(image))
                    {
                        var confidence = page.GetMeanConfidence();
                        if (confidence > 0.5)
                        {
                            var text = page.GetText();
                            if (string.IsNullOrWhiteSpace(text))
                            {
                                Thread.Sleep(1000);
                                continue;
                            }

                            var ld = 1.0 - levenshtein.Distance(prevText, text) / Math.Max(prevText.Length, text.Length);
                            if (ld < 0.7)
                            {
                                prevText = text;
                                text = text.Replace(" ", "").Trim();
                                if (!string.IsNullOrWhiteSpace(text))
                                {
                                    text1.ShowText(text);
                                }
                            }

                            textBox1.Invoke((Action)delegate
                            {
                                textBox1.AppendText($"Mean confidence: {page.GetMeanConfidence()}  LD : {ld}  {Environment.NewLine}");
                                textBox1.AppendText($"Text: {text} {Environment.NewLine}");
                            });
                        }
                    }

                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
