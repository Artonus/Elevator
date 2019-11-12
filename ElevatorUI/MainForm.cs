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
    /// <summary>
    /// Main window of the application
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Logger instance
        /// </summary>
        private ILogger _logger;
        /// <summary>
        /// Session instance
        /// </summary>
        private ISession _session;
        /// <summary>
        /// Elevator instance
        /// </summary>
        private Elevator _elevator;
        
        /// <summary>
        /// Default c-tor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes the properties of the application
        /// </summary>
        /// <param name="numberOfFloors"></param>
        private void Init(int numberOfFloors)
        {
            AppSettings.SetNumberOfFloors(numberOfFloors);
            // initialize session
            _session = new Session(new ElevatorContext());
            // initialize logger
            _logger = Logger.Instance(_session);
            // initialize elevator
            _elevator = new Elevator(_logger);
            _elevator.Init(MoveElevatorToFloor,CloseElevatorDoorsOnFloor, OpenElevatorDoorsOnFloor);
            // initialize control panel
            controlPanel.Init(MoveElevatorIfAllowed);
            // create floors
            InitializeFloors();
            // set timer properties and assign tick function
            elevatorMoveTimer.Tick += elevatorMoveTimer_Tick;
            elevatorMoveTimer.Interval = AppSettings.TimerInterval;
            // assign events to background worker
            worker.DoWork += SaveChangesAndGetData;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }
        /// <summary>
        /// Creates required number of floors
        /// </summary>
        private void InitializeFloors()
        {
            for (int i = AppSettings.NumberOfFloors - 1; i >= 0; i--)
            {
                var floor = new FloorControl(i, MoveElevatorIfAllowed, _logger, _elevator)
                {
                    // dock floors to the bottom of the screen
                    Dock = DockStyle.Bottom
                };
                // add floor to controls of the panel
                floorsOuterPanel.Controls.Add(floor);
            }
        }
        /// <summary>
        /// Move elevator if is in the right state
        /// </summary>
        /// <param name="floorNumber"></param>
        private void MoveElevatorIfAllowed(int floorNumber)
        {
            _elevator.CallForElevator(floorNumber);
        }

        #region Events
        /// <summary>
        /// Saves logs to the database and retrieves data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChangesAndGetData(object sender, DoWorkEventArgs e)
        {
            try
            {
                // save changes
                _session.Commit();
                // retrieve all logs and order them by their date
                // assign them to the result of the function
                e.Result = _session.Logs.GetAll().OrderByDescending(l => l.Timestamp).ToList();
            }
            catch (Exception ex)
            {
                //catch possible errors, display and log them
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _logger.LogError(ex.Message);
            }
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                // retrieve the result of the background worker and update the grid data source 
                // cast e.Result to List of type Log
                UpdateGridDataSource((List<Log>)e?.Result);
            }
            catch (Exception ex)
            {
                //catch possible errors, display and log them
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _logger.LogError(ex.Message);
            }
        }
        /// <summary>
        /// Event handler of the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogs_Click(object sender, EventArgs e)
        {
            // if background worker is running abort hte execution
            if (worker.IsBusy) return;
            
            // show data grid view and run background worker to retrieve data
            gvLogs.Visible = true;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Timer tick event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elevatorMoveTimer_Tick(object sender, EventArgs e)
        {
            // get the current position of the elevator
            var x = elevatorInShaftPictureBox.Location.X;
            var y = elevatorInShaftPictureBox.Location.Y;

            // calculate difference between current and end position
            var heightDiff = _elevator.ElevatorPosition.DestinationPosition - y;
            // if is equal to 0 end the timer execution
            if (heightDiff == 0)
            {
                EndElevatorMove();
                return;
            }
            // move elevator in correct direction
            var nextY = _elevator.ElevatorPosition.FloorDifference > 0 ? y - 1 : y + 1;
            elevatorInShaftPictureBox.Location = new Point(x, nextY);
        }
        /// <summary>
        /// Onload event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            var title = CommonMessages.FloorNumberDialogTitle;
            var message = CommonMessages.FloorNumberDialogMessage;
            // display dialog asking user how many floors shoud elevator have
            var numDialog = new FloorNumberInputDialog(message, title);
            var result = numDialog.ShowDialog();
            // if result is correct initialize window, otherwise close the app
            if (result == DialogResult.OK)
                Init((int)numDialog.SelectedNumber);
            else
                Close();
        }
        #endregion

        /// <summary>
        /// updates the data source of the grid view
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList"></param>
        private void UpdateGridDataSource<T>(IEnumerable<T> dataList)
        {
            var bindingSource = new BindingSource { DataSource = dataList };
            // collecting all logs and ordering them by timestamp
            gvLogs.DataSource = bindingSource;
            // gide column that contains ID of the log
            gvLogs.Columns[nameof(Log.ID)].Visible = false;
            // set size of the columns to fit all the data
            gvLogs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        /// <summary>
        /// Starts the movement of te elevator
        /// </summary>
        /// <param name="floorNumber"></param>
        private void MoveElevatorToFloor(int floorNumber)
        {
            
            var elevatorStartY = elevatorInShaftPictureBox.Location.Y;

            var difference = (_elevator.StartFloor - floorNumber) * -1;
            // set the required data to move the elevetor
            _elevator.ElevatorPosition = new ElevatorPositionHelper
            {
                StartPosition = elevatorStartY,
                FloorDifference = difference,
                DestinationPosition = elevatorStartY - difference * AppSettings.FloorHeight
            };
            // lock window scaling
            ToggleWindowResize(false);
            // start timer
            elevatorMoveTimer.Enabled = true;
            elevatorMoveTimer.Start();
        }
        /// <summary>
        /// Sets the display on floors
        /// </summary>
        /// <param name="floorNumber"></param>
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
        /// <summary>
        /// Closes the doors on the floor
        /// </summary>
        /// <param name="floorNumber"></param>
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
        /// <summary>
        /// Opens the doors on the floor
        /// </summary>
        /// <param name="floorNumber"></param>
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
        /// <summary>
        /// Finishes the move of the elevator
        /// </summary>
        private void EndElevatorMove()
        {
            // stop the timer
            elevatorMoveTimer.Stop();
            elevatorMoveTimer.Enabled = false;
            // unlock window resize
            ToggleWindowResize(true);
            // change the state of the elevator
            _elevator.SetState(new ElevatorDoorsOpening(_elevator, _logger));
            _logger.LogElevatorArrivedAtFloor(_elevator.DestinationFloor);
            SetElevatorDisplay();
        }
        /// <summary>
        /// Sets the display for the floors and elevator control panel
        /// </summary>
        private void SetElevatorDisplay()
        {
            // set the display of the control panel
            controlPanel.SetFloor(_elevator.DestinationFloor);
            // set the display on the floors
            SetElevatorOnFloorForFloorControls(_elevator.DestinationFloor);
        }
        /// <summary>
        /// Locks the scaling of the window to prevent unwanted behaviour of the elevator
        /// </summary>
        private void ToggleWindowResize(bool available)
        {
            // lock/unlock sizing of the window
            FormBorderStyle = available ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
            // lock/unlock minimize and maximize buttons
            MinimizeBox = available;
            MaximizeBox = available;
        }
    }
}