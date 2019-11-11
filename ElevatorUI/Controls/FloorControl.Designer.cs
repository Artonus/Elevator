namespace ElevatorUI.Controls
{
    partial class FloorControl
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
            this.components = new System.ComponentModel.Container();
            this.lbFloor = new System.Windows.Forms.Label();
            this.btnCallElevator = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbCurrentFloor = new System.Windows.Forms.Label();
            this.pbElevator = new System.Windows.Forms.PictureBox();
            this.leftDoorPanel = new System.Windows.Forms.PictureBox();
            this.rightDoorPanel = new System.Windows.Forms.PictureBox();
            this.elevatorBox = new System.Windows.Forms.Panel();
            this.doorsTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbElevator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftDoorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightDoorPanel)).BeginInit();
            this.elevatorBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFloor
            // 
            this.lbFloor.AutoSize = true;
            this.lbFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbFloor.Location = new System.Drawing.Point(371, 59);
            this.lbFloor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFloor.Name = "lbFloor";
            this.lbFloor.Size = new System.Drawing.Size(125, 24);
            this.lbFloor.TabIndex = 0;
            this.lbFloor.Text = "Floor number";
            // 
            // btnCallElevator
            // 
            this.btnCallElevator.Location = new System.Drawing.Point(375, 108);
            this.btnCallElevator.Margin = new System.Windows.Forms.Padding(2);
            this.btnCallElevator.Name = "btnCallElevator";
            this.btnCallElevator.Size = new System.Drawing.Size(115, 28);
            this.btnCallElevator.TabIndex = 1;
            this.btnCallElevator.Text = "Call Elevator";
            this.btnCallElevator.UseVisualStyleBackColor = true;
            this.btnCallElevator.Click += new System.EventHandler(this.btnCallElevator_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCurrentFloor);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(252, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(86, 58);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current floor";
            // 
            // lbCurrentFloor
            // 
            this.lbCurrentFloor.AutoSize = true;
            this.lbCurrentFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbCurrentFloor.Location = new System.Drawing.Point(21, 19);
            this.lbCurrentFloor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCurrentFloor.Name = "lbCurrentFloor";
            this.lbCurrentFloor.Size = new System.Drawing.Size(36, 37);
            this.lbCurrentFloor.TabIndex = 0;
            this.lbCurrentFloor.Text = "0";
            // 
            // pbElevator
            // 
            this.pbElevator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbElevator.Image = global::ElevatorUI.Properties.Resources.openElevator;
            this.pbElevator.Location = new System.Drawing.Point(0, 0);
            this.pbElevator.Margin = new System.Windows.Forms.Padding(0);
            this.pbElevator.Name = "pbElevator";
            this.pbElevator.Size = new System.Drawing.Size(110, 150);
            this.pbElevator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbElevator.TabIndex = 2;
            this.pbElevator.TabStop = false;
            // 
            // leftDoorPanel
            // 
            this.leftDoorPanel.Image = global::ElevatorUI.Properties.Resources.LeftDoor;
            this.leftDoorPanel.Location = new System.Drawing.Point(0, 0);
            this.leftDoorPanel.Name = "leftDoorPanel";
            this.leftDoorPanel.Size = new System.Drawing.Size(55, 150);
            this.leftDoorPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftDoorPanel.TabIndex = 4;
            this.leftDoorPanel.TabStop = false;
            // 
            // rightDoorPanel
            // 
            this.rightDoorPanel.Image = global::ElevatorUI.Properties.Resources.RightDoor;
            this.rightDoorPanel.Location = new System.Drawing.Point(55, 0);
            this.rightDoorPanel.Name = "rightDoorPanel";
            this.rightDoorPanel.Size = new System.Drawing.Size(55, 150);
            this.rightDoorPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightDoorPanel.TabIndex = 5;
            this.rightDoorPanel.TabStop = false;
            // 
            // elevatorBox
            // 
            this.elevatorBox.Controls.Add(this.leftDoorPanel);
            this.elevatorBox.Controls.Add(this.rightDoorPanel);
            this.elevatorBox.Controls.Add(this.pbElevator);
            this.elevatorBox.Location = new System.Drawing.Point(50, 18);
            this.elevatorBox.Margin = new System.Windows.Forms.Padding(0);
            this.elevatorBox.Name = "elevatorBox";
            this.elevatorBox.Size = new System.Drawing.Size(110, 150);
            this.elevatorBox.TabIndex = 6;
            // 
            // FloorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.elevatorBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCallElevator);
            this.Controls.Add(this.lbFloor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(500, 190);
            this.MinimumSize = new System.Drawing.Size(380, 190);
            this.Name = "FloorControl";
            this.Size = new System.Drawing.Size(498, 188);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbElevator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftDoorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightDoorPanel)).EndInit();
            this.elevatorBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFloor;
        private System.Windows.Forms.Button btnCallElevator;
        private System.Windows.Forms.PictureBox pbElevator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbCurrentFloor;
        private System.Windows.Forms.PictureBox leftDoorPanel;
        private System.Windows.Forms.PictureBox rightDoorPanel;
        private System.Windows.Forms.Panel elevatorBox;
        private System.Windows.Forms.Timer doorsTimer;
    }
}
