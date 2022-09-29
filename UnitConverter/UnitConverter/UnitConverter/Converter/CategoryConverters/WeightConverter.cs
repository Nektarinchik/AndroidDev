﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Converter
{
    internal sealed class WeightConverter : ICategoryConverter
    {
        public WeightConverter()
        {
            _unitConverter = null;
        }
        public double Convert(string processedUnit, string rawValue)
        {
            return _unitConverter.Convert(processedUnit, rawValue);
        }
        public IUnitConverter UnitConverter
        {
            set { _unitConverter = value; }
        }

        private IUnitConverter _unitConverter;
    }
}