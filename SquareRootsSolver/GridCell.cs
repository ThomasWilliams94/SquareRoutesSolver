using System;
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

        public int NormalCellSize
        {
            get
            {
                return itsNormalCellSize;
            }
        }

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
            this.BringToFront();
        }

        private void GridCell_MouseLeave(object sender, EventArgs e)
        {
            this.Size = new Size(itsNormalCellSize, itsNormalCellSize);
            this.Location = new Point(itsPositionX - (itsNormalCellSize / 2), 
                itsPositionY -  (itsNormalCellSize / 2));
            this.BringToFront();
        }

        private void GridCell_Click(object sender, EventArgs e)
        {
            Color currentColour = this.BackColor;

            if(currentColour == Color.White) 
            {
                this.BackColor = Color.OldLace;
                return;
            }
            if(currentColour == Color.OldLace) 
            {
                this.BackColor = Color.LightGray;
                return;
            }
            if(currentColour == Color.LightGray) 
            { 
                this.BackColor = Color.White;
                return;
            }
        }

    }
}
