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
            _elevator.Init(ChangeFloor,CloseElevatorDoorsOnFloor, OpenElevatorDoorsOnFloor);
            controlPanel.Init(MoveElevatorIfAllowed);
            InitializeFloors();
            elevatorMoveTimer.Tick += elevatorMoveTimer_Tick;
            elevatorMoveTimer.Interval = AppSettings.TimerInterval;
            worker.DoWork += SaveChangesAndGetData;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void InitializeFloors()
        {
            for (int i = AppSettings.NumberOfFloors - 1; i >= 0; i--)
            {
                var floor = new FloorControl(i, MoveElevatorIfAllowed, _logger, _elevator)
                {
                    Dock = DockStyle.Bottom
                };
                floorsOuterPanel.Controls.Add(floor);
            }
        }

        private void MoveElevatorIfAllowed(int floorNumber)
        {
            _elevator.CallForElevator(floorNumber);
        }

        #region EventHandlers
        private void SaveChangesAndGetData(object sender, DoWorkEventArgs e)
        {
            try
            {
                _session.Commit();
                e.Result = _session.Logs.GetAll().OrderByDescending(l => l.Timestamp).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _logger.LogError(ex.Message);
            }
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                UpdateGridDataSource((List<Log>)e?.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _logger.LogError(ex.Message);
            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy) return;
            
            gvLogs.Visible = true;
            worker.RunWorkerAsync();
        }


        private void elevatorMoveTimer_Tick(object sender, EventArgs e)
        {
            var x = elevatorInShaftPictureBox.Location.X;
            var y = elevatorInShaftPictureBox.Location.Y;

            var heightDiff = _elevator.ElevatorPosition.DestinationPosition - y;
            if (heightDiff == 0)
            {
                EndElevatorMove();
                return;
            }

            var nextY = _elevator.ElevatorPosition.FloorDifference > 0 ? y - 1 : y + 1;
            elevatorInShaftPictureBox.Location = new Point(x, nextY);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var title = CommonMessages.FloorNumberDialogTitle;
            var message = CommonMessages.FloorNumberDialogMessage;

            var numDialog = new FloorNumberInputDialog(message, title);
            var result = numDialog.ShowDialog();
            if (result == DialogResult.OK)
                Init((int)numDialog.SelectedNumber);
            else
                Close();
        }
        #endregion

        private void UpdateGridDataSource<T>(IEnumerable<T> dataList)
        {
            var bindingSource = new BindingSource();
            // collecting all logs and ordering them by timestamp
            bindingSource.DataSource = dataList;
            gvLogs.DataSource = bindingSource;

            gvLogs.Columns[nameof(Log.ID)].Visible = false;
            gvLogs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void ChangeFloor(int floorNumber)
        {
            MoveElevatorToFloor(floorNumber);
        }
        private void MoveElevatorToFloor(int floorNumber)
        {
            var elevatorStartY = elevatorInShaftPictureBox.Location.Y;

            var difference = (_elevator.StartFloor - floorNumber) * -1;

            _elevator.ElevatorPosition = new ElevatorPositionHelper
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
        private void CloseElevatorDoorsOnFloor(int floorNumber)
        {
            foreach (var ctrl in floorsOuterPanel.Controls)
            {
                if (ctrl is IFloor floor)
                {
                    floor.CloseElevatorDoor(floorNumber);
                }
            }
        }
        private void OpenElevatorDoorsOnFloor(int floorNumber)
        {
            foreach (var ctrl in floorsOuterPanel.Controls)
            {
                if (ctrl is IFloor floor)
                {
                    floor.OpenElevatorDoor(floorNumber);
                }
            }
        }

        private void EndElevatorMove()
        {
            elevatorMoveTimer.Stop();
            elevatorMoveTimer.Enabled = false;
            ToggleWindowResize(true);
            _elevator.SetState(new ElevatorDoorsOpening(_elevator, _logger));
            _logger.LogElevatorArrivedAtFloor(_elevator.DestinationFloor);
            SetElevatorDisplay();
        }

        private void SetElevatorDisplay()
        {
            controlPanel.SetFloor(_elevator.DestinationFloor);
            SetElevatorOnFloorForFloorControls(_elevator.DestinationFloor);
        }

        private void ToggleWindowResize(bool available)
        {
            FormBorderStyle = available ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
            MinimizeBox = available;
            MaximizeBox = available;
        }
    }
}