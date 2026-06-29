using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerGraphicsAssignment
{
    public partial class frmPolygonFilling : Form
    {
        // Canvas properties
        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;
        private Pen edgePen;

        // Polygon data
        private List<Point> polygonPoints = new List<Point>();
        private List<Point> filledPixels = new List<Point>();
        private Point seedPoint = Point.Empty;
        private bool isDrawing = false;
        private bool isSeedMode = false;
        private bool polygonClosed = false;

        // Colors
        private Color fillColor = Color.DeepSkyBlue;
        private Color boundaryColor = Color.Black;
        private Color defaultColor = Color.White;

        // Constants
        private const int VERTEX_RADIUS = 4;
        private const int SEED_RADIUS = 6;

        // Algorithm selection
        private enum FillAlgorithm { ScanLine, BoundaryFill, FloodFill }
        private FillAlgorithm selectedAlgorithm = FillAlgorithm.ScanLine;
        private bool use8Connected = false;
        private bool isFilling = false;

        public frmPolygonFilling()
        {
            InitializeComponent();

            // Subscribe to events
            this.Load += Form1_Load;
            this.picCanvas.MouseClick += picCanvas_MouseClick;
            this.picCanvas.Paint += picCanvas_Paint;
            this.picCanvas.Resize += picCanvas_Resize;

            // Button events
            this.btnDrawPolygon.Click += btnDrawPolygon_Click;
            this.btnClosePolygon.Click += btnClosePolygon_Click;
            this.btnSeedPoint.Click += btnSeedPoint_Click;
            this.btnFillPolygon.Click += btnFillPolygon_Click;
            this.btnClear.Click += btnClear_Click;
            this.btnChooseColor.Click += btnChooseColor_Click;
            this.btnSaveImage.Click += btnSaveImage_Click;
            this.btnRandomPolygon.Click += btnRandomPolygon_Click;
            this.btnShowVertices.Click += btnShowVertices_Click;
            this.btnZoomIn.Click += btnZoomIn_Click;
            this.btnZoomOut.Click += btnZoomOut_Click;

            // Color panel click
            this.pnlFillColor.Click += pnlFillColor_Click;

            // Radio button events
            this.rbScanLine.CheckedChanged += rbScanLine_CheckedChanged;
            this.rbBoundaryFill.CheckedChanged += rbBoundaryFill_CheckedChanged;
            this.rbFloodFill.CheckedChanged += rbFloodFill_CheckedChanged;
            this.rb4Connected.CheckedChanged += rb4Connected_CheckedChanged;
            this.rb8Connected.CheckedChanged += rb8Connected_CheckedChanged;

            InitializeCanvas();
            SetupUI();
        }

        private void SetupUI()
        {
            pnlFillColor.BackColor = fillColor;
            btnChooseColor.BackColor = fillColor;
            btnClosePolygon.Enabled = false;
            btnClosePolygon.BackColor = SystemColors.Control;

            // Set default radio buttons
            rbScanLine.Checked = true;
            rb4Connected.Checked = true;

            UpdateStatus("Ready. Draw a polygon or use random polygon.");
        }

        private void InitializeCanvas()
        {
            if (picCanvas.Width == 0 || picCanvas.Height == 0)
            {
                picCanvas.Width = 800;
                picCanvas.Height = 600;
            }

            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);

            edgePen = new Pen(Color.Black, 2);

            picCanvas.Image = canvasBitmap;
            picCanvas.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (canvasBitmap == null)
            {
                InitializeCanvas();
            }
            UpdateStatus("Application loaded. Draw a polygon to begin.");
        }

        // ===================== CANVAS EVENTS =====================

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= picCanvas.Width || e.Y < 0 || e.Y >= picCanvas.Height)
            {
                UpdateStatus("Click outside canvas bounds.");
                return;
            }

            // Seed Point mode
            if (isSeedMode)
            {
                seedPoint = new Point(e.X, e.Y);
                DrawSeedPoint(seedPoint);
                isSeedMode = false;
                btnSeedPoint.BackColor = SystemColors.Control;
                UpdateStatus($"Seed point set at ({e.X}, {e.Y})");
                return;
            }

            // Drawing mode
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
            if (canvasBitmap != null)
            {
                e.Graphics.DrawImage(canvasBitmap, 0, 0);
            }

            // Draw vertices dynamically on top
            foreach (var point in polygonPoints)
            {
                e.Graphics.FillEllipse(Brushes.Red, point.X - VERTEX_RADIUS, point.Y - VERTEX_RADIUS,
                                          VERTEX_RADIUS * 2, VERTEX_RADIUS * 2);
                e.Graphics.DrawEllipse(Pens.DarkRed, point.X - VERTEX_RADIUS, point.Y - VERTEX_RADIUS,
                                          VERTEX_RADIUS * 2, VERTEX_RADIUS * 2);
            }

            // Draw seed point dynamically on top
            if (seedPoint != Point.Empty)
            {
                e.Graphics.FillEllipse(Brushes.LimeGreen, seedPoint.X - SEED_RADIUS, seedPoint.Y - SEED_RADIUS,
                                          SEED_RADIUS * 2, SEED_RADIUS * 2);
                e.Graphics.DrawEllipse(Pens.DarkGreen, seedPoint.X - SEED_RADIUS - 2, seedPoint.Y - SEED_RADIUS - 2,
                                          SEED_RADIUS * 2 + 4, SEED_RADIUS * 2 + 4);
                e.Graphics.DrawString("Seed", new Font("Arial", 8), Brushes.DarkGreen, seedPoint.X + 10, seedPoint.Y - 5);
            }
        }

        private void picCanvas_Resize(object sender, EventArgs e)
        {
            // Handle resize if needed
        }

        // ===================== DRAWING METHODS =====================

        private void DrawVertex(int x, int y)
        {
            // We draw vertices dynamically in the Paint event to avoid corrupting the canvas bitmap
            picCanvas.Refresh();
        }

        private void DrawEdges()
        {
            if (polygonPoints.Count < 2) return;

            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                // Draw all edges
                for (int i = 0; i < polygonPoints.Count - 1; i++)
                {
                    g.DrawLine(edgePen, polygonPoints[i], polygonPoints[i + 1]);
                }

                // If polygon is closed, draw closing edge
                if (polygonClosed && polygonPoints.Count >= 3)
                {
                    g.DrawLine(edgePen, polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);
                }
            }
            picCanvas.Refresh();
        }

        private void DrawSeedPoint(Point point)
        {
            // We draw the seed point dynamically in the Paint event to avoid corrupting the canvas bitmap
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
            else
            {
                UpdateStatus("Polygon must have at least 3 vertices!");
            }
        }

        private void RefreshCanvas()
        {
            if (canvasBitmap != null)
            {
                canvasGraphics.Clear(Color.White);
            }
            else
            {
                canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
                canvasGraphics = Graphics.FromImage(canvasBitmap);
                canvasGraphics.Clear(Color.White);
            }

            if (polygonPoints.Count > 0)
            {
                // Draw edges
                for (int i = 0; i < polygonPoints.Count - 1; i++)
                {
                    canvasGraphics.DrawLine(edgePen, polygonPoints[i], polygonPoints[i + 1]);
                }

                if (polygonClosed && polygonPoints.Count >= 3)
                {
                    canvasGraphics.DrawLine(edgePen, polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);
                }

                // Draw filled pixels
                if (filledPixels.Count > 0)
                {
                    foreach (var pixel in filledPixels)
                    {
                        if (pixel.X >= 0 && pixel.X < canvasBitmap.Width &&
                            pixel.Y >= 0 && pixel.Y < canvasBitmap.Height)
                        {
                            canvasBitmap.SetPixel(pixel.X, pixel.Y, fillColor);
                        }
                    }
                }
            }

            picCanvas.Image = canvasBitmap;
            picCanvas.Refresh();
        }

        // ===================== BUTTON EVENTS =====================

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
            if (!isDrawing)
            {
                UpdateStatus("Not in drawing mode. Click 'Draw Polygon' first.");
                return;
            }
            ClosePolygon();
        }

        private void btnSeedPoint_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count < 3)
            {
                UpdateStatus("Please draw a polygon first!");
                return;
            }

            if (!polygonClosed)
            {
                UpdateStatus("Please close the polygon first (Click 'Close Polygon')!");
                return;
            }

            isSeedMode = true;
            btnSeedPoint.BackColor = Color.LightCoral;
            UpdateStatus("Click on canvas to set seed point inside the polygon.");
            picCanvas.Focus();
        }

        private void btnFillPolygon_Click(object sender, EventArgs e)
        {
            // Check if polygon exists and is closed
            if (polygonPoints.Count < 3)
            {
                UpdateStatus("Please draw a polygon first! (at least 3 vertices)");
                return;
            }

            if (!polygonClosed)
            {
                UpdateStatus("Please close the polygon first! (Click 'Close Polygon')");
                return;
            }

            // Prevent multiple fills at once
            if (isFilling) return;
            isFilling = true;

            // Clear previous fill
            ClearFill();

            try
            {
                // For Boundary Fill and Flood Fill, we need a seed point
                Point seed = seedPoint;
                if (seed == Point.Empty && selectedAlgorithm != FillAlgorithm.ScanLine)
                {
                    seed = GetPolygonCenter();
                    UpdateStatus($"Using polygon center as seed point at ({seed.X}, {seed.Y})");
                }

                // Check if seed is inside polygon (for Boundary Fill and Flood Fill)
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

                // Execute selected algorithm
                switch (selectedAlgorithm)
                {
                    case FillAlgorithm.ScanLine:
                        ScanLineFill();
                        break;
                    case FillAlgorithm.BoundaryFill:
                        if (use8Connected)
                            BoundaryFill8(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                        else
                            BoundaryFill4(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                        break;
                    case FillAlgorithm.FloodFill:
                        if (use8Connected)
                            FloodFill8(seed.X, seed.Y, fillColor, defaultColor);
                        else
                            FloodFill4(seed.X, seed.Y, fillColor, defaultColor);
                        break;
                }

                picCanvas.Refresh();
                UpdateStatus($"✓ Fill complete using {selectedAlgorithm}!");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: {ex.Message}");
            }
            finally
            {
                isFilling = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            UpdateStatus("Canvas cleared.");
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = fillColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    fillColor = colorDialog.Color;
                    btnChooseColor.BackColor = fillColor;
                    pnlFillColor.BackColor = fillColor;
                    UpdateStatus($"Fill color changed to {fillColor.Name}");
                }
            }
        }

        private void pnlFillColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = fillColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    fillColor = colorDialog.Color;
                    btnChooseColor.BackColor = fillColor;
                    pnlFillColor.BackColor = fillColor;
                    UpdateStatus($"Fill color changed to {fillColor.Name}");
                }
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveDialog.Title = "Save Image";
                saveDialog.DefaultExt = "png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    canvasBitmap.Save(saveDialog.FileName, GetImageFormat(saveDialog.FilterIndex));
                    UpdateStatus($"Image saved to {saveDialog.FileName}");
                }
            }
        }

        private void btnRandomPolygon_Click(object sender, EventArgs e)
        {
            ClearAll();
            Random rand = new Random();
            int numVertices = rand.Next(5, 10);
            int centerX = picCanvas.Width / 2;
            int centerY = picCanvas.Height / 2;
            int radius = Math.Min(picCanvas.Width, picCanvas.Height) / 3;

            for (int i = 0; i < numVertices; i++)
            {
                double angle = (2 * Math.PI * i) / numVertices + rand.NextDouble() * 0.5;
                int x = centerX + (int)(radius * Math.Cos(angle)) + rand.Next(-30, 30);
                int y = centerY + (int)(radius * Math.Sin(angle)) + rand.Next(-30, 30);
                polygonPoints.Add(new Point(Math.Max(10, Math.Min(picCanvas.Width - 10, x)),
                                            Math.Max(10, Math.Min(picCanvas.Height - 10, y))));
            }

            polygonClosed = true;
            isDrawing = false;
            btnClosePolygon.Enabled = false;
            btnClosePolygon.BackColor = SystemColors.Control;
            RefreshCanvas();
            UpdateStatus($"Random polygon with {numVertices} vertices created. ✓");
        }

        private void btnShowVertices_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count == 0)
            {
                UpdateStatus("No polygon to show vertices.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=====================================");
            sb.AppendLine("      POLYGON VERTICES");
            sb.AppendLine("=====================================");
            sb.AppendLine($"Total Vertices: {polygonPoints.Count}");
            sb.AppendLine(new string('-', 37));
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                sb.AppendLine($"Vertex {i + 1,2}: ({polygonPoints[i].X,3}, {polygonPoints[i].Y,3})");
            }
            sb.AppendLine(new string('-', 37));

            if (polygonClosed)
                sb.AppendLine("Status: CLOSED ✓");
            else
                sb.AppendLine("Status: OPEN");

            sb.AppendLine("=====================================");

            MessageBox.Show(sb.ToString(), "Vertices Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            int newWidth = (int)(canvasBitmap.Width * 1.2);
            int newHeight = (int)(canvasBitmap.Height * 1.2);
            Bitmap scaled = new Bitmap(canvasBitmap, newWidth, newHeight);
            canvasBitmap = scaled;
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            RefreshCanvas();
            UpdateStatus("Zoomed In");
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            int newWidth = (int)(canvasBitmap.Width * 0.8);
            int newHeight = (int)(canvasBitmap.Height * 0.8);
            if (newWidth > 100 && newHeight > 100)
            {
                Bitmap scaled = new Bitmap(canvasBitmap, newWidth, newHeight);
                canvasBitmap = scaled;
                canvasGraphics = Graphics.FromImage(canvasBitmap);
                RefreshCanvas();
                UpdateStatus("Zoomed Out");
            }
            else
            {
                UpdateStatus("Cannot zoom out further");
            }
        }

        // Flood Fill 4-Connected - Extremely fast with LockBits and bounded to the polygon's bounding box
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
            var bmpData = canvasBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int stride = bmpData.Stride / 4;
            int[] pixels = new int[stride * canvasBitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);

            if (pixels[y * stride + x] != defaultArgb)
            {
                canvasBitmap.UnlockBits(bmpData);
                return;
            }

            Queue<Point> queue = new Queue<Point>();
            pixels[y * stride + x] = fillArgb;
            filledPixels.Add(new Point(x, y));
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                Point p = queue.Dequeue();

                Point[] neighbors = {
                    new Point(p.X + 1, p.Y),
                    new Point(p.X - 1, p.Y),
                    new Point(p.X, p.Y + 1),
                    new Point(p.X, p.Y - 1)
                };

                foreach (var n in neighbors)
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

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
            canvasBitmap.UnlockBits(bmpData);
        }

        // Flood Fill 8-Connected - Extremely fast with LockBits and bounded to the polygon's bounding box
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
            var bmpData = canvasBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int stride = bmpData.Stride / 4;
            int[] pixels = new int[stride * canvasBitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);

            if (pixels[y * stride + x] != defaultArgb)
            {
                canvasBitmap.UnlockBits(bmpData);
                return;
            }

            Queue<Point> queue = new Queue<Point>();
            pixels[y * stride + x] = fillArgb;
            filledPixels.Add(new Point(x, y));
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                Point p = queue.Dequeue();

                Point[] neighbors = {
                    new Point(p.X + 1, p.Y),
                    new Point(p.X - 1, p.Y),
                    new Point(p.X, p.Y + 1),
                    new Point(p.X, p.Y - 1),
                    new Point(p.X + 1, p.Y + 1),
                    new Point(p.X + 1, p.Y - 1),
                    new Point(p.X - 1, p.Y + 1),
                    new Point(p.X - 1, p.Y - 1)
                };

                foreach (var n in neighbors)
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

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
            canvasBitmap.UnlockBits(bmpData);
        }

        // Boundary Fill 4-Connected - Extremely fast with LockBits and bounded to the polygon's bounding box
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
            var bmpData = canvasBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int stride = bmpData.Stride / 4;
            int[] pixels = new int[stride * canvasBitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);

            int startColor = pixels[y * stride + x];
            if (startColor == boundaryArgb || startColor == fillArgb)
            {
                canvasBitmap.UnlockBits(bmpData);
                return;
            }

            Queue<Point> queue = new Queue<Point>();
            pixels[y * stride + x] = fillArgb;
            filledPixels.Add(new Point(x, y));
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                Point p = queue.Dequeue();

                Point[] neighbors = {
                    new Point(p.X + 1, p.Y),
                    new Point(p.X - 1, p.Y),
                    new Point(p.X, p.Y + 1),
                    new Point(p.X, p.Y - 1)
                };

                foreach (var n in neighbors)
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

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
            canvasBitmap.UnlockBits(bmpData);
        }

        // Boundary Fill 8-Connected - Extremely fast with LockBits and bounded to the polygon's bounding box
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
            var bmpData = canvasBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int stride = bmpData.Stride / 4;
            int[] pixels = new int[stride * canvasBitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);

            int startColor = pixels[y * stride + x];
            if (startColor == boundaryArgb || startColor == fillArgb)
            {
                canvasBitmap.UnlockBits(bmpData);
                return;
            }

            Queue<Point> queue = new Queue<Point>();
            pixels[y * stride + x] = fillArgb;
            filledPixels.Add(new Point(x, y));
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                Point p = queue.Dequeue();

                Point[] neighbors = {
                    new Point(p.X + 1, p.Y),
                    new Point(p.X - 1, p.Y),
                    new Point(p.X, p.Y + 1),
                    new Point(p.X, p.Y - 1),
                    new Point(p.X + 1, p.Y + 1),
                    new Point(p.X + 1, p.Y - 1),
                    new Point(p.X - 1, p.Y + 1),
                    new Point(p.X - 1, p.Y - 1)
                };

                foreach (var n in neighbors)
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

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
            canvasBitmap.UnlockBits(bmpData);
        }

        // ===================== SCAN LINE FILL ALGORITHM =====================

        private void ScanLineFill()
        {
            if (polygonPoints.Count < 3) return;

            // Find min and max Y
            int minY = polygonPoints.Min(p => p.Y);
            int maxY = polygonPoints.Max(p => p.Y);

            int filledCount = 0;

            for (int y = minY; y <= maxY; y++)
            {
                List<int> intersections = new List<int>();

                for (int i = 0; i < polygonPoints.Count; i++)
                {
                    Point p1 = polygonPoints[i];
                    Point p2 = polygonPoints[(i + 1) % polygonPoints.Count];

                    // Check if edge intersects scan line
                    if ((p1.Y > y && p2.Y <= y) || (p1.Y <= y && p2.Y > y))
                    {
                        // Calculate intersection point
                        double x = p1.X + (double)(y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y);
                        intersections.Add((int)Math.Round(x));
                    }
                }

                // Sort intersections
                intersections.Sort();

                // Fill between pairs
                for (int i = 0; i < intersections.Count - 1; i += 2)
                {
                    int xStart = intersections[i];
                    int xEnd = intersections[i + 1];

                    if (xStart > xEnd)
                    {
                        int temp = xStart;
                        xStart = xEnd;
                        xEnd = temp;
                    }

                    for (int x = xStart; x <= xEnd; x++)
                    {
                        if (x >= 0 && x < canvasBitmap.Width && y >= 0 && y < canvasBitmap.Height)
                        {
                            canvasBitmap.SetPixel(x, y, fillColor);
                            filledPixels.Add(new Point(x, y));
                            filledCount++;
                        }
                    }
                }
            }

            UpdateStatus($"Scan Line Fill complete. {filledCount} pixels filled.");
        }

        // ===================== HELPER METHODS =====================

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
            {
                if (pixel.X >= 0 && pixel.X < canvasBitmap.Width &&
                    pixel.Y >= 0 && pixel.Y < canvasBitmap.Height)
                {
                    canvasBitmap.SetPixel(pixel.X, pixel.Y, Color.White);
                }
            }
            filledPixels.Clear();
            picCanvas.Refresh();
        }

        private Point GetPolygonCenter()
        {
            if (polygonPoints.Count == 0) return Point.Empty;
            int x = 0, y = 0;
            foreach (Point p in polygonPoints)
            {
                x += p.X;
                y += p.Y;
            }
            return new Point(x / polygonPoints.Count, y / polygonPoints.Count);
        }

        private bool IsPointInPolygon(Point point)
        {
            int crossings = 0;
            int n = polygonPoints.Count;

            for (int i = 0; i < n; i++)
            {
                Point p1 = polygonPoints[i];
                Point p2 = polygonPoints[(i + 1) % n];

                if ((p1.Y > point.Y) != (p2.Y > point.Y))
                {
                    double xIntersection = (point.Y - p1.Y) * (p2.X - p1.X) / (double)(p2.Y - p1.Y) + p1.X;
                    if (point.X < xIntersection)
                        crossings++;
                }
            }

            return crossings % 2 == 1;
        }

        private void UpdateStatus(string message)
        {
            if (lblStatus != null)
            {
                lblStatus.Text = message;
            }
        }

        private ImageFormat GetImageFormat(int filterIndex)
        {
            switch (filterIndex)
            {
                case 1: return ImageFormat.Png;
                case 2: return ImageFormat.Jpeg;
                case 3: return ImageFormat.Bmp;
                default: return ImageFormat.Png;
            }
        }

        // ===================== RADIO BUTTON EVENT HANDLERS =====================

        private void rbScanLine_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as Guna.UI2.WinForms.Guna2RadioButton;
            if (rb != null && rb.Checked)
            {
                selectedAlgorithm = FillAlgorithm.ScanLine;
                UpdateStatus("Scan Line Fill selected.");
            }
        }

        private void rbBoundaryFill_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as Guna.UI2.WinForms.Guna2RadioButton;
            if (rb != null && rb.Checked)
            {
                selectedAlgorithm = FillAlgorithm.BoundaryFill;
                UpdateStatus("Boundary Fill selected. Click inside polygon for seed.");
            }
        }

        private void rbFloodFill_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as Guna.UI2.WinForms.Guna2RadioButton;
            if (rb != null && rb.Checked)
            {
                selectedAlgorithm = FillAlgorithm.FloodFill;
                UpdateStatus("Flood Fill selected. Click inside polygon for seed.");
            }
        }

        private void rb4Connected_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as Guna.UI2.WinForms.Guna2RadioButton;
            if (rb != null && rb.Checked)
            {
                use8Connected = false;
                UpdateStatus("4-Connected mode selected.");
            }
        }

        private void rb8Connected_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as Guna.UI2.WinForms.Guna2RadioButton;
            if (rb != null && rb.Checked)
            {
                use8Connected = true;
                UpdateStatus("8-Connected mode selected.");
            }
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count < 3)
            {
                UpdateStatus("Please draw a polygon first!");
                return;
            }

            if (!polygonClosed)
            {
                UpdateStatus("Please close the polygon first!");
                return;
            }

            int tx, ty;
            if (!int.TryParse(numTx.Text, out tx) || !int.TryParse(numTy.Text, out ty))
            {
                UpdateStatus("Invalid tx or ty value!");
                return;
            }

            TranslatePolygon(tx, ty);
        }

        private void TranslatePolygon(int tx, int ty)
        {
            bool wasFilled = filledPixels.Count > 0;
            Point oldSeed = seedPoint;

            // Translate seed point if it existed
            if (oldSeed != Point.Empty)
                seedPoint = new Point(oldSeed.X + tx, oldSeed.Y + ty);

            // Translate vertices
            List<Point> translated = new List<Point>();
            foreach (Point p in polygonPoints)
                translated.Add(new Point(p.X + tx, p.Y + ty));
            polygonPoints = translated;

            // Clear old fill and redraw edges at new position
            ClearFill();
            RefreshCanvas();

            // Re-fill if polygon was filled before translation
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
                        case FillAlgorithm.ScanLine:
                            ScanLineFill();
                            break;
                        case FillAlgorithm.BoundaryFill:
                            if (use8Connected)
                                BoundaryFill8(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            else
                                BoundaryFill4(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            break;
                        case FillAlgorithm.FloodFill:
                            if (use8Connected)
                                FloodFill8(seed.X, seed.Y, fillColor, defaultColor);
                            else
                                FloodFill4(seed.X, seed.Y, fillColor, defaultColor);
                            break;
                    }

                    picCanvas.Refresh();
                    UpdateStatus($"Polygon translated by ({tx}, {ty}) — fill preserved");
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Translation done but re-fill failed: {ex.Message}");
                }
                finally
                {
                    isFilling = false;
                }
            }
            else
            {
                UpdateStatus($"Polygon translated by ({tx}, {ty})");
            }
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (polygonPoints.Count < 3)
            {
                UpdateStatus("Please draw a polygon first!");
                return;
            }

            if (!polygonClosed)
            {
                UpdateStatus("Please close the polygon first!");
                return;
            }

            double angle;
            if (!double.TryParse(guna2TextBox1.Text, out angle))
            {
                UpdateStatus("Invalid angle value!");
                return;
            }

            RotatePolygon(angle);
        }

        private void RotatePolygon(double angleDeg)
        {
            Point center = GetPolygonCenter();
            double θ = angleDeg * Math.PI / 180;
            double cosθ = Math.Cos(θ);
            double sinθ = Math.Sin(θ);

            bool wasFilled = filledPixels.Count > 0;

            List<Point> rotated = new List<Point>();
            foreach (Point p in polygonPoints)
            {
                // Translate to origin (relative to center)
                double dx = p.X - center.X;
                double dy = p.Y - center.Y;

                // Rotate around origin
                double xNew = dx * cosθ - dy * sinθ;
                double yNew = dx * sinθ + dy * cosθ;

                // Translate back to center
                rotated.Add(new Point((int)Math.Round(xNew + center.X), (int)Math.Round(yNew + center.Y)));
            }
            polygonPoints = rotated;

            if (wasFilled)
                seedPoint = GetPolygonCenter();

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
                        case FillAlgorithm.ScanLine:
                            ScanLineFill();
                            break;
                        case FillAlgorithm.BoundaryFill:
                            if (use8Connected)
                                BoundaryFill8(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            else
                                BoundaryFill4(seed.X, seed.Y, fillColor, boundaryColor, defaultColor);
                            break;
                        case FillAlgorithm.FloodFill:
                            if (use8Connected)
                                FloodFill8(seed.X, seed.Y, fillColor, defaultColor);
                            else
                                FloodFill4(seed.X, seed.Y, fillColor, defaultColor);
                            break;
                    }

                    picCanvas.Refresh();
                    UpdateStatus($"Polygon rotated by {angleDeg}° — fill preserved");
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Rotation done but re-fill failed: {ex.Message}");
                }
                finally
                {
                    isFilling = false;
                }
            }
            else
            {
                UpdateStatus($"Polygon rotated by {angleDeg}°");
            }
        }
    }
}