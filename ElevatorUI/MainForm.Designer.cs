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
            this.elevatorMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.controlPanelControl1 = new ElevatorUI.Controls.ControlPanelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLogs)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // floorsPanel
            // 
            this.floorsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.floorsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.floorsPanel.Location = new System.Drawing.Point(406, 0);
            this.floorsPanel.Name = "floorsPanel";
            this.floorsPanel.Size = new System.Drawing.Size(647, 576);
            this.floorsPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gvLogs);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 576);
            this.panel1.TabIndex = 3;
            // 
            // gvLogs
            // 
            this.gvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLogs.Location = new System.Drawing.Point(0, 100);
            this.gvLogs.Name = "gvLogs";
            this.gvLogs.RowHeadersWidth = 51;
            this.gvLogs.RowTemplate.Height = 24;
            this.gvLogs.Size = new System.Drawing.Size(240, 474);
            this.gvLogs.TabIndex = 3;
            this.gvLogs.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLogs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 100);
            this.panel3.TabIndex = 2;
            // 
            // btnLogs
            // 
            this.btnLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogs.Location = new System.Drawing.Point(62, 32);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(107, 38);
            this.btnLogs.TabIndex = 1;
            this.btnLogs.Text = "Show Logs";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.controlPanelControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(242, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 576);
            this.panel2.TabIndex = 4;
            // 
            // elevatorMoveTimer
            // 
            this.elevatorMoveTimer.Interval = 20;
            // 
            // controlPanelControl1
            // 
            this.controlPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanelControl1.Location = new System.Drawing.Point(0, 386);
            this.controlPanelControl1.Name = "controlPanelControl1";
            this.controlPanelControl1.Size = new System.Drawing.Size(164, 190);
            this.controlPanelControl1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 576);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.floorsPanel);
            this.Name = "MainForm";
            this.Text = "Elevator";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLogs)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel floorsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Panel panel2;
        private Controls.ControlPanelControl controlPanelControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer elevatorMoveTimer;
        private System.Windows.Forms.DataGridView gvLogs;
    }
}

