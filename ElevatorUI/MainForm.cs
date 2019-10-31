using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore;
using ElevatorCore.Abstract;
using ElevatorUI.Controls;

namespace ElevatorUI
{
    public partial class MainForm : Form
    {
        private readonly Elevator _elevator;
        private const int FloorHeight = 190;
        private int _elevatorStartY;
        private int _floorDif;

        public MainForm()
        {
            InitializeComponent();
            InitializeFloors();
            _elevator = new Elevator();
            controlPanel.Init(SetElevatorOnFloorForFloorControls);
        }

        private void InitializeFloors()
        {
            for (int i = AppSettings.NumberOfFloors - 1; i >= 0; i--)
            {
                var floor = new FloorControl(i, ChangeFloor)
                {
                    Dock = DockStyle.Bottom
                };
                floorsPanel.Controls.Add(floor);
            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            gvLogs.Visible = true;
        }

        private void ChangeFloor(int floorNumber)
        {
            controlPanel.SetFloor(floorNumber);
            SetElevatorOnFloorForFloorControls(floorNumber);
            _elevator.CurrentFloor = floorNumber;
        }

        private void MoveElevatorToFloor(int floorNumber)
        {
            _elevatorStartY = pictureBox1.Location.Y;
            var currentFloor = _elevator.CurrentFloor;

            _floorDif = (currentFloor - floorNumber) * -1;
            ToggleWindowResize(false);

            elevatorMoveTimer.Enabled = true;
            elevatorMoveTimer.Interval = AppSettings.TimerInterval;
            elevatorMoveTimer.Start();
        }

        private void SetElevatorOnFloorForFloorControls(int floorNumber)
        {
            foreach (var ctrl in floorsPanel.Controls)
            {
                if (ctrl is IFloor floor)
                {
                    floor.SetElevatorOnFloorDisplay(floorNumber);
                }
            }
            MoveElevatorToFloor(floorNumber);
            _elevator.CurrentFloor = floorNumber;
        }

        private void elevatorMoveTimer_Tick(object sender, EventArgs e)
        {
            var x = pictureBox1.Location.X;
            var y = pictureBox1.Location.Y;
            var destLocationY = _elevatorStartY - _floorDif * FloorHeight;

            var heightDiff = destLocationY - y;
            if (heightDiff == 0)
            {
                elevatorMoveTimer.Stop();
                elevatorMoveTimer.Enabled = false;
                ToggleWindowResize(true);
                return;
            }

            var nextY = _floorDif > 0 ? y - 1 : y + 1;
            pictureBox1.Location = new Point(x, nextY);
        }

        private void ToggleWindowResize(bool available)
        {
            this.FormBorderStyle = available ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
            MinimizeBox = available;
            MaximizeBox = available;
        }
    }
}