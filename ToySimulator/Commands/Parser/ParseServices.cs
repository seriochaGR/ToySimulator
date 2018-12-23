using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Enums;
using ToySimulator.Utilities;

namespace ToySimulator.Commands.Parser
{
    public class ParseServices : IParseServices
    {
        public Command GetInstruction(string line)
        {
            Command command = new Command();            
            string argumentString = "";

            int argumentSeperatorPosition = line.IndexOf(" ");
            if (argumentSeperatorPosition > 0)
            {
                argumentString = line.Substring(argumentSeperatorPosition + 1);
                line = line.Substring(0, argumentSeperatorPosition);                
            }
            line = line.ToUpper();

            Instruction instruction;
            if (Enum.TryParse(line, true, out instruction))
            {
                if (instruction == Instruction.Place)
                {
                    InstructionArguments arguments = new InstructionArguments();
                    if (!ParserInstructionUtility.TryParsePlaceArgs(argumentString, ref arguments))
                    {
                        command.Instruction = Instruction.Invalid;
                    }
                    else
                    {
                        command.Instruction = instruction;
                        command.InstructionArguments = arguments;
                    }
                }
                else
                {
                    command.Instruction = instruction;
                }
            }
            else
            {
                command.Instruction = Instruction.Invalid;
            }
            return command;
        }
    }
}
