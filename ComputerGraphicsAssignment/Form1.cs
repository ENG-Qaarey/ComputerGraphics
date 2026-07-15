using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ComputerGraphicsAssignment
{
    public partial class frmPolygonFilling : Form
    {
        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;
        private Pen edgePen;
        private List<Point> polygonPoints = new List<Point>();
        private List<Point> filledPixels = new List<Point>();
        private Point seedPoint = Point.Empty;
        private bool isDrawing = false;
        private bool isSeedMode = false;
        private bool polygonClosed = false;
        private Color fillColor = Color.DeepSkyBlue;
        private Color boundaryColor = Color.Black;
        private Color defaultColor = Color.White;
        private const int VERTEX_RADIUS = 4;
        private const int SEED_RADIUS = 6;
        private enum FillAlgorithm { ScanLine, BoundaryFill, FloodFill }
        private FillAlgorithm selectedAlgorithm = FillAlgorithm.ScanLine;
        private bool use8Connected = false;
        private bool isFilling = false;

        public frmPolygonFilling()
        {
            InitializeComponent();
            Load += Form1_Load;
            picCanvas.MouseClick += picCanvas_MouseClick;
            picCanvas.Paint += picCanvas_Paint;
            picCanvas.Resize += picCanvas_Resize;
            btnDrawPolygon.Click += btnDrawPolygon_Click;
            btnClosePolygon.Click += btnClosePolygon_Click;
            btnSeedPoint.Click += btnSeedPoint_Click;
            btnFillPolygon.Click += btnFillPolygon_Click;
            btnClear.Click += btnClear_Click;
            btnChooseColor.Click += btnChooseColor_Click;
            btnSaveImage.Click += btnSaveImage_Click;
            btnRandomPolygon.Click += btnRandomPolygon_Click;
            btnShowVertices.Click += btnShowVertices_Click;
            btnZoomIn.Click += btnZoomIn_Click;
            btnZoomOut.Click += btnZoomOut_Click;
            pnlFillColor.Click += pnlFillColor_Click;
            rbScanLine.CheckedChanged += rbScanLine_CheckedChanged;
            rbBoundaryFill.CheckedChanged += rbBoundaryFill_CheckedChanged;
            rbFloodFill.CheckedChanged += rbFloodFill_CheckedChanged;
            rb4Connected.CheckedChanged += rb4Connected_CheckedChanged;
            rb8Connected.CheckedChanged += rb8Connected_CheckedChanged;
            InitializeCanvas();
            SetupUI();
        }

        private void SetupUI()
        {
            pnlFillColor.BackColor = fillColor;
            btnChooseColor.BackColor = fillColor;
            btnClosePolygon.Enabled = false;
            btnClosePolygon.BackColor = SystemColors.Control;
            rbScanLine.Checked = true;
            rb4Connected.Checked = true;
            UpdateStatus("Ready. Draw a polygon or use random polygon.");
        }

        private void InitializeCanvas()
        {
            if (picCanvas.Width == 0 || picCanvas.Height == 0)
            { picCanvas.Width = 800; picCanvas.Height = 600; }
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);
            edgePen = new Pen(Color.Black, 2);
            picCanvas.Image = canvasBitmap;
            picCanvas.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (canvasBitmap == null) InitializeCanvas();
            UpdateStatus("Application loaded. Draw a polygon to begin.");
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= picCanvas.Width || e.Y < 0 || e.Y >= picCanvas.Height)
            { UpdateStatus("Click outside canvas bounds."); return; }

            if (isSeedMode)
            {
                seedPoint = new Point(e.X, e.Y);
                DrawSeedPoint(seedPoint);
                isSeedMode = false;
                btnSeedPoint.BackColor = SystemColors.Control;
                UpdateStatus($"Seed point set at ({e.X}, {e.Y})");
                return;
            }

            if (isDrawing && !polygonClosed)
            {
                polygonPoints.Add(new Point(e.X, e.Y));
                DrawVertex(e.X, e.Y);
                DrawEdges();
                UpdateStatus($"Added vertex {polygonPoints.Count} at ({e.X}, {e.Y})");

                if (polygonPoints.Count >= 3)
                {
                    btnClosePolygon.Enabled = true;
                    btnClosePolygon.BackColor = Color.LightGreen;
                    UpdateStatus($"Added vertex {polygonPoints.Count}. Click 'Close Polygon' to finish.");
                }
                else
                {
                    btnClosePolygon.Enabled = false;
                    btnClosePolygon.BackColor = SystemColors.Control;
                }
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (canvasBitmap != null) e.Graphics.DrawImage(canvasBitmap, 0, 0);

            foreach (var point in polygonPoints)
            {
                e.Graphics.FillEllipse(Brushes.Red, point.X - VERTEX_RADIUS, point.Y - VERTEX_RADIUS, VERTEX_RADIUS * 2, VERTEX_RADIUS * 2);
                e.Graphics.DrawEllipse(Pens.DarkRed, point.X - VERTEX_RADIUS, point.Y - VERTEX_RADIUS, VERTEX_RADIUS * 2, VERTEX_RADIUS * 2);
            }

            if (seedPoint != Point.Empty)
            {
                e.Graphics.FillEllipse(Brushes.LimeGreen, seedPoint.X - SEED_RADIUS, seedPoint.Y - SEED_RADIUS, SEED_RADIUS * 2, SEED_RADIUS * 2);
                e.Graphics.DrawEllipse(Pens.DarkGreen, seedPoint.X - SEED_RADIUS - 2, seedPoint.Y - SEED_RADIUS - 2, SEED_RADIUS * 2 + 4, SEED_RADIUS * 2 + 4);
                e.Graphics.DrawString("Seed", new Font("Arial", 8), Brushes.DarkGreen, seedPoint.X + 10, seedPoint.Y - 5);
            }
        }

        private void picCanvas_Resize(object sender, EventArgs e) { }

        private void DrawVertex(int x, int y) => picCanvas.Refresh();
        private void DrawSeedPoint(Point point) => picCanvas.Refresh();

        private void DrawEdges()
        {
            if (polygonPoints.Count < 2) return;
            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                for (int i = 0; i < polygonPoints.Count - 1; i++)
                    g.DrawLine(edgePen, polygonPoints[i], polygonPoints[i + 1]);
                if (polygonClosed && polygonPoints.Count >= 3)
                    g.DrawLine(edgePen, polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);
            }
            picCanvas.Refresh();
        }

        private void ClosePolygon()
        {
            if (polygonPoints.Count >= 3)
            {
                polygonClosed = true;
                isDrawing = false;
                DrawEdges();
                btnDrawPolygon.BackColor = SystemColors.Control;
                btnClosePolygon.Enabled = false;
                btnClosePolygon.BackColor = SystemColors.Control;
                UpdateStatus($"Polygon CLOSED with {polygonPoints.Count} vertices ✓");
            }
            else UpdateStatus("Polygon must have at least 3 vertices!");
        }

        private void RefreshCanvas()
        {
            if (canvasBitmap != null) canvasGraphics.Clear(Color.White);
            else
            {
                canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
                canvasGraphics = Graphics.FromImage(canvasBitmap);
                canvasGraphics.Clear(Color.White);
            }

            if (polygonPoints.Count > 0)
            {
                for (int i = 0; i < polygonPoints.Count - 1; i++)
                    canvasGraphics.DrawLine(edgePen, polygonPoints[i], polygonPoints[i + 1]);
                if (polygonClosed && polygonPoints.Count >= 3)
                    canvasGraphics.DrawLine(edgePen, polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);
                foreach (var pixel in filledPixels)
                    if (pixel.X >= 0 && pixel.X < canvasBitmap.Width && pixel.Y >= 0 && pixel.Y < canvasBitmap.Height)
                        canvasBitmap.SetPixel(pixel.X, pixel.Y, fillColor);
            }

            picCanvas.Image = canvasBitmap;
            picCanvas.Refresh();
        }

        private void btnDrawPolygon_Click(object sender, EventArgs e)
        {
            ClearAll();
            isDrawing = true;
            polygonClosed = false;
            btnDrawPolygon.BackColor = Color.LightGreen;
            btnClosePolygon.Enabled = false;
            btnClosePolygon.BackColor = SystemColors.Control;
            UpdateStatus("Click on canvas to add vertices. Click 'Close Polygon' when done.");
            picCanvas.Focus();
        }

        private void btnClosePolygon_Click(object sender, EventArgs e)
        {
            if (!isDrawing) { UpdateStatus("Not in drawing mode. Click 'Draw Polygon' first."); return; }
            ClosePolygon();
        }

        private void btnSeedPoint_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count < 3) { UpdateStatus("Please draw a polygon first!"); return; }
            if (!polygonClosed) { UpdateStatus("Please close the polygon first (Click 'Close Polygon')!"); return; }
            isSeedMode = true;
            btnSeedPoint.BackColor = Color.LightCoral;
            UpdateStatus("Click on canvas to set seed point inside the polygon.");
            picCanvas.Focus();
        }

        private void btnFillPolygon_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count < 3) { UpdateStatus("Please draw a polygon first! (at least 3 vertices)"); return; }
            if (!polygonClosed) { UpdateStatus("Please close the polygon first! (Click 'Close Polygon')"); return; }
            if (isFilling) return;
            isFilling = true;
            ClearFill();

            try
            {
                Point seed = seedPoint;
                if (seed == Point.Empty && selectedAlgorithm != FillAlgorithm.ScanLine)
                {
                    seed = GetPolygonCenter();
                    UpdateStatus($"Using polygon center as seed point at ({seed.X}, {seed.Y})");
                }

                if (selectedAlgorithm != FillAlgorithm.ScanLine)
                {
                    if (!IsPointInPolygon(seed))
                    {
                        UpdateStatus("WARNING: Seed point is outside the polygon! Using polygon center instead.");
                        seed = GetPolygonCenter();
                        if (!IsPointInPolygon(seed))
                        {
                            UpdateStatus("ERROR: Cannot find a valid seed point inside the polygon!");
                            isFilling = false;
                            return;
                        }
                        UpdateStatus($"Using polygon center at ({seed.X}, {seed.Y})");
                    }
                }

                switch (selectedAlgorithm)
                {
                    case FillAlgorithm.ScanLine: ScanLineFill(); break;
                    case FillAlgorithm.BoundaryFill:
                        if (use8Connected) BoundaryFill8(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                        else BoundaryFill4(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                        break;
                    case FillAlgorithm.FloodFill:
                        if (use8Connected) FloodFill8(seed.X, seed.Y, fillColor, defaultColor);
                        else FloodFill4(seed.X, seed.Y, fillColor, defaultColor);
                        break;
                }

                picCanvas.Refresh();
                UpdateStatus($"✓ Fill complete using {selectedAlgorithm}!");
            }
            catch (Exception ex) { UpdateStatus($"Error: {ex.Message}"); }
            finally { isFilling = false; }
        }

        private void btnClear_Click(object sender, EventArgs e) { ClearAll(); UpdateStatus("Canvas cleared."); }

        private void btnChooseColor_Click(object sender, EventArgs e) => PickFillColor();
        private void pnlFillColor_Click(object sender, EventArgs e) => PickFillColor();

        private void PickFillColor()
        {
            using (ColorDialog dlg = new ColorDialog { Color = fillColor })
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fillColor = dlg.Color;
                    btnChooseColor.BackColor = fillColor;
                    pnlFillColor.BackColor = fillColor;
                    UpdateStatus($"Fill color changed to {fillColor.Name}");
                }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog { Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp", Title = "Save Image", DefaultExt = "png" })
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    canvasBitmap.Save(dlg.FileName, GetImageFormat(dlg.FilterIndex));
                    UpdateStatus($"Image saved to {dlg.FileName}");
                }
        }

        private void btnRandomPolygon_Click(object sender, EventArgs e)
        {
            ClearAll();
            var rand = new Random();
            int n = rand.Next(5, 10), cx = picCanvas.Width / 2, cy = picCanvas.Height / 2;
            int r = Math.Min(picCanvas.Width, picCanvas.Height) / 3;
            for (int i = 0; i < n; i++)
            {
                double a = (2 * Math.PI * i) / n + rand.NextDouble() * 0.5;
                int x = cx + (int)(r * Math.Cos(a)) + rand.Next(-30, 30);
                int y = cy + (int)(r * Math.Sin(a)) + rand.Next(-30, 30);
                polygonPoints.Add(new Point(Math.Max(10, Math.Min(picCanvas.Width - 10, x)), Math.Max(10, Math.Min(picCanvas.Height - 10, y))));
            }
            polygonClosed = true;
            isDrawing = false;
            btnClosePolygon.Enabled = false;
            btnClosePolygon.BackColor = SystemColors.Control;
            RefreshCanvas();
            UpdateStatus($"Random polygon with {n} vertices created. ✓");
        }

        private void btnShowVertices_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count == 0) { UpdateStatus("No polygon to show vertices."); return; }

            var sb = new StringBuilder();
            sb.AppendLine("=====================================");
            sb.AppendLine("      POLYGON VERTICES");
            sb.AppendLine("=====================================");
            sb.AppendLine($"Total Vertices: {polygonPoints.Count}");
            sb.AppendLine(new string('-', 37));
            for (int i = 0; i < polygonPoints.Count; i++)
                sb.AppendLine($"Vertex {i + 1,2}: ({polygonPoints[i].X,3}, {polygonPoints[i].Y,3})");
            sb.AppendLine(new string('-', 37));
            sb.AppendLine(polygonClosed ? "Status: CLOSED ✓" : "Status: OPEN");
            sb.AppendLine("=====================================");
            MessageBox.Show(sb.ToString(), "Vertices Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            canvasBitmap = new Bitmap(canvasBitmap, (int)(canvasBitmap.Width * 1.2), (int)(canvasBitmap.Height * 1.2));
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            RefreshCanvas();
            UpdateStatus("Zoomed In");
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            int nw = (int)(canvasBitmap.Width * 0.8), nh = (int)(canvasBitmap.Height * 0.8);
            if (nw > 100 && nh > 100)
            {
                canvasBitmap = new Bitmap(canvasBitmap, nw, nh);
                canvasGraphics = Graphics.FromImage(canvasBitmap);
                RefreshCanvas();
                UpdateStatus("Zoomed Out");
            }
            else UpdateStatus("Cannot zoom out further");
        }

        private void FloodFill4(int x, int y, Color fill, Color defaultColor)
        {
            int fillArgb = fill.ToArgb();
            int defaultArgb = defaultColor.ToArgb();
            if (fillArgb == defaultArgb) return;
            if (x < 0 || x >= canvasBitmap.Width || y < 0 || y >= canvasBitmap.Height) return;

            int minX = Math.Max(0, polygonPoints.Min(pt => pt.X) - 2);
            int maxX = Math.Min(canvasBitmap.Width - 1, polygonPoints.Max(pt => pt.X) + 2);
            int minY = Math.Max(0, polygonPoints.Min(pt => pt.Y) - 2);
            int maxY = Math.Min(canvasBitmap.Height - 1, polygonPoints.Max(pt => pt.Y) + 2);
            if (x < minX || x > maxX || y < minY || y > maxY) return;

            var rect = new Rectangle(0, 0, canvasBitmap.Width, canvasBitmap.Height);
            var bmpData = canvasBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = bmpData.Stride / 4;
            int[] pixels = new int[stride * canvasBitmap.Height];
            Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);

            if (pixels[y * stride + x] != defaultArgb) { canvasBitmap.UnlockBits(bmpData); return; }

            var queue = new Queue<Point>();
            pixels[y * stride + x] = fillArgb;
            filledPixels.Add(new Point(x, y));
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                var dirs = new[] { new Point(p.X + 1, p.Y), new Point(p.X - 1, p.Y), new Point(p.X, p.Y + 1), new Point(p.X, p.Y - 1) };
                foreach (var n in dirs)
                {
                    if (n.X >= minX && n.X <= maxX && n.Y >= minY && n.Y <= maxY)
                    {
                        int idx = n.Y * stride + n.X;
                        if (pixels[idx] == defaultArgb && IsPointInPolygon(n))
                        {
                            pixels[idx] = fillArgb;
                            filledPixels.Add(n);
                            queue.Enqueue(n);
                        }
                    }
                }
            }

            Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
            canvasBitmap.UnlockBits(bmpData);
        }

        private void FloodFill8(int x, int y, Color fill, Color defaultColor)
        {
            int fillArgb = fill.ToArgb();
            int defaultArgb = defaultColor.ToArgb();
            if (fillArgb == defaultArgb) return;
            if (x < 0 || x >= canvasBitmap.Width || y < 0 || y >= canvasBitmap.Height) return;

            int minX = Math.Max(0, polygonPoints.Min(pt => pt.X) - 2);
            int maxX = Math.Min(canvasBitmap.Width - 1, polygonPoints.Max(pt => pt.X) + 2);
            int minY = Math.Max(0, polygonPoints.Min(pt => pt.Y) - 2);
            int maxY = Math.Min(canvasBitmap.Height - 1, polygonPoints.Max(pt => pt.Y) + 2);
            if (x < minX || x > maxX || y < minY || y > maxY) return;

            var rect = new Rectangle(0, 0, canvasBitmap.Width, canvasBitmap.Height);
            var bmpData = canvasBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = bmpData.Stride / 4;
            int[] pixels = new int[stride * canvasBitmap.Height];
            Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);

            if (pixels[y * stride + x] != defaultArgb) { canvasBitmap.UnlockBits(bmpData); return; }

            var queue = new Queue<Point>();
            pixels[y * stride + x] = fillArgb;
            filledPixels.Add(new Point(x, y));
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                var dirs = new[]
                {
                    new Point(p.X + 1, p.Y), new Point(p.X - 1, p.Y), new Point(p.X, p.Y + 1), new Point(p.X, p.Y - 1),
                    new Point(p.X + 1, p.Y + 1), new Point(p.X + 1, p.Y - 1), new Point(p.X - 1, p.Y + 1), new Point(p.X - 1, p.Y - 1)
                };
                foreach (var n in dirs)
                {
                    if (n.X >= minX && n.X <= maxX && n.Y >= minY && n.Y <= maxY)
                    {
                        int idx = n.Y * stride + n.X;
                        if (pixels[idx] == defaultArgb && IsPointInPolygon(n))
                        {
                            pixels[idx] = fillArgb;
                            filledPixels.Add(n);
                            queue.Enqueue(n);
                        }
                    }
                }
            }

            Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
            canvasBitmap.UnlockBits(bmpData);
        }

        private void BoundaryFill4(int x, int y, Color fill, Color boundary, Color defaultColor)
        {
            int fillArgb = fill.ToArgb();
            int boundaryArgb = boundary.ToArgb();
            if (x < 0 || x >= canvasBitmap.Width || y < 0 || y >= canvasBitmap.Height) return;

            int minX = Math.Max(0, polygonPoints.Min(pt => pt.X) - 2);
            int maxX = Math.Min(canvasBitmap.Width - 1, polygonPoints.Max(pt => pt.X) + 2);
            int minY = Math.Max(0, polygonPoints.Min(pt => pt.Y) - 2);
            int maxY = Math.Min(canvasBitmap.Height - 1, polygonPoints.Max(pt => pt.Y) + 2);
            if (x < minX || x > maxX || y < minY || y > maxY) return;

            var rect = new Rectangle(0, 0, canvasBitmap.Width, canvasBitmap.Height);
            var bmpData = canvasBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = bmpData.Stride / 4;
            int[] pixels = new int[stride * canvasBitmap.Height];
            Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);

            int sc = pixels[y * stride + x];
            if (sc == boundaryArgb || sc == fillArgb) { canvasBitmap.UnlockBits(bmpData); return; }

            var queue = new Queue<Point>();
            pixels[y * stride + x] = fillArgb;
            filledPixels.Add(new Point(x, y));
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                var dirs = new[] { new Point(p.X + 1, p.Y), new Point(p.X - 1, p.Y), new Point(p.X, p.Y + 1), new Point(p.X, p.Y - 1) };
                foreach (var n in dirs)
                {
                    if (n.X >= minX && n.X <= maxX && n.Y >= minY && n.Y <= maxY)
                    {
                        int idx = n.Y * stride + n.X;
                        int c = pixels[idx];
                        if (c != boundaryArgb && c != fillArgb && IsPointInPolygon(n))
                        {
                            pixels[idx] = fillArgb;
                            filledPixels.Add(n);
                            queue.Enqueue(n);
                        }
                    }
                }
            }

            Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
            canvasBitmap.UnlockBits(bmpData);
        }

        private void BoundaryFill8(int x, int y, Color fill, Color boundary, Color defaultColor)
        {
            int fillArgb = fill.ToArgb();
            int boundaryArgb = boundary.ToArgb();
            if (x < 0 || x >= canvasBitmap.Width || y < 0 || y >= canvasBitmap.Height) return;

            int minX = Math.Max(0, polygonPoints.Min(pt => pt.X) - 2);
            int maxX = Math.Min(canvasBitmap.Width - 1, polygonPoints.Max(pt => pt.X) + 2);
            int minY = Math.Max(0, polygonPoints.Min(pt => pt.Y) - 2);
            int maxY = Math.Min(canvasBitmap.Height - 1, polygonPoints.Max(pt => pt.Y) + 2);
            if (x < minX || x > maxX || y < minY || y > maxY) return;

            var rect = new Rectangle(0, 0, canvasBitmap.Width, canvasBitmap.Height);
            var bmpData = canvasBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = bmpData.Stride / 4;
            int[] pixels = new int[stride * canvasBitmap.Height];
            Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);

            int sc = pixels[y * stride + x];
            if (sc == boundaryArgb || sc == fillArgb) { canvasBitmap.UnlockBits(bmpData); return; }

            var queue = new Queue<Point>();
            pixels[y * stride + x] = fillArgb;
            filledPixels.Add(new Point(x, y));
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                var dirs = new[]
                {
                    new Point(p.X + 1, p.Y), new Point(p.X - 1, p.Y), new Point(p.X, p.Y + 1), new Point(p.X, p.Y - 1),
                    new Point(p.X + 1, p.Y + 1), new Point(p.X + 1, p.Y - 1), new Point(p.X - 1, p.Y + 1), new Point(p.X - 1, p.Y - 1)
                };
                foreach (var n in dirs)
                {
                    if (n.X >= minX && n.X <= maxX && n.Y >= minY && n.Y <= maxY)
                    {
                        int idx = n.Y * stride + n.X;
                        int c = pixels[idx];
                        if (c != boundaryArgb && c != fillArgb && IsPointInPolygon(n))
                        {
                            pixels[idx] = fillArgb;
                            filledPixels.Add(n);
                            queue.Enqueue(n);
                        }
                    }
                }
            }

            Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
            canvasBitmap.UnlockBits(bmpData);
        }

        private void ScanLineFill()
        {
            if (polygonPoints.Count < 3) return;
            int minY = polygonPoints.Min(p => p.Y);
            int maxY = polygonPoints.Max(p => p.Y);
            int filledCount = 0;

            for (int y = minY; y <= maxY; y++)
            {
                var xs = new List<int>();
                for (int i = 0; i < polygonPoints.Count; i++)
                {
                    var p1 = polygonPoints[i];
                    var p2 = polygonPoints[(i + 1) % polygonPoints.Count];
                    if ((p1.Y > y && p2.Y <= y) || (p1.Y <= y && p2.Y > y))
                    {
                        double x = p1.X + (double)(y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y);
                        xs.Add((int)Math.Round(x));
                    }
                }
                xs.Sort();
                for (int i = 0; i < xs.Count - 1; i += 2)
                {
                    int x0 = Math.Min(xs[i], xs[i + 1]), x1 = Math.Max(xs[i], xs[i + 1]);
                    for (int x = x0; x <= x1; x++)
                        if (x >= 0 && x < canvasBitmap.Width && y >= 0 && y < canvasBitmap.Height)
                        {
                            canvasBitmap.SetPixel(x, y, fillColor);
                            filledPixels.Add(new Point(x, y));
                            filledCount++;
                        }
                }
            }

            UpdateStatus($"Scan Line Fill complete. {filledCount} pixels filled.");
        }

        private void ClearAll()
        {
            polygonPoints.Clear();
            filledPixels.Clear();
            seedPoint = Point.Empty;
            polygonClosed = false;
            isDrawing = false;
            isSeedMode = false;

            if (canvasGraphics != null)
            {
                canvasGraphics.Clear(Color.White);
                picCanvas.Image = canvasBitmap;
                picCanvas.Refresh();
            }

            btnDrawPolygon.BackColor = SystemColors.Control;
            btnSeedPoint.BackColor = SystemColors.Control;
            btnClosePolygon.Enabled = false;
            btnClosePolygon.BackColor = SystemColors.Control;
            UpdateStatus("Cleared all.");
        }

        private void ClearFill()
        {
            foreach (var pixel in filledPixels)
                if (pixel.X >= 0 && pixel.X < canvasBitmap.Width && pixel.Y >= 0 && pixel.Y < canvasBitmap.Height)
                    canvasBitmap.SetPixel(pixel.X, pixel.Y, Color.White);
            filledPixels.Clear();
            picCanvas.Refresh();
        }

        private Point GetPolygonCenter()
        {
            if (polygonPoints.Count == 0) return Point.Empty;
            int x = 0, y = 0;
            foreach (var p in polygonPoints) { x += p.X; y += p.Y; }
            return new Point(x / polygonPoints.Count, y / polygonPoints.Count);
        }

        private bool IsPointInPolygon(Point point)
        {
            int crossings = 0, n = polygonPoints.Count;
            for (int i = 0; i < n; i++)
            {
                var p1 = polygonPoints[i];
                var p2 = polygonPoints[(i + 1) % n];
                if ((p1.Y > point.Y) != (p2.Y > point.Y))
                {
                    double xi = (point.Y - p1.Y) * (p2.X - p1.X) / (double)(p2.Y - p1.Y) + p1.X;
                    if (point.X < xi) crossings++;
                }
            }
            return crossings % 2 == 1;
        }

        private void UpdateStatus(string message) { if (lblStatus != null) lblStatus.Text = message; }

        private ImageFormat GetImageFormat(int fi) =>
            fi == 2 ? ImageFormat.Jpeg : fi == 3 ? ImageFormat.Bmp : ImageFormat.Png;

        private void rbScanLine_CheckedChanged(object sender, EventArgs e)
        { if ((sender as Guna.UI2.WinForms.Guna2RadioButton)?.Checked == true) { selectedAlgorithm = FillAlgorithm.ScanLine; UpdateStatus("Scan Line Fill selected."); } }

        private void rbBoundaryFill_CheckedChanged(object sender, EventArgs e)
        { if ((sender as Guna.UI2.WinForms.Guna2RadioButton)?.Checked == true) { selectedAlgorithm = FillAlgorithm.BoundaryFill; UpdateStatus("Boundary Fill selected. Click inside polygon for seed."); } }

        private void rbFloodFill_CheckedChanged(object sender, EventArgs e)
        { if ((sender as Guna.UI2.WinForms.Guna2RadioButton)?.Checked == true) { selectedAlgorithm = FillAlgorithm.FloodFill; UpdateStatus("Flood Fill selected. Click inside polygon for seed."); } }

        private void rb4Connected_CheckedChanged(object sender, EventArgs e)
        { if ((sender as Guna.UI2.WinForms.Guna2RadioButton)?.Checked == true) { use8Connected = false; UpdateStatus("4-Connected mode selected."); } }

        private void rb8Connected_CheckedChanged(object sender, EventArgs e)
        { if ((sender as Guna.UI2.WinForms.Guna2RadioButton)?.Checked == true) { use8Connected = true; UpdateStatus("8-Connected mode selected."); } }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count < 3) { UpdateStatus("Please draw a polygon first!"); return; }
            if (!polygonClosed) { UpdateStatus("Please close the polygon first!"); return; }
            int tx, ty;
            if (!int.TryParse(numTx.Text, out tx) || !int.TryParse(numTy.Text, out ty))
            { UpdateStatus("Invalid tx or ty value!"); return; }
            TranslatePolygon(tx, ty);
        }

        private void TranslatePolygon(int tx, int ty)
        {
            bool wasFilled = filledPixels.Count > 0;
            if (seedPoint != Point.Empty) seedPoint = new Point(seedPoint.X + tx, seedPoint.Y + ty);

            var translated = new List<Point>();
            foreach (var p in polygonPoints) translated.Add(new Point(p.X + tx, p.Y + ty));
            polygonPoints = translated;

            ClearFill();
            RefreshCanvas();

            if (wasFilled)
            {
                isFilling = true;
                try
                {
                    Point seed = seedPoint;
                    if (seed == Point.Empty && selectedAlgorithm != FillAlgorithm.ScanLine)
                        seed = GetPolygonCenter();
                    if (selectedAlgorithm != FillAlgorithm.ScanLine && !IsPointInPolygon(seed))
                        seed = GetPolygonCenter();

                    switch (selectedAlgorithm)
                    {
                        case FillAlgorithm.ScanLine: ScanLineFill(); break;
                        case FillAlgorithm.BoundaryFill:
                            if (use8Connected) BoundaryFill8(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            else BoundaryFill4(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            break;
                        case FillAlgorithm.FloodFill:
                            if (use8Connected) FloodFill8(seed.X, seed.Y, fillColor, defaultColor);
                            else FloodFill4(seed.X, seed.Y, fillColor, defaultColor);
                            break;
                    }

                    picCanvas.Refresh();
                    UpdateStatus($"Polygon translated by ({tx}, {ty}) — fill preserved");
                }
                catch (Exception ex) { UpdateStatus($"Translation done but re-fill failed: {ex.Message}"); }
                finally { isFilling = false; }
            }
            else UpdateStatus($"Polygon translated by ({tx}, {ty})");
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count < 3) { UpdateStatus("Please draw a polygon first!"); return; }
            if (!polygonClosed) { UpdateStatus("Please close the polygon first!"); return; }
            if (!double.TryParse(guna2TextBox1.Text, out double angle))
            { UpdateStatus("Invalid angle value!"); return; }
            RotatePolygon(angle);
        }

        private void RotatePolygon(double angleDeg)
        {
            double θ = angleDeg * Math.PI / 180, cosθ = Math.Cos(θ), sinθ = Math.Sin(θ);
            Point center = GetPolygonCenter();
            bool wasFilled = filledPixels.Count > 0;

            var rotated = new List<Point>();
            foreach (var p in polygonPoints)
            {
                double dx = p.X - center.X, dy = p.Y - center.Y;
                rotated.Add(new Point((int)Math.Round(dx * cosθ - dy * sinθ + center.X), (int)Math.Round(dx * sinθ + dy * cosθ + center.Y)));
            }
            polygonPoints = rotated;

            if (wasFilled) seedPoint = GetPolygonCenter();
            ClearFill();
            RefreshCanvas();

            if (wasFilled)
            {
                isFilling = true;
                try
                {
                    Point seed = seedPoint;
                    if (selectedAlgorithm != FillAlgorithm.ScanLine && !IsPointInPolygon(seed))
                        seed = GetPolygonCenter();

                    switch (selectedAlgorithm)
                    {
                        case FillAlgorithm.ScanLine: ScanLineFill(); break;
                        case FillAlgorithm.BoundaryFill:
                            if (use8Connected) BoundaryFill8(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            else BoundaryFill4(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            break;
                        case FillAlgorithm.FloodFill:
                            if (use8Connected) FloodFill8(seed.X, seed.Y, fillColor, defaultColor);
                            else FloodFill4(seed.X, seed.Y, fillColor, defaultColor);
                            break;
                    }

                    picCanvas.Refresh();
                    UpdateStatus($"Polygon rotated by {angleDeg}° — fill preserved");
                }
                catch (Exception ex) { UpdateStatus($"Rotation done but re-fill failed: {ex.Message}"); }
                finally { isFilling = false; }
            }
            else UpdateStatus($"Polygon rotated by {angleDeg}°");
        }

        private void btnScale_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count < 3) { UpdateStatus("Please draw a polygon first!"); return; }
            if (!polygonClosed) { UpdateStatus("Please close the polygon first!"); return; }
            double sx, sy;
            if (!double.TryParse(numSy.Text, out sx) || !double.TryParse(numSy.Text, out sy))
            { UpdateStatus("Invalid sx or sy value!"); return; }
            if (sx <= 0 || sy <= 0) { UpdateStatus("Scale factors must be positive!"); return; }
            ScalePolygon(sx, sy);
        }

        private void ScalePolygon(double sx, double sy)
        {
            Point center = GetPolygonCenter();
            bool wasFilled = filledPixels.Count > 0;

            var scaled = new List<Point>();
            foreach (var p in polygonPoints)
            {
                double dx = p.X - center.X;
                double dy = p.Y - center.Y;
                scaled.Add(new Point(
                    (int)Math.Round(dx * sx + center.X),
                    (int)Math.Round(dy * sy + center.Y)));
            }
            polygonPoints = scaled;

            if (wasFilled) seedPoint = GetPolygonCenter();
            ClearFill();
            RefreshCanvas();

            if (wasFilled)
            {
                isFilling = true;
                try
                {
                    Point seed = seedPoint;
                    if (selectedAlgorithm != FillAlgorithm.ScanLine && !IsPointInPolygon(seed))
                        seed = GetPolygonCenter();

                    switch (selectedAlgorithm)
                    {
                        case FillAlgorithm.ScanLine: ScanLineFill(); break;
                        case FillAlgorithm.BoundaryFill:
                            if (use8Connected) BoundaryFill8(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            else BoundaryFill4(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            break;
                        case FillAlgorithm.FloodFill:
                            if (use8Connected) FloodFill8(seed.X, seed.Y, fillColor, defaultColor);
                            else FloodFill4(seed.X, seed.Y, fillColor, defaultColor);
                            break;
                    }

                    picCanvas.Refresh();
                    UpdateStatus($"Polygon scaled by ({sx}, {sy}) — fill preserved");
                }
                catch (Exception ex) { UpdateStatus($"Scaling done but re-fill failed: {ex.Message}"); }
                finally { isFilling = false; }
            }
            else UpdateStatus($"Polygon scaled by ({sx}, {sy})");
        }
    }
}
