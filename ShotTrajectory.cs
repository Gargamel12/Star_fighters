using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_fighters
{
    internal class ShotTrajectory
    {
        private double angle;
        private double length;

        public ShotTrajectory()
        {
            // Default values
            Angle = 45; // Initial angle (45 degrees)
            Length = 50; // Initial length
        }

        public double Angle
        {
            get { return angle; }
            set
            {
                // Ensure that the angle stays within the range of 0 to 90 degrees
                angle = Math.Max(0, Math.Min(90, value));
            }
        }

        public double Length
        {
            get { return length; }
            set
            {
                // Ensure that the length is non-negative
                length = Math.Max(0, Math.Min(100, value));
            }
        }
    }
}
