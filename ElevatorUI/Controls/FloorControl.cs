using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore.Abstract;

namespace ElevatorUI.Controls
{
    public partial class FloorControl : UserControl, IFloor
    {
        private Action<int> CallElevatorAction;
        private int FloorNumber { get; }
        public FloorControl(int floorNumber, Action<int> callElevatorAction)
        {
            InitializeComponent();
            this.FloorNumber = floorNumber;
            this.lbFloor.Text = $"Floor {floorNumber}";
            this.CallElevatorAction = callElevatorAction;
        }

        private void btnCallElevator_Click(object sender, EventArgs e)
        {
            CallElevatorAction(this.FloorNumber);
        }

        public void SetElevatorOnFloorDisplay(int floorNumber)
        {
            this.lbCurrentFloor.Text = floorNumber.ToString();
        }
    }
}
