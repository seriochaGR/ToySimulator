using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;

namespace ToySimulator.Toys.Robots
{
    public class Robot : Toy, IToy
    {
        private const int step = 1;
                
        public void Place(int x, int y, Orientation facing)
        {
            xPosition = x;
            yPosition = y;
            this.facing = facing;
            isPlaced = true;
        }

        public bool XMovement(int direction)
        {
            if (isPlaced)
            {
                xPosition += step * direction;
                return true;
            }

            return false;            
        }

        public bool YMovement(int direction)
        {
            if (isPlaced)
            {
                yPosition += step * direction;
                return true;
            }

            return false;
        }
                
        public bool Left()
        {
            if (isPlaced)
            {
                FacingOf(Side.Left);
                return true;
            }

            return false;
        }

        public bool Right()
        {
            if (isPlaced)
            {
                FacingOf(Side.Right);
                return true;                
            }

            return false;
        }

        public string Report()
        {
            if (isPlaced)
            {
                return String.Format("{0},{1},{2}", xPosition, yPosition, facing.ToString().ToUpper());
            }
            return null;
        }

        public int GetXPosition()
        {
            return xPosition;
        }

        public int GetYPosition()
        {
            return yPosition;
        }

        public Orientation GetFacing()
        {
            return facing;
        }

        public bool IsToyPlaced()
        {
            return isPlaced;
        }
        
        public int GetStep()
        {
            return step;
        }
    }
}
