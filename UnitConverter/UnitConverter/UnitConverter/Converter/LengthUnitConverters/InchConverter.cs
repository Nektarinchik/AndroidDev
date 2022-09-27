using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class InchConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "inch":
                        return System.Convert.ToDouble(rawValue);
                    case "sm":
                        return 2.54 * System.Convert.ToDouble(rawValue); // constant
                    case "foot":
                        return 0.0833 * System.Convert.ToDouble(rawValue);
                    case "m":
                        return 0.0254 * System.Convert.ToDouble(rawValue);
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
