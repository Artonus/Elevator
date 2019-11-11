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

        public static string GetElevatorClosingDoorsMessage(int floorNumber)
        {
            return $"The doors of the elevator are closing at floor {floorNumber}";
        }

        public static string GetElevatorDoorsAlreadyClosingMessage(int floorNumber)
        {
            return $"The elevator is already closing the door at floor {floorNumber}, call has been canceled.";
        }

        public static string GetElevatorOpeningDoorsMessage(int floorNumber)
        {
            return $"The doors of the elevator are opening at floor {floorNumber}";
        }

        public static string GetElevatorDoorsAlreadyOpeningMessage(int floorNumber)
        {
            return $"The elevator is already opening the door at floor {floorNumber}, call has been canceled.";
        }


        public static string FloorNumberDialogMessage =>
            "Please enter how many floors you want to have in the elevator. But please be sensible cause they may not fit onto your screen.\nAdvised is 5 floors max with 100% scaling.";

        public static string FloorNumberDialogTitle => "Select number of floors";
    }
}
