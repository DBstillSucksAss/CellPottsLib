using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib
{
    public static class Logger 
    {
        private static string logPath { get { return Registry.LogPath; } }
        private static  StreamWriter sw;
        public static void Log(string message, object Sender)
        {
            if(!File.Exists(logPath) || !Path.GetExtension(logPath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                File.Create(logPath);
            }
            sw.WriteLine($"{DateTime.Now} - {Sender.GetType().Name}: {message}");
            
        }
        public static void Clearlog()
        {
            if (File.Exists(logPath))
            {
                sw.Close();
                File.WriteAllText(logPath, string.Empty);
                SetLogPath(logPath);
            }
        }
        public static void SetLogPath(string path)
        {
            Registry.LogPath = path;
            sw = new StreamWriter(logPath, append: true) { AutoFlush = true };
        }
    }
}
