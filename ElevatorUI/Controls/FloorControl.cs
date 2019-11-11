using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore;
using ElevatorCore.Elevator;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Elevator.Concrete;
using ElevatorCore.Utils;
using ElevatorCore.Utils.Abstract;

namespace ElevatorUI.Controls
{
    public partial class FloorControl : UserControl, IFloor
    {
        private readonly Action<int> _callElevatorAction;
        private readonly ILogger _logger;
        private readonly Elevator _elevator;
        private DoorsPositionHelper _rightDoorsHelper;
        private DoorsPositionHelper _leftDoorsHelper;
        private int FloorNumber { get; }
        public FloorControl(int floorNumber, Action<int> callElevatorAction, ILogger logger, Elevator elevator)
        {
            InitializeComponent();
            FloorNumber = floorNumber;
            lbFloor.Text = $"Floor {floorNumber}";
            _callElevatorAction = callElevatorAction;
            _logger = logger;
            _elevator = elevator;

            if (AppSettings.StartFloor == floorNumber)
            {
                SetElevatorDoorOpen();
            }

            doorsTimer.Interval = AppSettings.TimerInterval;
            doorsTimer.Enabled = false;
            doorsTimer.Tick += DoorOpenCloseTick;
        }

        private void SetElevatorDoorOpen()
        {
            leftDoorPanel.Location = new Point(rightDoorPanel.Width * -1, rightDoorPanel.Location.Y);
            rightDoorPanel.Location = new Point(elevatorBox.Width, rightDoorPanel.Location.Y);
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
            if (floorNumber != this.FloorNumber)
                return;
            
            _rightDoorsHelper = new DoorsPositionHelper
            {
                StartPosition = rightDoorPanel.Location.X,
                DestinationPosition = elevatorBox.Width - rightDoorPanel.Width,
                Opening = false
            };
            _leftDoorsHelper = new DoorsPositionHelper
            {
                StartPosition = leftDoorPanel.Location.X,
                DestinationPosition = 0,
                Opening = false
            };
            doorsTimer.Enabled = true;
            doorsTimer.Start();
        }

        public void OpenElevatorDoor(int floorNumber)
        {
            if (floorNumber != this.FloorNumber)
                return;

            _rightDoorsHelper = new DoorsPositionHelper
            {
                StartPosition = rightDoorPanel.Location.X,
                DestinationPosition = elevatorBox.Width,
                Opening = true
            };
            _leftDoorsHelper = new DoorsPositionHelper
            {
                StartPosition = leftDoorPanel.Location.X,
                DestinationPosition = leftDoorPanel.Width * -1,
                Opening = true
            };
            doorsTimer.Enabled = true;
            doorsTimer.Start();
        }

        private void DoorOpenCloseTick(object sender, EventArgs e)
        {
            var leftLocationX = leftDoorPanel.Location.X;
            var leftLocationY = leftDoorPanel.Location.Y;
            var rightLocationX = rightDoorPanel.Location.X;
            var rightLocationY = rightDoorPanel.Location.Y;

            var leftWidthDiff = _leftDoorsHelper.DestinationPosition - leftLocationX;
            var rightWidthDiff = _rightDoorsHelper.DestinationPosition - rightLocationX;
            if (leftWidthDiff == 0 && rightWidthDiff == 0)
            {
                _leftDoorsHelper.ActionEnded = _rightDoorsHelper.ActionEnded = true;
                DoorsOpenedClosed(_leftDoorsHelper.Opening);
                return;
            }

            var leftNextX = _leftDoorsHelper.Opening ? leftLocationX - 1 : leftLocationX + 1;
            leftDoorPanel.Location = new Point(leftNextX, leftLocationY);

            var rightNextX = _rightDoorsHelper.Opening ? rightLocationX + 1 : rightLocationX - 1;
            rightDoorPanel.Location = new Point(rightNextX, rightLocationY);
        }

        private void DoorsOpenedClosed(bool opened)
        {
            doorsTimer.Stop();
            doorsTimer.Enabled = false;

            var state = opened ? (IElevatorState) new ElevatorStationary(_elevator, _logger) : new ElevatorMoving(_elevator, _logger);
            _elevator.SetState(state);
        }
    }
}
