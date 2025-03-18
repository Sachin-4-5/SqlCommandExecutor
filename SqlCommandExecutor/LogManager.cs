using System;
using System.IO;
using System.Configuration;


namespace SqlCommandExecutor
{
    public class LogManager
    {
        private static readonly string LogFilePath = ConfigurationManager.AppSettings["LogFilePath"];
        public static void Log(string message)      //static hence no need to create object while calling.
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Logging Error: {ex.Message}");
            }
        }
    }
}
