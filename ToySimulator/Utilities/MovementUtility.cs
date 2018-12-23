using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;

namespace ToySimulator.Utilities
{
    public static class MovementUtility
    {        

        public static int GetYMovement(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.North:
                    return 1;
                case Orientation.South:
                    return -1;
                default:
                    return 0;

            }

        }

        public static int GetXMovement(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.East:
                    return 1;
                case Orientation.West:
                    return -1;
                default:
                    return 0;

            }

        }
    }
}
