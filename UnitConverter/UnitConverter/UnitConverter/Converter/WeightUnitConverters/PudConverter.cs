using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class PudConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "pud":
                        return System.Convert.ToDouble(rawValue);
                    case "kg":
                        return System.Convert.ToDouble(rawValue) * 16.38;
                    case "ounces":
                        return System.Convert.ToDouble(rawValue) * 577.79;
                    case "mg":
                        return System.Convert.ToDouble(rawValue) * 16380000;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
