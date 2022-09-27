using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal interface ICategoryConverter
    {
        double Convert(string processedUnit, string rawValue);
        IUnitConverter UnitConverter { set; }
    }
}
