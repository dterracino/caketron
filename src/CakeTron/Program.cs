﻿using System;
using System.IO;
using CakeTron.Core;
using CakeTron.Gitter;
using CakeTron.Slack;
using Microsoft.Extensions.Configuration;
using Serilog.Events;

namespace CakeTron
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Read the configuration
            var configuration = GetConfiguration();

            // Build the robot.
            var robot = new RobotBuilder()
                .UseGitter(configuration["Gitter:Token"])
                .UseSlack(configuration["Slack:Token"])
                .UseDefaultRobotParts()
                .UseInMemoryKarma()
                .UseSerilog(LogEventLevel.Debug)
                .Build();

            // Start the robot.
            robot.Start();

            // Setup cancellation.
            Console.CancelKeyPress += (s, e) =>
            {
                e.Cancel = true;
                robot.Stop();
            };

            // Wait for termination.
            robot.Join();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
