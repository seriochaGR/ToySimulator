using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;

namespace ToySimulator.Driver
{
    public interface IDriverToy
    {
        bool Placing(int x, int y, Orientation orientation);
        bool Movement();
        bool Right();
        bool Left();
        void Reporting();
    }
}
