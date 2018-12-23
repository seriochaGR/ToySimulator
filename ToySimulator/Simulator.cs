using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Commands;
using ToySimulator.Driver;
using ToySimulator.Enums;

namespace ToySimulator
{
    public class Simulator
    {
        public void Execute(IDriverToy driverToy, Command command)
        {
            switch (command.Instruction)
            {
                case Instruction.Place:
                    driverToy.Placing(command.InstructionArguments.X, command.InstructionArguments.Y, command.InstructionArguments.Facing);
                    break;
                case Instruction.Move:
                    driverToy.Movement();
                    break;
                case Instruction.Left:
                    driverToy.Left();
                    break;
                case Instruction.Right:
                    driverToy.Right();
                    break;
                case Instruction.Report:
                    driverToy.Reporting();
                    break;
                default:
                    break;
            }
        }
    }
}
