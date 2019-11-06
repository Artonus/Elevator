using System;
using System.Collections.Generic;
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
        public IElevatorState CurrentState { get; private set; }
        private PictureBox _elevatorImage;

        public int CurrentFloor { get; set; }
        public Elevator(PictureBox elevatorImage)
        {
            this._elevatorImage = elevatorImage;
            this.CurrentState = new ElevatorStationary(this);
        }
        public void SetState(IElevatorState elevatorState)
        {
            this.CurrentState = elevatorState;
        }
    }

    
}
