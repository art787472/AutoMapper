using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Mapper
{
    internal class CollectionMapper : IMapper
    {
        public T2 Convert<T2>(object source)
        {
            var destinationType = typeof(T2).GetGenericArguments();
            var sourceType = source.GetType().GetGenericArguments()[0];
            IEnumerable enumerable = source as IEnumerable;
            var result = (T2)Activator.CreateInstance(typeof(T2));
            var methodInfos = typeof(MyAutoMapper).GetMethods();
            var methodInfo = methodInfos.FirstOrDefault();
            var method = methodInfo.MakeGenericMethod(sourceType, destinationType[0]);
            foreach (var item in enumerable)
            {
                var r = method.Invoke(null, new object[] { item });
            }
            throw new NotImplementedException();

        }
    }
}
