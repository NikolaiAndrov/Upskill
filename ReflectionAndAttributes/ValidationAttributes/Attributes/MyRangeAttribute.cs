﻿namespace ValidationAttributes.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int result;

            if (!int.TryParse(obj?.ToString(), out result))
            {
                return false;
            }

            return result >= minValue && result <= maxValue;
        }
    }
}
