using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class SmConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "inch":
                        return System.Convert.ToDouble(rawValue) / 2.54;
                    case "sm":
                        return System.Convert.ToDouble(rawValue);
                    case "foot":
                        return System.Convert.ToDouble(rawValue) * 0.033;
                    case "m":
                        return System.Convert.ToDouble(rawValue) / 100;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
