namespace ValidationAttributes.Utilities
{
    using System;
    using System.Reflection;
    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object value)
        {
            Type type = value.GetType();

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes<MyValidationAttribute>(true);

                foreach (var attribute in attributes)
                {
                    var propertyValue = property.GetValue(value);

                    if (!attribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
