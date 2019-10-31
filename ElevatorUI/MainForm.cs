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
            _elevator.CurrentFloor = floorNumber;
            controlPanel.SetFloor(floorNumber);
            SetElevatorOnFloorForFloorControls(floorNumber);
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
        }
    }
}
