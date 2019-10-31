using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Abstract;
using ElevatorCore.Concrete;

namespace ElevatorCore
{
    public class Elevator
    {
        public IElevatorState CurrentState { get; private set; }

        public int CurrentFloor { get; set; }
        public Elevator()
        {
            this.CurrentState = new ElevatorStationary(this);
        }
        public void SetState(IElevatorState elevatorState)
        {
            this.CurrentState = elevatorState;
        }
    }

    
}
