using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Atribute;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
           Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            PropertyInfo[] propertiesAttributes = properties
                .Where(p => Attribute.IsDefined(p, typeof(MyValidationAttribute), inherit:true))
                .ToArray();
            foreach (var property in propertiesAttributes)
            {
               var validationAttributes = property
                    .GetCustomAttributes(typeof(MyValidationAttribute), inherit:true)
                    .Cast<MyValidationAttribute>();

                foreach (var attr in validationAttributes)
                {
                    object value = property.GetValue(obj);
                    if (attr.IsValid(value) ==  false) 
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
