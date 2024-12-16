using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logging
{
    public class LogEntry
    {
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; } 
        public object? Data { get; set; }

        public LogEntry() { }

        public LogEntry(string type, string sender, string message, object? data = null)
        {
            Type = type;
            Time = DateTime.Now;
            Sender = sender;
            Message = message;
            Data = data;
        }
        public LogEntry(string type, object sender, string message, object? data = null)
        {
            Type = type;
            Time = DateTime.Now;
            Sender = sender.GetType().Name;
            Message = message;
            Data = data;
        }
        public LogEntry(string type,DateTime time, string sender, string message, object? data = null)
        {
            Type = type;
            Time = time;
            Sender = sender;
            Message = message;
            Data = data;
        }

        public LogEntry(string type,DateTime time, object sender, string message, object? data = null)
        {
            Type = type;
            Time = time;
            Sender = sender.GetType().Name;
            Message = message;
            Data = data;
        }
    }
}
