using System;
using System.Collections.Generic;
using System.Text;

namespace SquareRootsSolver
{
    class SolverCellInfo
    {
        // For each GridCell, a SolverCellInfo will be created in 
        // the Solve method, before filling in the options.

        #region Members

        private int itsPosX;
        private int itsPosY;

        // starting at (0,0) in the top-left cell, going to
        // (itsGridSize - 1, itsGridSize - 1) in bottom-right cell
        // (see MainForm);
        private int itsRow;
        private int itsColumn;

        // These should only ever be one of three values: -1, 0, or 1.
        //        -1 => it's never been assigned
        //         0 => that side is 'blocked'
        //         1 => that side is 'cut'
        private int itsValueLeft  = -1;
        private int itsValueRight = -1;
        private int itsValueAbove = -1;
        private int itsValueBelow = -1;

        private bool itsAllFourKnown = false;

        #endregion

        public SolverCellInfo(int xPosOfGridCell, int yPosOfGridCell)
        {
            this.PosX = xPosOfGridCell;
            this.PosY = yPosOfGridCell;
        }

        #region Properties

        public int PosX
        {
            get
            {
                return itsPosX;
            }
            set
            {
                itsPosX = value;
            }
        }

        public int PosY
        {
            get
            {
                return itsPosY;
            }
            set
            {
                itsPosY = value;
            }
        }

        public int Row
        {
            get
            {
                return itsRow;
            }
            set
            {
                itsRow = value;
            }
        }

        public int Column
        {
            get
            {
                return itsColumn;
            }
            set
            {
                itsColumn = value;
            }
        }

        public bool AllFourKnown
        {
            get
            {
                return itsAllFourKnown;
            }
            set
            {
                itsAllFourKnown = value;
            }
        }

        #endregion

        #region Public Methods

        public bool CheckAllFourKnownForAllCells(List<SolverCellInfo> theListOfCells) 
        {
            foreach (SolverCellInfo sci in theListOfCells)
            {
                // If we find one that is false, then return false
                if (!sci.AllFourKnown)
                {
                    return false;
                }
            }

            // If we get here, all were true, so the puzzle is solved!
            return true;
        }
        #endregion

    }
}
