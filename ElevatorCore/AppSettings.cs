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
        /// <summary>
        /// Number of floors in the application
        /// </summary>
        public static int NumberOfFloors { get; private set; }
        /// <summary>
        /// Interval of the timers
        /// </summary>
        public static int TimerInterval => 15;
        /// <summary>
        /// Minimum number of floors
        /// </summary>
        public const int MinimumFloorCount = 2;
        /// <summary>
        /// The height of a single floor
        /// </summary>
        public const int FloorHeight = 190;
        /// <summary>
        /// The floor number that elevator starts on
        /// </summary>
        public const int StartFloor = 0;

        /// <summary>
        /// Sets number of floors
        /// </summary>
        /// <param name="numberOfFloors"></param>
        public static void SetNumberOfFloors(int numberOfFloors)
        {
            NumberOfFloors = numberOfFloors;
        }
    }
}
