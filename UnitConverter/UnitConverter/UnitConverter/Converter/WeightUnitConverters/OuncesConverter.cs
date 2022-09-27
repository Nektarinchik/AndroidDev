using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class OuncesConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "pud":
                        return System.Convert.ToDouble(rawValue) * 0.0017;
                    case "kg":
                        return System.Convert.ToDouble(rawValue) * 0.028;
                    case "ounces":
                        return System.Convert.ToDouble(rawValue);
                    case "mg":
                        return System.Convert.ToDouble(rawValue) * 28349.52;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
