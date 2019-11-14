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
    /// <summary>
    /// Represents the single floor
    /// </summary>
    public partial class FloorControl : UserControl, IFloor
    {
        /// <summary>
        /// Action to call elevator
        /// </summary>
        private readonly Action<int> _callElevatorAction;
        /// <summary>
        /// Logger instance
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Elevator instance
        /// </summary>
        private readonly Elevator _elevator;
        /// <summary>
        /// Position helper of the right door panel
        /// </summary>
        private DoorsPositionHelper _rightDoorsHelper;
        /// <summary>
        /// Position helper of the left door panel
        /// </summary>
        private DoorsPositionHelper _leftDoorsHelper;
        /// <summary>
        /// Number of current floor
        /// </summary>
        private int FloorNumber { get; }
        /// <summary>
        /// Default c-tor
        /// </summary>
        /// <param name="floorNumber">Number of floor</param>
        /// <param name="callElevatorAction">Action to call elevator to floor</param>
        /// <param name="logger">Logger instance</param>
        /// <param name="elevator">Elevator instances</param>
        public FloorControl(int floorNumber, Action<int> callElevatorAction, ILogger logger, Elevator elevator)
        {
            InitializeComponent();
            FloorNumber = floorNumber;
            lbFloor.Text = $"Floor {floorNumber}";
            _callElevatorAction = callElevatorAction;
            _logger = logger;
            _elevator = elevator;
            // if current floor is start floor set the doors open
            if (AppSettings.StartFloor == floorNumber)
            {
                SetElevatorDoorOpen();
            }
            // set timer properties
            doorsTimer.Interval = AppSettings.TimerInterval;
            doorsTimer.Enabled = false;
            doorsTimer.Tick += DoorOpenCloseTick;
        }

        /// <summary>
        /// Set position of door panels to make them open
        /// </summary>
        private void SetElevatorDoorOpen()
        {
            leftDoorPanel.Location = new Point(rightDoorPanel.Width * -1, rightDoorPanel.Location.Y);
            rightDoorPanel.Location = new Point(elevatorBox.Width, rightDoorPanel.Location.Y);
        }
        /// <summary>
        /// Event of button clock to call the elevator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallElevator_Click(object sender, EventArgs e)
        {
            // log event
            _logger.LogElevatorCalledToFloor(this.FloorNumber);
            // call elevator at MainForm
            _callElevatorAction(this.FloorNumber);
        }
        /// <summary>
        /// Sets the floor display value
        /// </summary>
        /// <param name="floorNumber"></param>
        public void SetElevatorOnFloorDisplay(int floorNumber)
        {
            this.lbCurrentFloor.Text = floorNumber.ToString();
        }
        /// <summary>
        /// Starts the process of closing elevator doors
        /// </summary>
        /// <param name="floorNumber"></param>
        public void CloseElevatorDoor(int floorNumber)
        {
            // if the request was to another floor abort the action
            if (floorNumber != this.FloorNumber)
                return;
            // set start and end position of the elevator doors
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
            // start timer
            doorsTimer.Enabled = true;
            doorsTimer.Start();
        }

        /// <summary>
        /// Starts the process of opening elevator doors
        /// </summary>
        /// <param name="floorNumber"></param>
        public void OpenElevatorDoor(int floorNumber)
        {
            // if the request was to another floor abort the action
            if (floorNumber != FloorNumber)
                return;
            // set start and end position of the elevator doors
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
            // start timer
            doorsTimer.Enabled = true;
            doorsTimer.Start();
        }
        /// <summary>
        /// Timer tick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoorOpenCloseTick(object sender, EventArgs e)
        {
            // determine current position of the doors
            var leftLocationX = leftDoorPanel.Location.X;
            var leftLocationY = leftDoorPanel.Location.Y;
            var rightLocationX = rightDoorPanel.Location.X;
            var rightLocationY = rightDoorPanel.Location.Y;
            // calculate difference between current position and destination position
            var leftWidthDiff = _leftDoorsHelper.DestinationPosition - leftLocationX;
            var rightWidthDiff = _rightDoorsHelper.DestinationPosition - rightLocationX;
            // if difference is 0 stop the timer
            if (leftWidthDiff == 0 && rightWidthDiff == 0)
            {
                _leftDoorsHelper.ActionEnded = _rightDoorsHelper.ActionEnded = true;
                DoorsOpenedClosed(_leftDoorsHelper.Opening);
                return;
            }
            // move door panels in correct direction based on if they are opening or not
            var leftNextX = _leftDoorsHelper.Opening ? leftLocationX - 1 : leftLocationX + 1;
            leftDoorPanel.Location = new Point(leftNextX, leftLocationY);

            var rightNextX = _rightDoorsHelper.Opening ? rightLocationX + 1 : rightLocationX - 1;
            rightDoorPanel.Location = new Point(rightNextX, rightLocationY);
        }
        /// <summary>
        /// End action to the timer
        /// </summary>
        /// <param name="opened"></param>
        private void DoorsOpenedClosed(bool opened)
        {
            // stop timer
            doorsTimer.Stop();
            doorsTimer.Enabled = false;
            // change state of the elevator, if the next elevator state will be ElevatorMoving it will
            // auto trigger the function to move elevator do selected floor
            var state = opened ? (IElevatorState) new ElevatorStationaryState(_elevator, _logger) : new ElevatorMovingState(_elevator, _logger);

            _elevator.SetState(state);
        }
    }
}
