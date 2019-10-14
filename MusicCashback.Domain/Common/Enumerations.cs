using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MusicCashback.Domain.Common
{
    public static class Enumerations
    {
        public static List<EnumKeyValue> GetEnumValuesWithDescription(this Type type)
        {
            var enumKeyValue = EnumKeyValue.ListEmpty();

            if (!type.IsEnum)
                throw new ArgumentException("Informe um enumerador como parametro");
            
            foreach (var item in type.GetEnumValues())
            {
                enumKeyValue.Add(EnumKeyValue.Builder((System.Enum)item));
            };

            return enumKeyValue;
        }

        public static string GetDescription(this System.Enum enumValue)
        {
            string output = null;
            Type type = enumValue.GetType();
            FieldInfo fi = type.GetField(enumValue.ToString());
            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attrs.Length > 0) output = attrs[0].Description;
            return output;
        }
    }

    public class EnumKeyValue
    {
        public int Key { get; set; }
        public string Description { get; set; }

        public static List<EnumKeyValue> ListEmpty() => new List<EnumKeyValue>();

        public static EnumKeyValue Builder(System.Enum item)
        {
            return new EnumKeyValue
            {
                Key = (int)System.Enum.Parse(item.GetType(), item.ToString()),
                Description = item.GetDescription()
            };

        }
    }
}

