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

            GridCell gridCell = new GridCell();

            gridCell.PositionX = 70;
            gridCell.PositionY = 70;

            gridCell.Location = new Point(gridCell.PositionX - gridCell.Width/2, gridCell.PositionY - gridCell.Height/2);

            this.Controls.Add(gridCell);
        }

        
    }
}
