using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorUI.Controls
{
    public partial class FloorControl : UserControl
    {
        private Action<int> callElevatorAction;
        public int FloorNumber { get; private set; }
        public FloorControl(int floorNumber, Action<int> callElevatorAction)
        {
            InitializeComponent();
            FloorNumber = floorNumber;
            this.lbFloor.Text = $"Floor {floorNumber}";
            this.callElevatorAction = callElevatorAction;
        }

        private void btnCallElevator_Click(object sender, EventArgs e)
        {
            callElevatorAction(this.FloorNumber);
        }
    }
}
