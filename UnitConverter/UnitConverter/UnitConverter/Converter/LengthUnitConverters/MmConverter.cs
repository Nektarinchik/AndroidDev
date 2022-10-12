using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class MmConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "dm":
                        return System.Convert.ToDouble(rawValue) * 0.01;
                    case "sm":
                        return System.Convert.ToDouble(rawValue) * 0.1;
                    case "mm":
                        return System.Convert.ToDouble(rawValue);
                    case "m":
                        return System.Convert.ToDouble(rawValue) * 0.001;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
