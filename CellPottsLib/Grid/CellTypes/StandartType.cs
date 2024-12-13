using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Grid.CellTypes
{
    public class StandartType : CellTypeDefinition
    {
        public StandartType(string name, int identityMin, int identityMax) : base(name, identityMin, identityMax)
        {
            
        }
    }
}
