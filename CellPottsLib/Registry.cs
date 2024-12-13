using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib
{
    public static class Registry
    {
        public static bool EnableLogging { get; set; } = false;
        public static ILogger? Logger { get; set; } = null;
        public static int BackgroundIdentity { get; set; } = 0;
        public static double DefaultAdhesiveCellCell { get; set; } = 0.5f;
        public static double DefaultAdhesiveCellBackground { get; set; } = 1f;
        public static double DefaultAdhesiveCellBoundary { get; set; } = 1.5f;
        public static double VolumeFactor { get; set; } = 1.0f;
        public static double CircumferenceFactor { get; set; } = 1.0f;
        public static string LogPath { get; set; } = "";

    }
}
