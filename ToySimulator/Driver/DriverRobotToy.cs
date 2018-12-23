using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;
using ToySimulator.Tabletop;
using ToySimulator.Toys;
using ToySimulator.Utilities;

namespace ToySimulator.Driver
{
    public class DriverRobotToy : IDriverToy
    {
        private IToy robotToy { get; }
        private ITabletop tabletop { get; }

        public DriverRobotToy(IToy toy, ITabletop tabletop)
        {
            robotToy = toy;
            this.tabletop = tabletop;
        }

        public bool Placing(int x, int y, Orientation orientation)
        {
            if (tabletop.IsValidPosition(x, y))
            {
                robotToy.Place(x, y, orientation);
                return true;
            }

            return false;
        }

        public bool Movement()
        {
            if (robotToy.IsToyPlaced())
            {
                int xDirection = MovementUtility.GetXMovement(robotToy.GetFacing());
                if (xDirection != 0){
                    var xPosition = robotToy.GetStep() * xDirection;
                    if (tabletop.IsValidPosition(robotToy.GetXPosition() + xPosition, robotToy.GetYPosition()))
                    {
                        robotToy.XMovement(xDirection);
                        return true;
                    }
                }
                else
                {
                    int yDirection = MovementUtility.GetYMovement(robotToy.GetFacing());
                    if (yDirection != 0)
                    {
                        var yPosition = robotToy.GetStep() * yDirection;
                        if (tabletop.IsValidPosition(robotToy.GetXPosition(), robotToy.GetYPosition() + yPosition))
                        {
                            robotToy.YMovement(yDirection);
                            return true;
                        }
                    }
                }                
            }

            return false;
        }               

        public bool Right()
        {
            if (robotToy.IsToyPlaced())
            {
                robotToy.Right();
                return true;
            }

            return false;
        }

        public bool Left()
        {
            if (robotToy.IsToyPlaced())
            {
                robotToy.Left();
                return true;
            }

            return false;
        }

        public void Reporting()
        {
            if (robotToy.IsToyPlaced())
            {
                Console.WriteLine(robotToy.Report());
            }
        }
    }
}
