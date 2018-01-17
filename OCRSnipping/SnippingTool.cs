using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCRSnipping
{
    public partial class SnippingTool : Form
    {
        public Image Image { get; set; }

        private Rectangle rcSelect = new Rectangle();
        private Rectangle rcScaleSelect = new Rectangle();
        private Point pntStart;
        private Point scaleStart;
        private static int widthOfResolution = 1920;
        private static int heightOfResolution = 1080;
        private static double widthOfScreen = Screen.PrimaryScreen.Bounds.Width;
        private static double heightOfScreen = Screen.PrimaryScreen.Bounds.Height;
        private double coW;
        private double coH;


        public SnippingTool(Image screenShot)
        {
            InitializeComponent();
            this.BackgroundImage = screenShot;
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;

            coW = widthOfResolution / widthOfScreen;
            coH = heightOfResolution / heightOfScreen;
            Console.WriteLine(widthOfResolution + " " + heightOfResolution);
            Console.WriteLine(widthOfScreen + " " + heightOfScreen);
            Console.WriteLine(coW + " " + coH);
        }

        public static Image Snip()
        {
            var rc = Screen.PrimaryScreen.Bounds;

            Bitmap bmp = new Bitmap(widthOfResolution, heightOfResolution);

            using (Graphics gr = Graphics.FromImage(bmp))
                gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            var snipper = new SnippingTool(bmp);

            if (snipper.ShowDialog() == DialogResult.OK)
            {
                return snipper.Image;
            }

            return null;
        }



        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Start the snip on mouse down
            if (e.Button != MouseButtons.Left) return;
            pntStart = e.Location;

            scaleStart = new Point((int)(pntStart.X * coW), (int)(pntStart.Y * coH));
            rcSelect = new Rectangle(pntStart, new Size(0, 0));
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Modify the selection on mouse move
            if (e.Button != MouseButtons.Left) return;
            int x1 = Math.Min(e.X, pntStart.X);
            int y1 = Math.Min(e.Y, pntStart.Y);
            int x2 = Math.Max(e.X, pntStart.X);
            int y2 = Math.Max(e.Y, pntStart.Y);

            int sx1 = (int)Math.Min(e.X * coW, pntStart.X * coW);
            int sy1 = (int)Math.Min(e.Y * coH, pntStart.Y * coH);
            int sx2 = (int)Math.Max(e.X * coW, pntStart.X * coW);
            int sy2 = (int)Math.Max(e.Y * coH, pntStart.Y * coH);

            rcSelect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            rcScaleSelect = new Rectangle(sx1, sy1, sx2 - sx1, sy2 - sy1);
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Complete the snip on mouse-up
            if (rcSelect.Width <= 0 || rcSelect.Height <= 0) return;
            Image = new Bitmap(rcScaleSelect.Width, rcScaleSelect.Height);
            using (Graphics gr = Graphics.FromImage(Image))
            {
                gr.DrawImage(this.BackgroundImage, new Rectangle(0, 0, Image.Width, Image.Height),
                    rcScaleSelect, GraphicsUnit.Pixel);
            }
            DialogResult = DialogResult.OK;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the current selection
            using (Brush br = new SolidBrush(Color.FromArgb(120, Color.White)))
            {
                int x1 = rcSelect.X; int x2 = rcSelect.X + rcSelect.Width;
                int y1 = rcSelect.Y; int y2 = rcSelect.Y + rcSelect.Height;
                e.Graphics.FillRectangle(br, new Rectangle(0, 0, x1, this.Height));
                e.Graphics.FillRectangle(br, new Rectangle(x2, 0, this.Width - x2, this.Height));
                e.Graphics.FillRectangle(br, new Rectangle(x1, 0, x2 - x1, y1));
                e.Graphics.FillRectangle(br, new Rectangle(x1, y2, x2 - x1, this.Height - y2));
            }
            using (Pen pen = new Pen(Color.Red, 3))
            {
                e.Graphics.DrawRectangle(pen, rcSelect);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Allow canceling the snip with the Escape key
            if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
