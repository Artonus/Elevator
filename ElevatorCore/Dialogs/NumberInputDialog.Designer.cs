﻿namespace ElevatorCore.Dialogs
{
    partial class NumberInputDialog
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
            this.btnOk = new System.Windows.Forms.Button();
            this.nudUserInput = new System.Windows.Forms.NumericUpDown();
            this.lbQuestion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudUserInput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(137, 162);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // nudUserInput
            // 
            this.nudUserInput.Location = new System.Drawing.Point(137, 123);
            this.nudUserInput.Name = "nudUserInput";
            this.nudUserInput.Size = new System.Drawing.Size(120, 22);
            this.nudUserInput.TabIndex = 1;
            // 
            // lbQuestion
            // 
            this.lbQuestion.Location = new System.Drawing.Point(12, 9);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(378, 100);
            this.lbQuestion.TabIndex = 2;
            this.lbQuestion.Text = "Please neter the number";
            // 
            // NumberInputDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 197);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.nudUserInput);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NumberInputDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NumberInputDialog";
            ((System.ComponentModel.ISupportInitialize)(this.nudUserInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown nudUserInput;
        private System.Windows.Forms.Label lbQuestion;
    }
}