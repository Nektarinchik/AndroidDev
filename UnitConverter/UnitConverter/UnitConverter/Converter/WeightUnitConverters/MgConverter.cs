using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class MgConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "pud":
                        return System.Convert.ToDouble(rawValue) * 6.11e-8;
                    case "kg":
                        return System.Convert.ToDouble(rawValue) * 0.000001;
                    case "ounces":
                        return System.Convert.ToDouble(rawValue) * 0.000035;
                    case "mg":
                        return System.Convert.ToDouble(rawValue);
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
