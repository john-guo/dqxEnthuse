using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Diagnostics;
using System.IO;

namespace dqxEnthuse
{
    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }

        public void ShowText(string text)
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate
                {
                    label1.Text = Translate(text);
                });
            }
            else
            {
                label1.Text = Translate(text);
            }
        }

        public string Translate(string text)
        {
            Clipboard.SetText(text);
            return text;
        }
    }
}
