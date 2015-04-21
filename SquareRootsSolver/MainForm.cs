using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SquareRootsSolver
{
    public partial class MainForm : Form
    {
        // The version number of the application
        public string theirVersion = "0.0.1";

        #region Members

        // Contains a list of the GridCells displayed on the MainForm
        List<GridCell> itsGridCells;

        private int itsGridSize;

        // Contains a list of the SolverCellInfos used for solving 
        // (and eventually drawing the solution)
        List<SolverCellInfo> itsSolverCellInfos = new List<SolverCellInfo>();

        private bool itsDrawingSolution = false;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            itsGridCells = new List<GridCell>();
        }

        #region Private Methods

        private bool SolvePuzzle()
        {
            // Clear previous SolverCellInfos
            itsSolverCellInfos.Clear();

            // Counter for assigning row number
            int iRow = 0;
            // Counter for assigning column number
            int iColumn = 0;

            // Add all GridCells as SolverCellInfos to itsSolverCellInfos
            foreach (GridCell gridCell in itsGridCells)
            {
                SolverCellInfo sci = new SolverCellInfo(gridCell.PositionX, gridCell.PositionY);

                sci.Row = iRow;
                sci.Column = iColumn;

                iRow++;
                //iColumn++;

                if(iRow == itsGridSize) 
                {
                    iRow = 0;
                    iColumn++;
                }
                
                //if(iColumn == itsGridSize) 
                //{
                //    iColumn = 0;
                //    iRow++;
                //}

                itsSolverCellInfos.Add(sci);

            }

            // Fill in the 'border cells' with 0s for sides that make up the border
            foreach (SolverCellInfo sci in itsSolverCellInfos)
            {
                if (sci.Row == 0) 
                {
                    sci.ValueAbove = 0;
                    //sci.KnownSidesAndValues.Add("Above", 0);
                }

                if (sci.Row == itsGridSize - 1)
                {
                    sci.ValueBelow = 0;
                    //sci.KnownSidesAndValues.Add("Below", 0);
                }

                if (sci.Column == 0)
                {
                    sci.ValueLeft = 0;
                    //sci.KnownSidesAndValues.Add("Left", 0);
                }

                if (sci.Column == itsGridSize - 1)
                {
                    sci.ValueRight = 0;
                    //sci.KnownSidesAndValues.Add("Right", 0);
                }
            }

            foreach (SolverCellInfo sci in itsSolverCellInfos)
            {
                CheckTwoSidesOfSameValueKnown(sci);
            }

            if (SolverCellInfo.CheckAllFourKnownForAllCells(itsSolverCellInfos))
            {
                return true;
            }

            return false;
        }

        private void CheckTwoSidesOfSameValueKnown(SolverCellInfo theSolverCellInfo) 
        {
            // Check there are two sides known
            if (theSolverCellInfo.KnownSidesAndValues.Count == 2)
            {
                List<int> theTwoValues = new List<int>();
                
                // Now check that they are both the same value
                Dictionary<string,int>.ValueCollection values = theSolverCellInfo.KnownSidesAndValues.Values;

                foreach (int value in values)
                {
                    theTwoValues.Add(value);
                }

                if (theTwoValues[0] == theTwoValues[1])
                {
                    // now we know the other two sides. 

                    // valueToAdd will be 0 if the above value is 1 or 1 if 
                    int valueToAdd = Math.Abs(theTwoValues[0] - 1);
                                        
                    if(!theSolverCellInfo.KnownSidesAndValues.ContainsKey("Above") ) 
                    {
                        theSolverCellInfo.ValueAbove = valueToAdd;
                        //theSolverCellInfo.KnownSidesAndValues.Add("Above", valueToAdd);
                    }

                    if (!theSolverCellInfo.KnownSidesAndValues.ContainsKey("Below"))
                    {
                        theSolverCellInfo.ValueBelow = valueToAdd;
                        //theSolverCellInfo.KnownSidesAndValues.Add("Below", valueToAdd);
                    }

                    if (!theSolverCellInfo.KnownSidesAndValues.ContainsKey("Left"))
                    {
                        theSolverCellInfo.ValueLeft = valueToAdd;
                        //theSolverCellInfo.KnownSidesAndValues.Add("Left", valueToAdd);
                    }

                    if (!theSolverCellInfo.KnownSidesAndValues.ContainsKey("Right"))
                    {
                        theSolverCellInfo.ValueRight = valueToAdd;
                        //theSolverCellInfo.KnownSidesAndValues.Add("Right", valueToAdd);
                    }

                }
            }
        }

        private void DrawSolution()
        {
            itsDrawingSolution = true;

            this.Refresh();

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Draws a grid of size theGridSize x theGridSize (assuming grids
        /// will be sqaure)
        /// </summary>
        /// <param name="theGridSize"></param>
        public void DrawGridCells(int theGridSize)
        {
            // Set itsGridSize
            itsGridSize = theGridSize;

            // for getting height and width for positioning
            GridCell dummyGridCell = new GridCell();
            Point formCentre = new Point(this.Width / 2, this.Height / 2);

            int xStart = formCentre.X - theGridSize * dummyGridCell.Width / 2;
            int yStart = formCentre.Y - theGridSize * dummyGridCell.Height / 2;

            for (int x = xStart + dummyGridCell.Width; x <= xStart + theGridSize * dummyGridCell.Width; 
                x += dummyGridCell.Width)
            {
                for (int y = yStart + dummyGridCell.Height; y <= yStart + theGridSize * dummyGridCell.Height; 
                    y += dummyGridCell.Height)
                {
                    GridCell gridCell = new GridCell();

                    gridCell.PositionX = x;
                    gridCell.PositionY = y;

                    gridCell.Location = new Point(gridCell.PositionX - gridCell.Width / 2, gridCell.PositionY - gridCell.Height / 2);

                    this.Controls.Add(gridCell);
                    itsGridCells.Add(gridCell);
                }
            }
        }

        #endregion


        private void ItsMenuItem_File_NewGrid_Click(object sender, EventArgs e)
        {
            foreach (GridCell gridCell in itsGridCells)
            {
                this.Controls.Remove(gridCell);                               
            }

            itsGridCells.Clear();

            // Also remove all of the solver cells
            itsSolverCellInfos.Clear();

            NewGridDialog newGridDialog = new NewGridDialog(this);

            newGridDialog.Show();

        }

        private void ItsMenuItems_Tools_Solve_Click(object sender, EventArgs e)
        {
            if (SolvePuzzle()) 
            {
                DrawSolution();
            }                                        
                
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {       
            
            if (itsDrawingSolution)
            {
                foreach (GridCell gridCell in itsGridCells)
                {
                    gridCell.SendToBack();
                    gridCell.BackColor = Color.Transparent;
                    gridCell.Hide();
                }

                GridCell dummyGridCell = new GridCell();

                Graphics g = e.Graphics;

                Brush brush = new SolidBrush(Color.Black);

                Pen pen = new Pen(brush, 4);

                foreach (SolverCellInfo sci in itsSolverCellInfos)
                {
                    Point ctrPoint = new Point(sci.PosX , 
                        sci.PosY );
                                        
                    if (sci.ValueAbove == 1)
                    {
                        Point newPoint = new Point(ctrPoint.X, ctrPoint.Y - dummyGridCell.NormalCellSize/2);
                        g.DrawLine(pen, ctrPoint, newPoint);
                    }

                    if (sci.ValueBelow == 1) 
                    {
                        Point newPoint = new Point(ctrPoint.X, ctrPoint.Y + dummyGridCell.NormalCellSize/2);
                        g.DrawLine(pen, ctrPoint, newPoint);
                    }

                    if (sci.ValueLeft == 1) 
                    {
                        Point newPoint = new Point(ctrPoint.X - dummyGridCell.NormalCellSize / 2, ctrPoint.Y);
                        g.DrawLine(pen, ctrPoint, newPoint);
                    }

                    if (sci.ValueRight == 1)
                    {
                        Point newPoint = new Point(ctrPoint.X + dummyGridCell.NormalCellSize / 2, ctrPoint.Y);
                        g.DrawLine(pen, ctrPoint, newPoint);
                    }
                }

                

                itsDrawingSolution = false;
            }
            
        }

        
    }
}
