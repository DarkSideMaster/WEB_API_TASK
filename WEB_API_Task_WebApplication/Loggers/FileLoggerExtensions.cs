using Microsoft.Extensions.Logging;
using WEB_API_Task.Loggers;

namespace WEB_API_Task.Loggers
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filePath)

        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
