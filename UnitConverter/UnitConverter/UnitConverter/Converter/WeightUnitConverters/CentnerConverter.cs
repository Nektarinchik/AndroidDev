using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class CentnerConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "centner":
                        return System.Convert.ToDouble(rawValue);
                    case "kg":
                        return System.Convert.ToDouble(rawValue) * 100;
                    case "g":
                        return System.Convert.ToDouble(rawValue) * 100000;
                    case "mg":
                        return System.Convert.ToDouble(rawValue) * 100000000;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
