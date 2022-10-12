using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class DmConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "dm":
                        return System.Convert.ToDouble(rawValue);
                    case "sm":
                        return 10 * System.Convert.ToDouble(rawValue); // constant
                    case "mm":
                        return 100 * System.Convert.ToDouble(rawValue);
                    case "m":
                        return 0.1 * System.Convert.ToDouble(rawValue);
                }
                return 0.0;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
