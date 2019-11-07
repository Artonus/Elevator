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
    public partial class NumberInputDialog : Form
    {
        public decimal SelectedNumber { get; private set; }
        public NumberInputDialog(string text, string caption)
        {
            InitializeComponent();
            Text = caption;
            lbQuestion.Text = text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (nudUserInput.Value == default || nudUserInput.Value < AppSettings.MinimumFloorCount)
            {
                //TODO: Inform user about wrong input
                return;
            }

            DialogResult = DialogResult.OK;
            SelectedNumber = nudUserInput.Value;
        }
    }
}
