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
        List<SolverCellInfo> itsSolverCellInfos;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            itsGridCells = new List<GridCell>();
        }

        #region Private Methods

        private void SolvePuzzle()
        {
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
                iColumn++;

                if(iRow == itsGridSize) 
                {
                    iRow = 0;
                }
                
                if(iColumn == itsGridSize) 
                {
                    iColumn = 0;
                }

                itsSolverCellInfos.Add(sci);

            }

            // Fill in the 'border cells' with 0s for sides that make up the border
            foreach (SolverCellInfo sci in itsSolverCellInfos)
            {
                if (sci.Row == 0) 
                {
                    sci.ValueAbove = 0;
                }

                if (sci.Row == itsGridSize - 1)
                {
                    sci.ValueBelow = 0;
                }

                if (sci.Column == 0)
                {
                    sci.ValueLeft = 0;
                }

                if (sci.Column == itsGridSize - 1)
                {
                    sci.ValueRight = 0;
                }
            }

            if (SolverCellInfo.CheckAllFourKnownForAllCells(itsSolverCellInfos))
            {
                return;
            }

            return;
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

        
    }
}
