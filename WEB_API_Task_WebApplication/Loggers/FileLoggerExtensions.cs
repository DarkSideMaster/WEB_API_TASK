using Microsoft.Extensions.Logging;
 
namespace WEB_API_Task_WebApplication.Loggers
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
