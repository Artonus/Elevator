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
            this.floorsPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gvLogs = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogs = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.controlPanel = new ElevatorUI.Controls.ControlPanelControl();
            this.elevatorMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.elevatorShaft = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLogs)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.elevatorShaft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // floorsPanel
            // 
            this.floorsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.floorsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.floorsPanel.Location = new System.Drawing.Point(448, 0);
            this.floorsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.floorsPanel.Name = "floorsPanel";
            this.floorsPanel.Size = new System.Drawing.Size(486, 468);
            this.floorsPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gvLogs);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 468);
            this.panel1.TabIndex = 3;
            // 
            // gvLogs
            // 
            this.gvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLogs.Location = new System.Drawing.Point(0, 81);
            this.gvLogs.Margin = new System.Windows.Forms.Padding(2);
            this.gvLogs.Name = "gvLogs";
            this.gvLogs.RowHeadersWidth = 51;
            this.gvLogs.RowTemplate.Height = 24;
            this.gvLogs.Size = new System.Drawing.Size(180, 385);
            this.gvLogs.TabIndex = 3;
            this.gvLogs.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLogs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 81);
            this.panel3.TabIndex = 2;
            // 
            // btnLogs
            // 
            this.btnLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogs.Location = new System.Drawing.Point(46, 26);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(80, 31);
            this.btnLogs.TabIndex = 1;
            this.btnLogs.Text = "Show Logs";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.controlPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(182, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 468);
            this.panel2.TabIndex = 4;
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 313);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(123, 155);
            this.controlPanel.TabIndex = 3;
            // 
            // elevatorMoveTimer
            // 
            this.elevatorMoveTimer.Interval = 20;
            this.elevatorMoveTimer.Tick += new System.EventHandler(this.elevatorMoveTimer_Tick);
            // 
            // elevatorShaft
            // 
            this.elevatorShaft.Controls.Add(this.pictureBox1);
            this.elevatorShaft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevatorShaft.Location = new System.Drawing.Point(305, 0);
            this.elevatorShaft.Name = "elevatorShaft";
            this.elevatorShaft.Size = new System.Drawing.Size(143, 468);
            this.elevatorShaft.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::ElevatorUI.Properties.Resources.openElevator;
            this.pictureBox1.Location = new System.Drawing.Point(28, 298);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 468);
            this.Controls.Add(this.elevatorShaft);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.floorsPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Elevator";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLogs)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.elevatorShaft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel floorsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Panel panel2;
        private Controls.ControlPanelControl controlPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer elevatorMoveTimer;
        private System.Windows.Forms.DataGridView gvLogs;
        private System.Windows.Forms.Panel elevatorShaft;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

