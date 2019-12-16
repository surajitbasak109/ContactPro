namespace ContactPro
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.districtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panchayatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membershipEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.membershipEntryToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(996, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.districtToolStripMenuItem,
            this.constiToolStripMenuItem,
            this.panchayatToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "&Master";
            // 
            // districtToolStripMenuItem
            // 
            this.districtToolStripMenuItem.Name = "districtToolStripMenuItem";
            this.districtToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.districtToolStripMenuItem.Text = "&District";
            this.districtToolStripMenuItem.Click += new System.EventHandler(this.districtToolStripMenuItem_Click);
            // 
            // constiToolStripMenuItem
            // 
            this.constiToolStripMenuItem.Name = "constiToolStripMenuItem";
            this.constiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.constiToolStripMenuItem.Text = "&Constituency";
            this.constiToolStripMenuItem.Click += new System.EventHandler(this.constiToolStripMenuItem_Click);
            // 
            // panchayatToolStripMenuItem
            // 
            this.panchayatToolStripMenuItem.Name = "panchayatToolStripMenuItem";
            this.panchayatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.panchayatToolStripMenuItem.Text = "&Panchayat";
            this.panchayatToolStripMenuItem.Click += new System.EventHandler(this.panchayatToolStripMenuItem_Click);
            // 
            // membershipEntryToolStripMenuItem
            // 
            this.membershipEntryToolStripMenuItem.Name = "membershipEntryToolStripMenuItem";
            this.membershipEntryToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.membershipEntryToolStripMenuItem.Text = "&Membership Entry";
            this.membershipEntryToolStripMenuItem.Click += new System.EventHandler(this.membershipEntryToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(996, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.DarkSlateGray;
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(142)))), ((int)(((byte)(0))))));
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(996, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Pro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem districtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panchayatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membershipEntryToolStripMenuItem;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}



