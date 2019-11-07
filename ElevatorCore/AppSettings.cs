using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCore
{
    public static class AppSettings
    {
        public static int NumberOfFloors { get; private set; }
        public static int TimerInterval => 15;

        public const int MinimumFloorCount = 2;

        public const int FloorHeight = 190;

        public static void SetNumberOfFloors(int numberOfFloors)
        {
            NumberOfFloors = numberOfFloors;
        }
    }
}
