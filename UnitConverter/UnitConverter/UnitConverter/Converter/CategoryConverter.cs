using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal abstract class CategoryConverter
    {
        public CategoryConverter()
        {
            UnitConverter = null;
        }
        public abstract double Convert(string processedUnit, string rawValue);
        public IUnitConverter UnitConverter
        {
            set { _unitConverter = value; }
        }

        protected IUnitConverter _unitConverter;
    }
}
