using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorCore.Elevator.Abstract;
using ElevatorCore.Utils.Abstract;

namespace ElevatorCore.Elevator.Concrete
{
    public class ElevatorStationary : IElevatorState
    {
        private readonly Elevator _elevator;
        private readonly ILogger _logger;
        public ElevatorStationary(Elevator elevator, ILogger logger)
        {
            _logger = logger;
            _elevator = elevator;
        }
        public void MoveElevator(int floorNumber, Action<int> moveElevatorAction)
        {
            _logger.LogElevatorStartedMoving(floorNumber);
            _elevator.SetState(new ElevatorMoving(_elevator, _logger));
            moveElevatorAction(floorNumber);
            _elevator.CurrentFloor = floorNumber;
        }
    }
}
