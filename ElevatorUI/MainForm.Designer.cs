namespace ElevatorUI
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
            this.components = new System.ComponentModel.Container();
            this.floorsOuterPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gvLogs = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogs = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.controlPanel = new ElevatorUI.Controls.ControlPanelControl();
            this.elevatorMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.elevatorShaft = new System.Windows.Forms.Panel();
            this.elevatorInShaftPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLogs)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.elevatorShaft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elevatorInShaftPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // floorsOuterPanel
            // 
            this.floorsOuterPanel.AutoScroll = true;
            this.floorsOuterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.floorsOuterPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.floorsOuterPanel.Location = new System.Drawing.Point(645, 0);
            this.floorsOuterPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.floorsOuterPanel.Name = "floorsOuterPanel";
            this.floorsOuterPanel.Size = new System.Drawing.Size(600, 576);
            this.floorsOuterPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gvLogs);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 576);
            this.panel1.TabIndex = 3;
            // 
            // gvLogs
            // 
            this.gvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLogs.Location = new System.Drawing.Point(0, 100);
            this.gvLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvLogs.Name = "gvLogs";
            this.gvLogs.RowHeadersWidth = 51;
            this.gvLogs.RowTemplate.Height = 24;
            this.gvLogs.Size = new System.Drawing.Size(397, 474);
            this.gvLogs.TabIndex = 3;
            this.gvLogs.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLogs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 100);
            this.panel3.TabIndex = 2;
            // 
            // btnLogs
            // 
            this.btnLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogs.Location = new System.Drawing.Point(61, 32);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(264, 38);
            this.btnLogs.TabIndex = 1;
            this.btnLogs.Text = "Show Logs";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.controlPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(399, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 576);
            this.panel2.TabIndex = 4;
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 137);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(164, 439);
            this.controlPanel.TabIndex = 3;
            // 
            // elevatorMoveTimer
            // 
            this.elevatorMoveTimer.Interval = 20;
            this.elevatorMoveTimer.Tick += new System.EventHandler(this.elevatorMoveTimer_Tick);
            // 
            // elevatorShaft
            // 
            this.elevatorShaft.Controls.Add(this.elevatorInShaftPictureBox);
            this.elevatorShaft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevatorShaft.Location = new System.Drawing.Point(563, 0);
            this.elevatorShaft.Margin = new System.Windows.Forms.Padding(4);
            this.elevatorShaft.Name = "elevatorShaft";
            this.elevatorShaft.Size = new System.Drawing.Size(82, 576);
            this.elevatorShaft.TabIndex = 5;
            // 
            // elevatorInShaftPictureBox
            // 
            this.elevatorInShaftPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.elevatorInShaftPictureBox.Image = global::ElevatorUI.Properties.Resources.openElevator;
            this.elevatorInShaftPictureBox.Location = new System.Drawing.Point(-72, 367);
            this.elevatorInShaftPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.elevatorInShaftPictureBox.Name = "elevatorInShaftPictureBox";
            this.elevatorInShaftPictureBox.Size = new System.Drawing.Size(147, 185);
            this.elevatorInShaftPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elevatorInShaftPictureBox.TabIndex = 0;
            this.elevatorInShaftPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 576);
            this.Controls.Add(this.elevatorShaft);
            this.Controls.Add(this.floorsOuterPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Elevator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLogs)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.elevatorShaft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elevatorInShaftPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel floorsOuterPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Panel panel2;
        private Controls.ControlPanelControl controlPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer elevatorMoveTimer;
        private System.Windows.Forms.DataGridView gvLogs;
        private System.Windows.Forms.Panel elevatorShaft;
        private System.Windows.Forms.PictureBox elevatorInShaftPictureBox;
    }
}

