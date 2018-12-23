using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;

namespace ToySimulator.Commands
{
    public class InstructionArguments
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Facing { get; set; }
    }
}
