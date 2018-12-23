using System;
using System.Collections.Generic;
using System.Text;

namespace ToySimulator.Tabletop
{
    public class SquareTabletop : ITabletop
    {
        public int Size { get; }

        public SquareTabletop(int size)
        {
            Size = size;
        }

        public bool IsValidPosition(int x, int y)
        {
            if ((x >= 0 && x < Size) && (y >= 0 && y < Size))
            {
                return true;
            }

            return false;
        }
    }
}
