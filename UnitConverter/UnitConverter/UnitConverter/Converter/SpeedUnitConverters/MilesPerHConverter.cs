using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class MilesPerHConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "m/s":
                        return System.Convert.ToDouble(rawValue) * 0.44704;
                    case "km/h":
                        return System.Convert.ToDouble(rawValue) * 1.609344;
                    case "miles/h":
                        return System.Convert.ToDouble(rawValue);
                    case "nodes":
                        return System.Convert.ToDouble(rawValue) * 0.868976;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
