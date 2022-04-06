namespace KUSYS.Web.Api.Logging
{
    public class FileLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = string.Format("{0}: {1} - {2}", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), logLevel.ToString(), formatter(state, exception));
            WriteMessageToFile(message);
        }

        private static void WriteMessageToFile(string message)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string filePath = string.Format("{0}.log", Path.Combine(directoryPath, DateTime.Now.ToString("ddMMyyyy")), DateTime.Now.ToString("ddMMyyyy"));
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
