using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SquareRootsSolver
{
    public partial class NewGridDialog : Form
    {
        // Members
        int itsGridSize;
        MainForm itsParent;

        public NewGridDialog(MainForm theParent)
        {
            InitializeComponent();

            itsParent = theParent;
            // default value of 6
            itsNumericGridSize.Value = 6;
        }

        private void ItsButtonOkay_Click(object sender, EventArgs e)
        {
            itsGridSize = (int)itsNumericGridSize.Value;

            itsParent.DrawGridCells(itsGridSize);

            this.Close();
        }


    }
}
