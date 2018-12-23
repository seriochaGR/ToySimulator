using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;

namespace ToySimulator.Toys
{
    public interface IToy
    {
        void Place(int x, int y, Orientation facing);
        bool XMovement(int direction);
        bool YMovement(int direction);
        bool Left();
        bool Right();
        string Report();
        int GetXPosition();
        int GetYPosition();
        Orientation GetFacing();
        bool IsToyPlaced();
        int GetStep();
    }
}
