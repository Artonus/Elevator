using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore;
using ElevatorCore.DataAccess;
using ElevatorCore.DataAccess.Abstract;
using ElevatorCore.DataAccess.Concrete;
using ElevatorCore.DataAccess.Model;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Dialogs;
using ElevatorCore.Elevator;
using ElevatorCore.Elevator.Concrete;
using ElevatorCore.Utils;
using ElevatorCore.Utils.Abstract;
using ElevatorUI.Controls;

namespace ElevatorUI
{
    public partial class MainForm : Form
    {
        private ILogger _logger;
        private ISession _session;
        private Elevator _elevator;
        private ElevatorPositionHelper _elevatorPosition;
        public MainForm()
        {
            InitializeComponent();
        }
        private void Init(int numberOfFloors)
        {
            AppSettings.SetNumberOfFloors(numberOfFloors);
            
            _session = new Session(new ElevatorContext());
            _logger = Logger.Instance(_session);
            _elevator = new Elevator(_logger);
            controlPanel.Init(MoveElevatorIfAllowed);
            InitializeFloors();
            elevatorMoveTimer.Tick += elevatorMoveTimer_Tick;
            elevatorMoveTimer.Interval = AppSettings.TimerInterval;
        }

        private void InitializeFloors()
        {
            for (int i = AppSettings.NumberOfFloors - 1; i >= 0; i--)
            {
                var floor = new FloorControl(i, MoveElevatorIfAllowed, _logger)
                {
                    Dock = DockStyle.Bottom
                };
                floorsOuterPanel.Controls.Add(floor);
            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            try
            {
                _session.Commit();
                gvLogs.Visible = true;
                UpdateGridDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateGridDataSource()
        {
            var bindingSource = new BindingSource();
            var list = _session.Logs.GetAllLogs().ToList();
            bindingSource.DataSource = list;
            gvLogs.DataSource = bindingSource;

            gvLogs.Columns[nameof(Log.ID)].Visible = false;
            gvLogs.Sort(gvLogs.Columns[nameof(Log.ID)], ListSortDirection.Descending);
        }

        private void MoveElevatorIfAllowed(int floorNumber)
        {
            _elevator.CallForElevator(floorNumber, ChangeFloor);
        }

        private void ChangeFloor(int floorNumber)
        {
            controlPanel.SetFloor(floorNumber);
            SetElevatorOnFloorForFloorControls(floorNumber);
            MoveElevatorToFloor(floorNumber);
        }
        private void MoveElevatorToFloor(int floorNumber)
        {
            var elevatorStartY = elevatorInShaftPictureBox.Location.Y;

            var difference = (_elevator.CurrentFloor - floorNumber) * -1;

            _elevatorPosition = new ElevatorPositionHelper
            {
                StartPosition = elevatorStartY,
                FloorDifference = difference,
                DestinationPosition = elevatorStartY - difference * AppSettings.FloorHeight
            };
            ToggleWindowResize(false);

            elevatorMoveTimer.Enabled = true;
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
        }

        private void elevatorMoveTimer_Tick(object sender, EventArgs e)
        {
            var x = elevatorInShaftPictureBox.Location.X;
            var y = elevatorInShaftPictureBox.Location.Y;

            var heightDiff = _elevatorPosition.DestinationPosition - y;
            if (heightDiff == 0)
            {
                elevatorMoveTimer.Stop();
                elevatorMoveTimer.Enabled = false;
                ToggleWindowResize(true);
                _elevator.SetState(new ElevatorStationary(_elevator, _logger));
                _logger.LogElevatorArrivedAtFloor(_elevator.CurrentFloor);
                return;
            }

            var nextY = _elevatorPosition.FloorDifference > 0 ? y - 1 : y + 1;
            elevatorInShaftPictureBox.Location = new Point(x, nextY);
        }

        private void ToggleWindowResize(bool available)
        {
            FormBorderStyle = available ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
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
                Init((int)numDialog.SelectedNumber);
            else
                Close();

        }
    }
}