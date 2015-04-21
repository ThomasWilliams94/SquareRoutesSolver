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

            for (int x = 40 + 40; x < 40 + 4 * 40; x += 40)
            {
                for (int y = 40 + 40; y < 40 + 40 * 4; y+=40)
                {
                    GridCell gridCell = new GridCell();

                    gridCell.PositionX = x;
                    gridCell.PositionY = y;

                    gridCell.Location = new Point(gridCell.PositionX - gridCell.Width / 2, gridCell.PositionY - gridCell.Height / 2);

                    this.Controls.Add(gridCell);
                }
            }
            
        }

        
    }
}
