using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public abstract class CellUpdateUnitBase : ILogicUnit
    {
        public string ID { get; private set; }
        public LogicUnitType Type { get; private set; }
        private bool enabled { get; set; } = true;
        public CellUpdateUnitBase(string id)
        {
            ID = id;
            Type = LogicUnitType.Cell;
        }

        public abstract void UpdateStartTimeStep(I2DGrid grid);
        public abstract void UpdateEndTimeStep(I2DGrid grid);
        public virtual void Enable()
        {
            enabled = true;
        }
        public virtual void Disable()
        {
            enabled = false;
        }


    }
}
