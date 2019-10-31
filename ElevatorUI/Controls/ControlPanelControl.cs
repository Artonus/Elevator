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
using ElevatorCore.Abstract;

namespace ElevatorUI.Controls
{
    public partial class ControlPanelControl : UserControl, IElevatorController
    {
        public ControlPanelControl()
        {
            InitializeComponent();

            InitializeButtons();
        }

        private void InitializeButtons()
        {
            for (int i = AppSettings.NumberOfFloors -1; i >= 0; i--)
            {
                var btn = new Button
                {
                    Tag = i,
                    Text = $"Floor {i}",
                    Name = $"btnFloor{i}",
                    Dock = DockStyle.Bottom
                };
                btn.Click += FloorCallClick;
                this.Controls.Add(btn);
            }
        }

        private void FloorCallClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            this.tbFloorNumber.Text = ((int) btn?.Tag).ToString();
        }

        public void SetFloor(int floorNumber)
        {
            this.tbFloorNumber.Text = floorNumber.ToString();
        }
    }
}
