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
                case "dm":
                    return new DmConverter();
                case "sm":
                    return new SmConverter();
                case "mm":
                    return new MmConverter();
                case "m":
                    return new MConverter();
                case "centner":
                    return new CentnerConverter();
                case "kg":
                    return new KgConverter();
                case "g":
                    return new GConverter();
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
