using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Elevator.Concrete;

namespace ElevatorCore.Elevator
{
    public class Elevator
    {
        private IElevatorState _currentState;
        private PictureBox _elevatorImage;
        public int CurrentFloor { get; set; }
        public Elevator()
        {
            _currentState = new ElevatorStationary(this);
        }
        public void SetState(IElevatorState elevatorState)
        {
            _currentState = elevatorState;
        }

        public void CallForElevator(int floorNumber, Action<int> elevatorCalledAction)
        {
            _currentState.MoveElevator(floorNumber, elevatorCalledAction);
        }
    }
}
