using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public class LogicHandler : ILogicHandler
    {
        public IEnergyCalculator EnergyCalculator { get; private set; }
        private List<ILogicUnit> LogicUnits;

        public LogicHandler(EnergyCalculator? energyCalculator = null)
        {
            LogicUnits = new List<ILogicUnit>();
            EnergyCalculator = energyCalculator ?? new EnergyCalculator();
        }

        public void AddLogicUnit(ILogicUnit unit)
        {
            if(unit.Type == LogicUnitType.EnergyCalculator)
            {
                EnergyCalculator.AddEnergyUnit((EnergyUnitBase)unit);
            }
            if(!LogicUnits.Any(x => x.ID == unit.ID))
            {
                LogicUnits.Add(unit);
            }
        }

        public ILogicUnit? GetLogicUnit(string ID, LogicUnitType type)
        {
            if(type == LogicUnitType.EnergyCalculator) { return EnergyCalculator.GetEnergyUnit(ID); }

            ILogicUnit? unit = LogicUnits.First(x => x.ID == ID);
            return unit;
        }

        public List<ILogicUnit> GetLogicUnits()
        {
            List<ILogicUnit> units = new();
            units.AddRange(LogicUnits);
            units.AddRange(EnergyCalculator.GetEnergyUnits());
            return units;
        }

        public void RemoveLogicUnit(string ID, LogicUnitType type)
        {
            if(type == LogicUnitType.EnergyCalculator) { EnergyCalculator.RemoveEnergyUnit(ID); }
            LogicUnits.Remove(LogicUnits.First(x => x.ID == ID));
        }

        public void SetEnergyCalculator(IEnergyCalculator calculator)
        {
            EnergyCalculator = calculator;
        }
    }
}
