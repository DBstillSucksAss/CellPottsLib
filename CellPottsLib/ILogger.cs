using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib
{
    public interface ILogger
    {
        public Logtype LogType { get; set; }
        public void Log(string message, object Sender);
        public void SetLogPath(string path);

    }

    public enum Logtype
    {
        txt,
        json
    }
}
