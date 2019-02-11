using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToySimulator.App_Start;
using ToySimulator.Commands.Parser;
using ToySimulator.Driver;
using ToySimulator.Enums;
using ToySimulator.Tabletop;
using ToySimulator.Toys;
using ToySimulator.Toys.Robots;

namespace ToySimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var container = ContainerConfig.Configure(5);

            using (var scope = container.BeginLifetimeScope())
            {
                var parse = scope.Resolve<IParseServices>();
                var driver = scope.Resolve<IDriverToy>();

                while (true)
                {
                    string line = PromptForCommand();
                    if (line.ToUpper() == "EXIT" || line.ToUpper() == "QUIT")
                    {
                        Environment.Exit(0);
                    }
                    var command = parse.GetInstruction(line);

                    if (command.Instruction != Instruction.Invalid)
                    {
                        var simulator = new Simulator();
                        simulator.Execute(driver, command);
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }
                }
            }                      
        }
       
        private static string PromptForCommand()
        {
            Console.WriteLine("#: ");
            return Console.ReadLine();
        }
    }
}
