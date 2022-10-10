using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class LengthConverter : CategoryConverter
    {
        public LengthConverter() :
            base()
        { }
        public override double Convert(string processedUnit, string rawValue)
        {
            return _unitConverter.Convert(processedUnit, rawValue);
        }
    }
}
