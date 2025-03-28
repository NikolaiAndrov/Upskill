﻿namespace ValidationAttributes.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null && !string.IsNullOrWhiteSpace(obj.ToString()); ;
        }
    }
}
