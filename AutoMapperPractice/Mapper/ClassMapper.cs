using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Mapper
{
    internal class ClassMapper : IMapper
    {
        public T2 Convert<T2>(object source)
        {
            var sourceType = source.GetType();
            ConstructorInfo constructor = typeof(T2).GetConstructor(Type.EmptyTypes);
            T2 t2 = (T2)constructor.Invoke(null);

            foreach (var item in sourceType.GetProperties())
            {

                var value = item.GetValue(source);
                var propT2 = typeof(T2).GetProperty(item.Name);

                if (propT2 != null)
                {
                    var propT2Type = propT2.PropertyType;
                    //MakeGenericTypeMethod

                    //var methodInfo = typeof(MyAutoMapper).GetMethod("ConvertType", BindingFlags.Static | BindingFlags.NonPublic);
                    //object t2Value = null;
                    //if (methodInfo != null)
                    //{
                    //    t2Value = methodInfo.MakeGenericMethod(propT2Type).Invoke(null, new object[] { value });
                    //}

                    //propT2.SetValue(t2, t2Value);

                    //var methodInfos = typeof(MyAutoMapper).GetMethods();
                    //var methodInfo = methodInfos.FirstOrDefault();
                    //var method = methodInfo.MakeGenericMethod(item.PropertyType, propT2.PropertyType);
                    var result = ConvertService.CallMap(item.PropertyType, propT2.PropertyType, value);
                    
                    propT2.SetValue(t2, result);

                }


            };
            return t2;
            //var methodInfos = typeof(MyAutoMapper).GetMethods();
            //var methodInfo = methodInfos.FirstOrDefault();
            //var method = methodInfo.MakeGenericMethod(sourceType, typeof(T2));
            //var result = (T2)method.Invoke(null, new object[] { source });
            //return result;
        }
    }
}
