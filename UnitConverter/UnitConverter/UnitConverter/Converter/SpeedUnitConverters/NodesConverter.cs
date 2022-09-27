using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class NodesConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "m/s":
                        return System.Convert.ToDouble(rawValue) * 0.514444;
                    case "km/h":
                        return System.Convert.ToDouble(rawValue) * 1.85;
                    case "miles/h":
                        return System.Convert.ToDouble(rawValue) * 1.150779;
                    case "nodes":
                        return System.Convert.ToDouble(rawValue);
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
