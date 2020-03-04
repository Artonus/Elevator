using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorCore.Dialogs
{
    /// <summary>
    /// Dialog to ask for numeric user input
    /// </summary>
    public partial class FloorNumberInputDialog : Form
    {
        /// <summary>
        /// Number entered by the user
        /// </summary>
        public decimal SelectedNumber { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="text">Information to the user</param>
        /// <param name="caption">Title of the window</param>
        public FloorNumberInputDialog(string text, string caption)
        {
            InitializeComponent();
            Text = caption;
            lbQuestion.Text = text;
        }

        /// <summary>
        /// Event that handles OK button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // check if it is valid input
            if (nudUserInput.Value < AppSettings.MinimumFloorCount)
            {
                
                lbErrMessage.Visible = true;
                lbErrMessage.Text =
                    $"Please enter the number of floors that is greater or equal {AppSettings.MinimumFloorCount}";
                return;
            }

            DialogResult = DialogResult.OK;
            SelectedNumber = nudUserInput.Value;
        }
    }
}
