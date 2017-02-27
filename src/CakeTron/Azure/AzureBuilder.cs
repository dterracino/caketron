using Dotbot;
using Microsoft.Extensions.DependencyInjection;

namespace CakeTron.Azure
{
    public static class AzureBuilder
    {
        public static RobotBuilder UseAzureWebJobShutdownListener(this RobotBuilder builder)
        {
            builder.Services.AddSingleton<IWorker, WebJobShutdownListener>();
            return builder;
        }
    }
}
