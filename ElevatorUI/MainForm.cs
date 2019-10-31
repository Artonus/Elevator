using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore;
using ElevatorUI.Controls;

namespace ElevatorUI
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            InitializeFloors();
        }

        private void InitializeFloors()
        {
            for (int i = AppSettings.NumberOfFloors - 1; i >= 0; i--)
            {
                var floor = new FloorControl(i, ChangeFloor)
                {
                    Dock = DockStyle.Bottom
                };
                this.floorsPanel.Controls.Add(floor);
            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            gvLogs.Visible = true;
        }

        private void ChangeFloor(int floorNumber)
        {
            this.controlPanelControl1.SetFloor(floorNumber);
        }
    }
}
