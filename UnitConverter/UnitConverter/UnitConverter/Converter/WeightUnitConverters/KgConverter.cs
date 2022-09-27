using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class KgConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "pud":
                        return System.Convert.ToDouble(rawValue) * 0.061;
                    case "kg":
                        return System.Convert.ToDouble(rawValue);
                    case "ounces":
                        return System.Convert.ToDouble(rawValue) * 35.27;
                    case "mg":
                        return System.Convert.ToDouble(rawValue) * 1000000;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
