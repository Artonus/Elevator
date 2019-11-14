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
    /// <summary>
    /// control panel of the Elevator
    /// </summary>
    public partial class ControlPanelControl : UserControl, IElevatorController
    {
        /// <summary>
        /// Action to change floor
        /// </summary>
        private Action<int> _changeFloorIfAllowedAction;
        /// <summary>
        /// Default c-tor
        /// </summary>
        public ControlPanelControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes the control buttons and actions required by the control
        /// </summary>
        /// <param name="changeFloorIfAllowed"></param>
        public void Init(Action<int> changeFloorIfAllowed)
        {
            _changeFloorIfAllowedAction = changeFloorIfAllowed;
            // Initialization of the floor buttons 
            InitializeButtons();
        }
        /// <summary>
        /// Initializes the buttons of the floor
        /// </summary>
        private void InitializeButtons()
        {
            var controlWidth = Width;
            for (int i = 0; i < AppSettings.NumberOfFloors; i++)
            {
                var btn = new Button
                {
                    //store number of the floor in the Tag property
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

        /// <summary>
        /// Button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FloorCallClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            // retrieve floor number from Tag property
            var flrNumber = (int)btn?.Tag;
            _changeFloorIfAllowedAction(flrNumber);
        }
        /// <summary>
        /// Sets the display number of the Panel Control
        /// </summary>
        /// <param name="floorNumber"></param>
        public void SetFloor(int floorNumber)
        {
            this.lbCurrentFloor.Text = floorNumber.ToString();
        }
    }
}
