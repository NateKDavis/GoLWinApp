﻿using System;
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
        // Initialize arrays
        Cell[,] universe = new Cell[100, 100];
        Cell[,] scratchPad = new Cell[100, 100];

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        // Random funness
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            Fill2DCellArray(universe);
            Fill2DCellArray(scratchPad);

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
                    count = countNeighborsFinite(ix, iy);

                    //if the cell is alive and has less than 2 or more than 3 neighbors
                    if (universe[ix, iy].isAlive == true && (count < 2 || count > 3))
                    {
                        scratchPad[ix, iy].isAlive = false;
                    }

                    //if the cell is alive and has 2 or 3 neighbors
                    if (universe[ix, iy].isAlive == true && (count == 2 || count == 3))
                    {
                        scratchPad[ix, iy].isAlive = true;
                    }

                    //if the cell is dead and has 3 neighbors
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

            graphicsPanel1.Invalidate();

            // clear the scratchPad
            for (int ix = 0; ix < scratchPad.GetLength(0); ix++)
            {
                for (int iy = 0; iy < scratchPad.GetLength(1); iy++)
                {
                    scratchPad[ix, iy].isAlive = false;
                }
            }

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

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

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

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

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

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

                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    // if xCheck or yCheck is less than 0 then continue
                    if (xCheck < 0 || yCheck < 0)
                    {
                        continue;
                    }

                    // if xCheck or yCheck is greater than or equal too xLen or YLen then continue
                    if (xCheck >= xLen || yCheck >= yLen)
                    {
                        continue;
                    }

                    if (universe[xCheck, yCheck].isAlive == true) neighbors++;
                }
            }

            return neighbors;
        }

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
                        xLen = -1;
                    }

                    // if yCheck is less than 0 then set to yLen - 1
                    if (yCheck < 0)
                    {
                        yLen = -1;
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

        // Fills a 2D Cell arrays with new cells
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

            for (int ix = 0; ix < universe.GetLength(0); ix++)
            {
                for (int iy = 0; iy < universe.GetLength(1); iy++)
                {
                    num = rand.Next(3);

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

            graphicsPanel1.Invalidate();
        }

        // Pauses and resets the universe and generation count
        private void NewUniverse()
        {
            timer.Enabled = false;
            generations = 0;

            for (int ix = 0; ix < universe.GetLength(0); ix++)
            {
                for (int iy = 0; iy < universe.GetLength(1); iy++)
                {
                    universe[ix, iy].isAlive = false;
                }
            }

            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            graphicsPanel1.Invalidate();
        }

        #region Tooltip Buttons
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

        private void NewUniverseButton_Click(object sender, EventArgs e)
        {
            NewUniverse();
        }

        private void randomFromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void randomFromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUniverse();
            RandomUniverseTimeSeed();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}