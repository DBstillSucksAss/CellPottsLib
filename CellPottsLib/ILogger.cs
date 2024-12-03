using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib
{
    public interface ILogger
    {
        public void Log(string message, object Sender);
        public void SetLogPath(string path);
    }
}
