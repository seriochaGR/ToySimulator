using System;
using ToySimulator.Commands;
using ToySimulator.Enums;

namespace ToySimulator.Utilities
{
    public static class ParserInstructionUtility
    {       

        public static bool TryParsePlaceArgs(string argumentString, ref InstructionArguments arguments)
        {
            var argumentParts = argumentString.Split(',');
            int x;
            int y;
            Orientation facing;

            if (argumentParts.Length == 3 &&
                TryGetCoordinate(argumentParts[0], out x) &&
                TryGetCoordinate(argumentParts[1], out y) &&
                TryGetFacingDirection(argumentParts[2], out facing))
            {
                arguments = new InstructionArguments
                {
                    X = x,
                    Y = y,
                    Facing = facing,
                };

                return true;
            }

            return false;
        }

        private static bool TryGetCoordinate(string coordinate, out int coordinateValue)
        {
            return int.TryParse(coordinate, out coordinateValue);
        }

        private static bool TryGetFacingDirection(string direction, out Orientation facing)
        {
            return Enum.TryParse(direction, true, out facing);
        }
    }
}
