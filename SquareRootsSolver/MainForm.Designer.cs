namespace SquareRootsSolver
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itsMenuStrip = new System.Windows.Forms.MenuStrip();
            this.itsToolStripItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.itsMenuItem_File_NewGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itsMenuItem_File_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.itsToolStripItem_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.itsMenuItem_Tools_Solve = new System.Windows.Forms.ToolStripMenuItem();
            this.itsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // itsMenuStrip
            // 
            this.itsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itsToolStripItem_File,
            this.itsToolStripItem_Tools});
            this.itsMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.itsMenuStrip.Name = "itsMenuStrip";
            this.itsMenuStrip.Size = new System.Drawing.Size(559, 24);
            this.itsMenuStrip.TabIndex = 0;
            this.itsMenuStrip.Text = "menuStrip1";
            // 
            // itsToolStripItem_File
            // 
            this.itsToolStripItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itsMenuItem_File_NewGrid,
            this.toolStripSeparator1,
            this.itsMenuItem_File_Close});
            this.itsToolStripItem_File.Name = "itsToolStripItem_File";
            this.itsToolStripItem_File.Size = new System.Drawing.Size(37, 20);
            this.itsToolStripItem_File.Text = "File";
            // 
            // itsMenuItem_File_NewGrid
            // 
            this.itsMenuItem_File_NewGrid.Name = "itsMenuItem_File_NewGrid";
            this.itsMenuItem_File_NewGrid.Size = new System.Drawing.Size(152, 22);
            this.itsMenuItem_File_NewGrid.Text = "New Grid";
            this.itsMenuItem_File_NewGrid.Click += new System.EventHandler(this.ItsMenuItem_File_NewGrid_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // itsMenuItem_File_Close
            // 
            this.itsMenuItem_File_Close.Name = "itsMenuItem_File_Close";
            this.itsMenuItem_File_Close.Size = new System.Drawing.Size(152, 22);
            this.itsMenuItem_File_Close.Text = "Close";
            // 
            // itsToolStripItem_Tools
            // 
            this.itsToolStripItem_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itsMenuItem_Tools_Solve});
            this.itsToolStripItem_Tools.Name = "itsToolStripItem_Tools";
            this.itsToolStripItem_Tools.Size = new System.Drawing.Size(48, 20);
            this.itsToolStripItem_Tools.Text = "Tools";
            // 
            // itsMenuItem_Tools_Solve
            // 
            this.itsMenuItem_Tools_Solve.Name = "itsMenuItem_Tools_Solve";
            this.itsMenuItem_Tools_Solve.Size = new System.Drawing.Size(152, 22);
            this.itsMenuItem_Tools_Solve.Text = "Solve";
            this.itsMenuItem_Tools_Solve.Click += new System.EventHandler(this.ItsMenuItems_Tools_Solve_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 514);
            this.Controls.Add(this.itsMenuStrip);
            this.MainMenuStrip = this.itsMenuStrip;
            this.Name = "MainForm";
            this.Text = "Square Roots Solver";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.itsMenuStrip.ResumeLayout(false);
            this.itsMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip itsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem itsToolStripItem_File;
        private System.Windows.Forms.ToolStripMenuItem itsMenuItem_File_NewGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itsMenuItem_File_Close;
        private System.Windows.Forms.ToolStripMenuItem itsToolStripItem_Tools;
        private System.Windows.Forms.ToolStripMenuItem itsMenuItem_Tools_Solve;
    }
}

