﻿using CakeTron.Diagnostics;
using Dotbot;
using Dotbot.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

// ReSharper disable once CheckNamespace
namespace CakeTron
{
    public static class RobotBuilderExtensions
    {
        public static RobotBuilder UseSerilogConsole(this RobotBuilder builder, LogEventLevel level)
        {
            builder.Services.AddSingleton<ILog>(
                new SerilogLogAdapter(
                    new LoggerConfiguration()
                        .WriteTo.LiterateConsole()
                        .MinimumLevel.Is(level)
                        .Enrich.FromLogContext()
                        .CreateLogger()));

            return builder;
        }
    }
}
