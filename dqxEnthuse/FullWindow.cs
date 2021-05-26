using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace dqxEnthuse
{
    public partial class FullWindow : Form
    {
        Bitmap image;
        Mat mat;
        MatExpr zeros;
        int isProcessing = 0;
        System.Drawing.Point p1;
        System.Drawing.Point p2;
        Form _parent;
        public Rectangle Rect { get; private set; }
        public Mat Target { get; private set; }

        public FullWindow(Form parent)
        {
            _parent = parent;
            InitializeComponent();
            Bounds = Screen.PrimaryScreen.Bounds;
            Opacity = 0;

            image = new Bitmap(Size.Width, Size.Height);
            var g = Graphics.FromImage(image);
            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.Location, System.Drawing.Point.Empty, Size);
            mat = image.ToMat();
            zeros = Mat.Zeros(mat.Rows, mat.Cols, mat.Type());
        }

        private void FullWindow_Paint(object sender, PaintEventArgs e)
        {
            Mat m = new Mat();
            Cv2.AddWeighted(mat, 0.7, zeros, 0.3, 0, m);
            e.Graphics.DrawImage(m.ToBitmap(), Location);
            if (isProcessing == 2)
            {
                Rect = new Rectangle(p1, new System.Drawing.Size(p2.X - p1.X, p2.Y - p1.Y));
                e.Graphics.DrawImage(image, Rect, Rect, GraphicsUnit.Pixel);
            }
            Opacity = 100;
        }

        private void FullWindow_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            isProcessing = 1;
        }

        private void FullWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (isProcessing == 0)
                return;

            p2 = e.Location;
            isProcessing = 2;
            Invalidate();
        }

        private void FullWindow_MouseUp(object sender, MouseEventArgs e)
        {
            isProcessing = 0;
            var rowStart = Math.Min(Rect.Location.Y, Rect.Location.Y + Rect.Size.Height);
            var rowEnd = Math.Max(Rect.Location.Y, Rect.Location.Y + Rect.Size.Height);
            var colStart = Math.Min(Rect.Location.X, Rect.Location.X + Rect.Size.Width);
            var colEnd = Math.Max(Rect.Location.X, Rect.Location.X + Rect.Size.Width);

            if (rowStart == rowEnd || colStart == colEnd)
                return;

            Rect = new Rectangle(colStart, rowStart, Math.Abs(Rect.Width), Math.Abs(Rect.Height));
            Target = mat[rowStart, rowEnd, colStart, colEnd];

            if (_parent != null)
                _parent.WindowState = FormWindowState.Normal;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FullWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void FullWindow_Load(object sender, EventArgs e)
        {
            Activate();
        }
    }
}
