
namespace dqxEnthuse
{
    partial class FullWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FullWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FullWindow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FullWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FullWindow_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullWindow_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FullWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FullWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FullWindow_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}