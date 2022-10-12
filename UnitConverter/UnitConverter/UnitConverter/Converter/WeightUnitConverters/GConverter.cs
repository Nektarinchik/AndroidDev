using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class GConverter : IUnitConverter
    {
        public double Convert(string processedUnit, string rawValue)
        {
            if (!string.IsNullOrEmpty(rawValue))
            {
                switch (processedUnit)
                {
                    case "centner":
                        return System.Convert.ToDouble(rawValue) * 0.00001;
                    case "kg":
                        return System.Convert.ToDouble(rawValue) * 0.001;
                    case "g":
                        return System.Convert.ToDouble(rawValue);
                    case "mg":
                        return System.Convert.ToDouble(rawValue) * 1000;
                }
                return 0.0;
            }
            else return 0.0;
        }
    }
}
