using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToySimulator.Commands.Parser;
using ToySimulator.Driver;
using ToySimulator.Tabletop;
using ToySimulator.Toys;
using ToySimulator.Toys.Robots;

namespace ToySimulator.App_Start
{
    public static class ContainerConfig
    {
        public static IContainer Configure(int size)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Robot>().As<IToy>();
            builder.Register(t => new SquareTabletop(size)).As<ITabletop>();
            builder.RegisterType<DriverRobotToy>().As<IDriverToy>();
            builder.RegisterType<ParseServices>().As<IParseServices>();

            return builder.Build();
        }
    }
}
