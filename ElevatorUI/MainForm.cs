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
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Dialogs;
using ElevatorCore.Elevator;
using ElevatorUI.Controls;

namespace ElevatorUI
{
    public partial class MainForm : Form
    {
        private Elevator _elevator;
        private const int FloorHeight = 190;
        private int _elevatorStartY;
        private int _floorDif;

        public MainForm()
        {
            InitializeComponent();
            
        }
        private void Init(int numberOfFloors)
        {
            AppSettings.SetNumberOfFloors(numberOfFloors);
            InitializeFloors();
            _elevator = new Elevator(this.elevatorInShaftPictureBox);
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
                floorsOuterPanel.Controls.Add(floor);
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
            _elevatorStartY = elevatorInShaftPictureBox.Location.Y;
            var currentFloor = _elevator.CurrentFloor;

            _floorDif = (currentFloor - floorNumber) * -1;
            ToggleWindowResize(false);

            elevatorMoveTimer.Enabled = true;
            elevatorMoveTimer.Interval = AppSettings.TimerInterval;
            elevatorMoveTimer.Start();
        }

        private void SetElevatorOnFloorForFloorControls(int floorNumber)
        {
            foreach (var ctrl in floorsOuterPanel.Controls)
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
            var x = elevatorInShaftPictureBox.Location.X;
            var y = elevatorInShaftPictureBox.Location.Y;
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
            elevatorInShaftPictureBox.Location = new Point(x, nextY);
        }

        private void ToggleWindowResize(bool available)
        {
            this.FormBorderStyle = available ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
            MinimizeBox = available;
            MaximizeBox = available;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var title = "Number of floors";
            var message =
                "Please enter how many floors you want to have in the elevator. But please be sensible cause they may not fit onto your screen.\nAdvised is 5 floors max with 100% scaling.";
            var numDialog = new NumberInputDialog(message, title);
            var result = numDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Init((int)numDialog.SelectedNumber);
            }
            else
            {
                Close();
            }
        }
    }
}