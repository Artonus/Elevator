using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore.Utils
{
    public static class CommonMessages
    {
        public static string GetElevatorArrivedMessage(int floorNumber)
        {
            return $"Elevator has arrived at floor {floorNumber}";
        }

        public static string GetElevatorCalledToFloorMessage(int floorNumber)
        {
            return $"Elevator has been called to floor {floorNumber}";
        }

        public static string GetElevatorStartedMovingMessage(int floorNumber)
        {
            return $"Elevator started moving to floor {floorNumber}";
        }

        public static string GetErrorMessage(string error)
        {
            return $"Program has encountered an error: \n{error}";
        }

        public static string GetElevatorAlreadyMovingMessage(int floorNumber)
        {
            return $"The elevator is already moving to the floor {floorNumber}, call has been canceled.";
        }
    }
}
