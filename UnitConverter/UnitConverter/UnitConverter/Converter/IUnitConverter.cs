using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal interface IUnitConverter
    {
        double Convert(string processedUnit, string rawValue);
    }
}
