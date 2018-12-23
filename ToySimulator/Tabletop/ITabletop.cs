using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Tabletop
{
    public interface ITabletop
    {
        bool IsValidPosition(int x, int y);
    }
}
