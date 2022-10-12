using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class MConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "dm":
                        return System.Convert.ToDouble(rawValue) * 10;
                    case "sm":
                        return System.Convert.ToDouble(rawValue) * 100;
                    case "mm":
                        return System.Convert.ToDouble(rawValue) * 1000;
                    case "m":
                        return System.Convert.ToDouble(rawValue);
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
