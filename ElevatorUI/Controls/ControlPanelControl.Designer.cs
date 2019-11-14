namespace ElevatorUI.Controls
{
    partial class ControlPanelControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlButtonsPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbCurrentFloor = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 49);
            this.panel1.TabIndex = 0;
            // 
            // controlButtonsPanel
            // 
            this.controlButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlButtonsPanel.Location = new System.Drawing.Point(0, 49);
            this.controlButtonsPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controlButtonsPanel.Name = "controlButtonsPanel";
            this.controlButtonsPanel.Size = new System.Drawing.Size(84, 190);
            this.controlButtonsPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCurrentFloor);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(80, 47);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current floor";
            // 
            // lbCurrentFloor
            // 
            this.lbCurrentFloor.AutoSize = true;
            this.lbCurrentFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbCurrentFloor.Location = new System.Drawing.Point(25, 15);
            this.lbCurrentFloor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCurrentFloor.Name = "lbCurrentFloor";
            this.lbCurrentFloor.Size = new System.Drawing.Size(27, 29);
            this.lbCurrentFloor.TabIndex = 0;
            this.lbCurrentFloor.Text = "0";
            // 
            // ControlPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.controlButtonsPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlPanelControl";
            this.Size = new System.Drawing.Size(84, 239);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel controlButtonsPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbCurrentFloor;
    }
}
