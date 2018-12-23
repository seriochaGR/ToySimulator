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
            var services = InitializationDI();
            var robot = new Robot();
            var table = new SquareTabletop(5);
            var driver = new DriverRobotToy(robot, table);

            var parse = services.GetService<IParseServices>();

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

        private static ServiceProvider InitializationDI()
        {
            var serviceProvider = new ServiceCollection()
                                       .AddTransient<IToy, Robot>()
                                       .AddTransient<ITabletop, SquareTabletop>()
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
