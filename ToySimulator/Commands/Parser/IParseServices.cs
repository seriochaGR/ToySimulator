using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;

namespace ToySimulator.Commands.Parser
{
    public interface IParseServices
    {
        Command GetInstruction(string line);
    }
}
