using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace CellPottsLib.Logging
{
    public static class Logger
    {
        public static string Path { get { return Registry.LogPath; } set { SetLogPath(value); } }
        static StreamWriter? sw;

        public static void Log(LogEntry entry)
        {
            if (!Registry.LoggingEnabled) { return; }

            if (!File.Exists(Path) || !System.IO.Path.GetExtension(Path).Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                System.IO.Path.ChangeExtension(Registry.LogPath, ".json");
                using (File.Create(Path)) { }
                if (sw != null) { sw.Close(); }
                sw = new StreamWriter(Path);
            }
            
            string logtext = JsonSerializer.Serialize(entry);
            sw.WriteLine(logtext);
        }

        public static void Clearlog()
        {
            if (File.Exists(Path))
            {
                if (sw != null)
                {
                    sw.Close();
                }
                File.WriteAllText(Path, string.Empty);
                SetLogPath(Path);
            }
        }

        public static void SetLogPath(string path)
        {
            Registry.LogPath = path;
            Registry.EnableLogging = true;
            sw = new StreamWriter(Path);
        }

        public static void DisableLogging()
        {
            Registry.EnableLogging = false;
            if (sw != null)
            {
                sw.Close();
            }
        }

        public static void EnableLogging()
        {
            if (Path == "")
            {
                throw new Exception("No Logpath set. Logging cant be enabled");
            }
            Registry.EnableLogging = true;
            if (sw != null)
            {
                sw.Close();
            }
            sw = new StreamWriter(Path);
        }

        public static void FinalizeLog()
        {
            if (sw != null)
            {
                sw.Close();
            }

            // Step 1: Read all lines from the log file
            var logLines = File.ReadAllLines(Path);

            // Step 2: Parse each line into a JSON object
            var logEntries = new List<object>();
            foreach (var line in logLines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    try
                    {
                        var logEntry = JsonSerializer.Deserialize<object>(line);
                        logEntries.Add(logEntry);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failed to parse log entry: {line}", ex);
                    }
                }
            }

            // Step 3: Wrap all JSON objects in an array
            string wrappedJson = JsonSerializer.Serialize(logEntries);

            // Step 4: Overwrite the log file with the wrapped JSON array
            File.WriteAllText(Path, wrappedJson);

            Console.WriteLine("Log file successfully wrapped in a JSON array.");
        }
    }
}
