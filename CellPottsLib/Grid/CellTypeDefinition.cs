using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Grid
{
    public abstract class CellTypeDefinition
    {
        public string Name { get; private set; }
        //IdentityMin and IdentityMax define the range of Identities that are allowed for this CellType
        public int IdentityMin { get; private set; }
        public int IdentityMax { get; private set; }
        public int TargetVolume { get; set; }
        public int TargetCircumference { get; set; }
        public int MinVolumeForDivision { get; set; }
        public CellTypeDefinition(string name, int identityMin, int identityMax)
        {
            Name = name;
            IdentityMin = identityMin;
            IdentityMax = identityMax;
            additionalProperties = new Dictionary<string, object>();
            EnergyFactors = new Dictionary<string, double>();
            SetStandartEnergyFactors();
        }

        //Energy Factors, used by the different EnergyUnits 
        //the EnergyFactors for "volume", "circumference", "adhesivecell", "adhesivebackground" and "adhesiveboundrary" are set to the default Values from the Registry on creation
        private Dictionary<string, double> EnergyFactors;
        private Dictionary<string, object> additionalProperties;
        public virtual object GetAdditionalProperty(string propertyName)
        {
            return additionalProperties[propertyName.ToLower()] ?? "not found";
        }
        public virtual void SetAdditionalProperty(string propertyName, object value)
        {
            propertyName = propertyName.ToLower();
            if (additionalProperties.ContainsKey(propertyName))
            {
                additionalProperties[propertyName] = value;
            }
            else
            {
                additionalProperties.Add(propertyName, value);
            }
        }

        public virtual void DeleteAdditionalProperty(string propertyName)
        {
            additionalProperties.Remove(propertyName.ToLower());
        }

        public virtual void SetEnergyFactor(string FactorName, double FactorValue)
        {
            if (EnergyFactors == null)
            {
                EnergyFactors = new Dictionary<string, double>();
            }
            if (EnergyFactors.ContainsKey(FactorName))
            {
                EnergyFactors[FactorName] = FactorValue;
            }
            else
            {
                EnergyFactors.Add(FactorName, FactorValue);
            }
        }

        public virtual double? GetEnergyFactor(string FactorName)
        {
            if (EnergyFactors.ContainsKey(FactorName))
            {
                return EnergyFactors[FactorName];
            }
            else
            {
                return null;
            }
        }

        public virtual void DeleteEnergyFactor(string FactorName)
        {
            EnergyFactors.Remove(FactorName);
        }

        protected virtual void SetStandartEnergyFactors()
        {
            EnergyFactors.Add("adhesivecell", Registry.DefaultAdhesiveCellCell);
            EnergyFactors.Add("adhesivebackground", Registry.DefaultAdhesiveCellBackground);
            EnergyFactors.Add("adhesiveboundary", Registry.DefaultAdhesiveCellBoundary);
            EnergyFactors.Add("volume", Registry.VolumeFactor);
            EnergyFactors.Add("circumference", Registry.CircumferenceFactor);
        }

        public bool Contains(int identity)
        {
            return identity >= IdentityMin && identity <= IdentityMax;
        }

        public bool IntersectsWith(CellTypeDefinition typeDefinition)
        {
            if(typeDefinition.IdentityMin >= IdentityMin && typeDefinition.IdentityMin <= IdentityMax)
            {
                return true;
            }
            if (typeDefinition.IdentityMax >= IdentityMin && typeDefinition.IdentityMax <= IdentityMax)
            {
                return true;
            }
            if(typeDefinition.IdentityMin >= IdentityMin && typeDefinition.IdentityMax <= IdentityMax)
            {
                return true;
            }
            if (typeDefinition.IdentityMin <= IdentityMin && typeDefinition.IdentityMax >= IdentityMax)
            {
                return true;
            }
            return false;
        }
    } 
}
