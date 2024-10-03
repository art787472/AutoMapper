using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    internal static class Extension
    {
        public static ConvertCategory GetTypeProperty(this Type type)
        {
            Type sourceType = Nullable.GetUnderlyingType(type) ?? type;
            if (sourceType == typeof(string))
                return ConvertCategory.BasicType;

            if (sourceType.IsArray)
                return ConvertCategory.ArrayType;

            if (typeof(IEnumerable).IsAssignableFrom(type))
                return ConvertCategory.CollectionType;

            if (sourceType.IsClass)
                return ConvertCategory.ClassType;
            if (sourceType.IsEnum)
                return ConvertCategory.EnumType;

            return ConvertCategory.BasicType;

        }
    }
}
