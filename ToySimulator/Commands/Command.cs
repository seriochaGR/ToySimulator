using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;

namespace ToySimulator.Commands
{
    public class Command
    {
        public Instruction Instruction { get; set; }
        public InstructionArguments InstructionArguments { get; set; }
    }
}
