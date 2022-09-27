using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal static class UnitConverterFactory
    {
        public static IUnitConverter CreateUnitConverter(string rawUnit)
        {
            switch (rawUnit)
            {
                case "inch":
                    return new InchConverter();
                case "sm":
                    return new SmConverter();
                case "foot":
                    return new FootConverter();
                case "m":
                    return new MConverter();
                case "pud":
                    return new PudConverter();
                case "kg":
                    return new KgConverter();
                case "ounces":
                    return new OuncesConverter();
                case "mg":
                    return new MgConverter();
                case "m/s":
                    return new MPerSConverter();
                case "km/h":
                    return new KmPerHConverter();
                case "miles/h":
                    return new MilesPerHConverter();
                case "nodes":
                    return new NodesConverter();
                default:
                    throw new ArgumentException("Invalid cast");
            }
        }
    }
}
