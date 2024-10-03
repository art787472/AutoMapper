using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    internal class ConvertService
    {
        static public object CallMap(Type type1, Type type2, object value)
        {
            var methodInfos = typeof(MyAutoMapper).GetMethods();
            var methodInfo = methodInfos.FirstOrDefault();
            var method = methodInfo.MakeGenericMethod(type1, type2);
            var result = method.Invoke(null, new object[] { value });
            return result;
        }
    }
}
