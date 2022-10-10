using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal static class CategoryConverterFactory
    {
        public static CategoryConverter CreateCategoryConverter(string category)
        {
            switch (category)
            {
                case "Length":
                    return new LengthConverter();
                case "Weight":
                    return new WeightConverter();
                case "Speed":
                    return new SpeedConverter();
                default:
                    throw new ArgumentException("Invalid cast");
            }
        }
    }
}
