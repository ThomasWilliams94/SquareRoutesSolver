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

        #endregion

        public MainForm()
        {
            InitializeComponent();


        }

        #region Public Methods

        /// <summary>
        /// Draws a grid of size theGridSize x theGridSize (assuming grids
        /// will be sqaure)
        /// </summary>
        /// <param name="theGridSize"></param>
        public void DrawGridCells(int theGridSize)
        {
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
                }
            }
        }

        #endregion


        private void ItsMenuItem_File_NewGrid_Click(object sender, EventArgs e)
        {
            // temporary removal of controls
            // Maybe have a list of GridCells belonging to MainForm, and
            // remove those. Then .Clear() that list before adding in new ones. 
            foreach (Control control in this.Controls)
            {
                if (control is GridCell)
                {
                    this.Controls.Remove(control);
                }
                
            }

            NewGridDialog newGridDialog = new NewGridDialog(this);

            newGridDialog.Show();

        }

        
    }
}
