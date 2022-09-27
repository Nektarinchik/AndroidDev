using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class FootConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "inch":
                        return System.Convert.ToDouble(rawValue) * 12.0;
                    case "sm":
                        return System.Convert.ToDouble(rawValue) / 0.033;
                    case "foot":
                        return System.Convert.ToDouble(rawValue);
                    case "m":
                        return System.Convert.ToDouble(rawValue) * 0.3;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
