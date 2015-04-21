﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SquareRootsSolver
{
    public partial class GridCell : UserControl
    {
        #region Members

        #region Constants

        private const int itsNormalCellSize = 40;
        private const int itsExpandedCellSize = 48;

        #endregion 

        private int itsPositionX;
        private int itsPositionY;

        #endregion

        public GridCell()
        {
            InitializeComponent();
        }

        #region Properties

        public int PositionX
        {
            get
            {
                return itsPositionX;
            }
            set
            {
                itsPositionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return itsPositionY;
            }
            set
            {
                itsPositionY = value;
            }
        }

        #endregion

        private void GridCell_MouseEnter(object sender, EventArgs e)
        {
            this.Size = new Size(itsExpandedCellSize, itsExpandedCellSize);
            this.Location = new Point(itsPositionX - (itsExpandedCellSize / 2), 
                itsPositionY - (itsExpandedCellSize / 2) );
        }

        private void GridCell_MouseLeave(object sender, EventArgs e)
        {
            this.Size = new Size(itsNormalCellSize, itsNormalCellSize);
            this.Location = new Point(itsPositionX - (itsNormalCellSize / 2), 
                itsPositionY -  (itsNormalCellSize / 2));
        }

    }
}