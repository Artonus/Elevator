using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Utils.Abstract;

namespace ElevatorUI.Controls
{
    public partial class FloorControl : UserControl, IFloor
    {
        private readonly Action<int> _callElevatorAction;
        private readonly ILogger _logger;
        private int FloorNumber { get; }
        public FloorControl(int floorNumber, Action<int> callElevatorAction, ILogger logger)
        {
            InitializeComponent();
            FloorNumber = floorNumber;
            lbFloor.Text = $"Floor {floorNumber}";
            _callElevatorAction = callElevatorAction;
            _logger = logger;
        }

        private void btnCallElevator_Click(object sender, EventArgs e)
        {
            _logger.LogElevatorCalledToFloor(this.FloorNumber);
            _callElevatorAction(this.FloorNumber);
        }

        public void SetElevatorOnFloorDisplay(int floorNumber)
        {
            this.lbCurrentFloor.Text = floorNumber.ToString();
        }

        public void CloseElevatorDoor(int floorNumber)
        {
            throw new NotImplementedException();
        }

        public void OpenElevatorDoor(int floorNumber)
        {

            throw new NotImplementedException();
        }
    }
}
