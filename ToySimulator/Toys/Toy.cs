using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;

namespace ToySimulator.Toys
{
    public abstract class Toy
    {
        protected int xPosition { get; set; }
        protected int yPosition { get; set; }
        protected Orientation facing { get; set; }
        protected bool isPlaced { get; set; }

        public Toy()
        {
            isPlaced = false;
        }

        public void Place(int x, int y, Orientation facing)
        {
            xPosition = x;
            yPosition = y;
            this.facing = facing;
            isPlaced = true;
        }

        protected void FacingOf(Side side)
        {
            int newFacing = (int)facing + (side == Side.Right ? 1 : -1);

            if (newFacing > 4)
            {
                newFacing = 1;
            }
            else if(newFacing < 1)
            {
                newFacing = 4;
            }

            Turn((Orientation)newFacing);
        }

        private void Turn(Orientation orientation)
        {
            facing = orientation;
        }

        public string Report()
        {
            if (isPlaced)
            {
                return String.Format("{0},{1},{2}", xPosition, yPosition, facing.ToString().ToUpper());
            }
            return null;
        }
    }
}
