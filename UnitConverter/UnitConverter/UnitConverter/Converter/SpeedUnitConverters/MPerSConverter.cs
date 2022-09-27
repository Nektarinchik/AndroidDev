using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class MPerSConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "m/s":
                        return System.Convert.ToDouble(rawValue);
                    case "km/h":
                        return System.Convert.ToDouble(rawValue) * 3.6;
                    case "miles/h":
                        return System.Convert.ToDouble(rawValue) * 2.236936;
                    case "nodes":
                        return System.Convert.ToDouble(rawValue) * 1.943845;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
