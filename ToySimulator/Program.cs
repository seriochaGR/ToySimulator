using Microsoft.Extensions.DependencyInjection;
using System;
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
            var services = InitializationDI(5);

            var parse = services.GetService<IParseServices>();
            var driver = services.GetService<IDriverToy>();

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

        private static ServiceProvider InitializationDI(int size)
        {
            var serviceProvider = new ServiceCollection()
                                       .AddTransient<IToy, Robot>()
                                       .AddTransient<ITabletop>(t => new SquareTabletop(size))
                                       .AddTransient<IDriverToy, DriverRobotToy>()
                                       .AddTransient<IParseServices, ParseServices>()
                                       .BuildServiceProvider();

            return serviceProvider;
        }

        private static string PromptForCommand()
        {
            Console.WriteLine("#: ");
            return Console.ReadLine();
        }
    }
}
