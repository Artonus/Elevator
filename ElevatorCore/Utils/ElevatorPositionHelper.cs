using System.Windows.Forms.VisualStyles;

namespace ElevatorCore.Utils
{
    /// <summary>
    /// Helper class that contains variables necessary to manage doors opening and closing
    /// </summary>
    public class ElevatorPositionHelper
    {
        /// <summary>
        /// Start position of the elevator
        /// </summary>
        public int StartPosition { get; set; }
        /// <summary>
        /// Destination position of the elevator
        /// </summary>
        public int DestinationPosition { get; set; }
        /// <summary>
        /// Difference between floors
        /// </summary>
        public int FloorDifference { get; set; }
    }
}
