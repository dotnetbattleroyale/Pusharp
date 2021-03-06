using System;

namespace Pusharp
{
    public class LogMessage
    {
        public string Message { get; }
        public LogLevel Level { get; }

        public LogMessage(LogLevel level, string message)
        {
            Message = message;
            Level = level;
        }

        public override string ToString()
        {
            var time = DateTime.UtcNow;
            var niceTime = $"{(time.Hour < 10 ? "0" : "")}{time.Hour}:{(time.Minute < 10 ? "0" : "")}{time.Minute}" +
                           $":{(time.Second < 10 ? "0" : "")}{time.Second}";

            return $"[{niceTime}] [{Level,-8}] {Message}";
        }
    }
}