using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLStartUpTemplate1
{
    public partial class Form1 : Form
    {
        #region Initializations
        Cell[,] universe = new Cell[50, 50]; // Shown array
        Cell[,] scratchPad = new Cell[50, 50]; // Array to hold the next gen

        Color gridColor;
        Color cellColor;

        // The Timer class
        Timer timer = new Timer();

        int generations = 0;
        int seed = 0;
        int numLiving = 0;

        bool isFinite = true;
        bool showGrid = true;
        #endregion

        public Form1()
        {
            InitializeComponent();

            // Loading color settings
            graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.CellColor;

            NewUniverse(Properties.Settings.Default.UniverseWidth, Properties.Settings.Default.UniverseHeight);

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            int count = 0;

            for (int ix = 0; ix < universe.GetLength(0); ix++)
            {
                for (int iy = 0; iy < universe.GetLength(1); iy++)
                {
                    if (isFinite)
                    {
                        count = countNeighborsFinite(ix, iy);
                    }
                    else
                    {
                        count = CountNeighborsToroidal(ix, iy);
                    }                    

                    // If the cell is alive and has less than 2 or more than 3 neighbors
                    if (universe[ix, iy].isAlive == true && (count < 2 || count > 3))
                    {
                        scratchPad[ix, iy].isAlive = false;
                    }

                    // If the cell is alive and has 2 or 3 neighbors
                    if (universe[ix, iy].isAlive == true && (count == 2 || count == 3))
                    {
                        scratchPad[ix, iy].isAlive = true;
                    }

                    // If the cell is dead and has 3 neighbors
                    if (universe[ix, iy].isAlive == false && count == 3)
                    {
                        scratchPad[ix, iy].isAlive = true;
                    }
                }
            }

            // Swap arrays
            Cell[,] temp = universe;
            universe = scratchPad;
            scratchPad = temp;

            // clear the scratchPad
            for (int ix = 0; ix < scratchPad.GetLength(0); ix++)
            {
                for (int iy = 0; iy < scratchPad.GetLength(1); iy++)
                {
                    scratchPad[ix, iy].isAlive = false;
                }
            }

            generations++;
            AliveCellCount();

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            graphicsPanel1.Invalidate();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        // Calculates cell size and paints them
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            float cellWidth = graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            float cellHeight = graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    RectangleF cellRect = RectangleF.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y].isAlive == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    if (showGrid == true)
                    {
                        // Outline the cell with a pen
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        // Calculates what cell is being clicked
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                float cellWidth = graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
                float cellHeight = graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = (int)(e.X / cellWidth);
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = (int)(e.Y / cellHeight);

                // Toggle the cell's state
                universe[x, y].isAlive = !universe[x, y].isAlive;

                numLiving++;
                toolStripStatusLabelAliveCells.Text = "Alive Cells = " + numLiving.ToString();

                graphicsPanel1.Invalidate();
            }
        }

        // Counts neighbors if the universe ends at the edges
        private int countNeighborsFinite(int x, int y)
        {
            int neighbors = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for(int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    // If xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    // If xCheck or yCheck is less than 0 then continue
                    if (xCheck < 0 || yCheck < 0)
                    {
                        continue;
                    }

                    // If xCheck or yCheck is greater than or equal too xLen or YLen then continue
                    if (xCheck >= xLen || yCheck >= yLen)
                    {
                        continue;
                    }

                    if (universe[xCheck, yCheck].isAlive == true) neighbors++;
                }
            }

            return neighbors;
        }

        // Counts neighbors if the universe wraps at the edges
        private int CountNeighborsToroidal(int x, int y)
        {
            int neighbors = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    // if xCheck is less than 0 then set to xLen - 1
                    if (xCheck < 0)
                    {
                        xCheck = xLen - 1;
                    }

                    // if yCheck is less than 0 then set to yLen - 1
                    if (yCheck < 0)
                    {
                        yCheck = yLen - 1;
                    }

                    // if xCheck is greater than or equal too xLen then set to 0
                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }

                    // if yCheck is greater than or equal too yLen then set to 0
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }

                    if (universe[xCheck, yCheck].isAlive == true) neighbors++;
                }
            }
            return neighbors;
        }

        // Fills a 2D Cell array with new cells
        private void Fill2DCellArray(Cell[,] array)
        {
            for (int ix = 0; ix < array.GetLength(0); ix++)
            {
                for (int iy = 0; iy < array.GetLength(1); iy++)
                {
                    array[ix, iy] = new Cell();
                }
            }
        }

        // Loops through the universe and randoms cells to alive or dead
        private void RandomUniverseTimeSeed()
        {
            int num = 0;
            Random randTime = new Random();

            for (int ix = 0; ix < universe.GetLength(0); ix++)
            {
                for (int iy = 0; iy < universe.GetLength(1); iy++)
                {
                    num = randTime.Next(3);

                    if (num == 0)
                    {
                        universe[ix, iy].isAlive = true;
                    }
                    else
                    {
                        universe[ix, iy].isAlive = false;
                    }
                }
            }

            AliveCellCount();
            graphicsPanel1.Invalidate();
        }

        // Loops through the universe and randoms cells to alive or dead
        private void RandomUniverseRandNumSeed()
        {
            int num = 0;
            Random randNum = new Random(seed);

            for (int ix = 0; ix < universe.GetLength(0); ix++)
            {
                for (int iy = 0; iy < universe.GetLength(1); iy++)
                {
                    num = randNum.Next(3);

                    if (num == 0)
                    {
                        universe[ix, iy].isAlive = true;
                    }
                    else
                    {
                        universe[ix, iy].isAlive = false;
                    }
                }
            }

            AliveCellCount();
            graphicsPanel1.Invalidate();
        }

        // Pauses and resets the universe and generation count
        private void NewUniverse(int x, int y)
        {
            universe = new Cell[x, y];
            scratchPad = new Cell[x, y];

            Fill2DCellArray(universe);
            Fill2DCellArray(scratchPad);

            timer.Enabled = false;
            generations = 0;
            numLiving = 0;

            for (int ix = 0; ix < universe.GetLength(0); ix++)
            {
                for (int iy = 0; iy < universe.GetLength(1); iy++)
                {
                    universe[ix, iy].isAlive = false;
                }
            }

            graphicsPanel1.Invalidate();
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            toolStripStatusLabelAliveCells.Text = "Alive Cells = " + numLiving.ToString();
        }

        private void AliveCellCount()
        {
            numLiving = 0;

            for (int ix = 0; ix < universe.GetLength(0); ix++)
            {
                for (int iy = 0; iy < universe.GetLength(1); iy++)
                {
                    if (universe[ix, iy].isAlive == true)
                    {
                        numLiving++;
                    }
                }
            }

            toolStripStatusLabelAliveCells.Text = "Alive Cells = " + numLiving.ToString();            
        }

        #region Toolbar

        #region File
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Colors
        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        private void cellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsPanel1.BackColor = DefaultBackColor;
            gridColor = Color.Black;
            cellColor = Color.Gray;
        }
        #endregion

        #region Universe
        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFinite == false)
            {
                isFinite = true;
                finiteToolStripMenuItem.Checked = true;
                toroidalToolStripMenuItem.Checked = false;
            }
        }

        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFinite == true)
            {
                isFinite = false;
                toroidalToolStripMenuItem.Checked = true;
                finiteToolStripMenuItem.Checked = false;
            }
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModalDialogSize dlg = new ModalDialogSize();
            dlg.UniverseWidth = Properties.Settings.Default.UniverseWidth;
            dlg.UniverseHeight = Properties.Settings.Default.UniverseHeight;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                Properties.Settings.Default.UniverseWidth = dlg.UniverseWidth;
                Properties.Settings.Default.UniverseHeight = dlg.UniverseHeight;

                NewUniverse(Properties.Settings.Default.UniverseWidth, Properties.Settings.Default.UniverseHeight);
                graphicsPanel1.Invalidate();
            }
        }
        #endregion

        #region View
        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showGrid = !showGrid;
            graphicsPanel1.Invalidate();
        }
        #endregion

        private void NewUniverseButton_Click(object sender, EventArgs e)
        {
            NewUniverse(Properties.Settings.Default.UniverseWidth, Properties.Settings.Default.UniverseHeight);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void NextGenerationButton_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }

        #region Random
        private void randomFromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModalDialogSeed dlg = new ModalDialogSeed();
            dlg.Seed = seed;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                seed = dlg.Seed;
                NewUniverse(Properties.Settings.Default.UniverseWidth, Properties.Settings.Default.UniverseHeight);
                RandomUniverseRandNumSeed();
                graphicsPanel1.Invalidate();
            }
        }

        private void randomFromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUniverse(Properties.Settings.Default.UniverseWidth, Properties.Settings.Default.UniverseHeight);
            RandomUniverseTimeSeed();
        }
        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.BackgroundColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.GridColor = gridColor;
            Properties.Settings.Default.CellColor = cellColor;

            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
