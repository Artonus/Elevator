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
using ElevatorCore.Elevator.Abstract;

namespace ElevatorUI.Controls
{
    public partial class ControlPanelControl : UserControl, IElevatorController
    {
        private Action<int> SetFloorOnButtonClickAction;
        public ControlPanelControl()
        {
            InitializeComponent();
        }

        public void Init(Action<int> setFloorOnButtonClickAction)
        {
            SetFloorOnButtonClickAction = setFloorOnButtonClickAction;
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            var controlWidth = Width;
            for (int i = 0; i < AppSettings.NumberOfFloors; i++)
            {
                var btn = new Button
                {
                    Tag = i,
                    Text = $"Floor {i}",
                    Name = $"btnFloor{i}",
                    Anchor = AnchorStyles.Top,
                    Width = controlWidth,
                    Dock = DockStyle.Top
                };
                btn.Click += FloorCallClick;
                controlButtonsPanel.Controls.Add(btn);
            }
        }

        private void FloorCallClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var flrNumber = (int)btn?.Tag;
            this.tbFloorNumber.Text = flrNumber.ToString();
            SetFloorOnButtonClickAction(flrNumber);
        }

        public void SetFloor(int floorNumber)
        {
            this.tbFloorNumber.Text = floorNumber.ToString();
        }
    }
}
