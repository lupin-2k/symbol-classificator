using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SymbolClassificator
{
    public partial class SymbolClassificator : Form
    {
        public SymbolClassificator()
        {
            InitializeComponent();
        }
        //
        [DllImport("mlp.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Predict(int[] matrix);

        [DllImport("mlp.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void LoadModel([MarshalAs(UnmanagedType.LPStr)] string filePath);


        const int targetSize = 28;
        const double countThreshold = 0.3;
        private Point lastPoint;
        private bool isDrawing = false;
        private Bitmap handwritingBmp;
        private Graphics bitmapGraphics;
        private bool eraseCheck = false;
        private bool drawCheck = false;
        private int[] matrixToVector;
        private int prediction = 0;
        private string modelPath;


        private void SymbolClassificator_Load(object sender, EventArgs e)
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            modelPath = System.IO.Path.Combine(exeDirectory, "model_weights.txt");

            handwritingBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(handwritingBmp))
            {
                g.Clear(Color.White);
            }
            bitmapGraphics = Graphics.FromImage(handwritingBmp);
            bitmapGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pictureBox1.Image = handwritingBmp;
            matrixToVector = new int[targetSize * targetSize];
        }
        private void submitButton_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (handwritingBmp != null)
            {
                using (Graphics g = Graphics.FromImage(handwritingBmp))
                {
                    g.Clear(Color.White);
                }
                pictureBox1.Invalidate();
            }
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            int[] blockCounts = new int[targetSize * targetSize];
            int blockwidth = pictureBox1.Width / targetSize;
            int blockheight = pictureBox1.Height / targetSize;
            int prediction = 0;
            for (int y = 0; y < pictureBox1.Height; y++)
            {
                for (int x = 0; x < pictureBox1.Width; x++)
                {
                    Color pixelColor = handwritingBmp.GetPixel(x, y);
                    if (pixelColor.R < 128)
                    {
                        int targetX = x / blockwidth;
                        int targetY = y / blockheight;
                        int targetIndex = (targetY * targetSize) + targetX;
                        blockCounts[targetIndex]++;
                    }
                }
            }
            int totalBlockPixels = blockwidth * blockheight;
            double threshold = countThreshold * totalBlockPixels;

            for (int i = 0; i < matrixToVector.Length; i++)
            {
                if (blockCounts[i] >= threshold) matrixToVector[i] = 1;
                else matrixToVector[i] = 0;
            }
            LoadModel(modelPath);
            prediction = Predict(matrixToVector);
            toolStripTextBox1.Text = ShowClass(prediction);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if (eraseCheck == true) eraseCheck = false;
            if (drawCheck == false) { drawCheck = true; return; }
            else drawCheck = false;
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            if (drawCheck == true) drawCheck = false;
            if (eraseCheck == false) { eraseCheck = true; return; }
            else eraseCheck = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            bool draw = (drawCheck == true);
            bool erase = (eraseCheck == true);
            if (isDrawing && (draw || erase))
            {
                if (draw)
                {
                    using (Pen drawingPen = new Pen(Color.Black, 24))
                    {
                        drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        drawingPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        bitmapGraphics.DrawLine(drawingPen, lastPoint, e.Location);
                    }
                    lastPoint = e.Location;
                    pictureBox1.Invalidate();
                }
                else
                {
                    using (Pen drawingPen = new Pen(Color.White, 40))
                    {
                        drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        drawingPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        bitmapGraphics.DrawLine(drawingPen, lastPoint, e.Location);
                    }
                    lastPoint = e.Location;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private string ShowClass(int index)
        {
            if (index >= 0 && index <= 9)
            {
                return index.ToString();
            }
            if (index >= 10 && index <= 35)
            {
                return ((char)('A' + (index - 10))).ToString();
            }
            if (index >= 36 && index <= 61)
            {
                return ((char)('a' + (index - 36))).ToString();
            }
            return "?";
        }
    }
}
