using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Mapper
{
    internal class BasicMapper : IMapper
    {
        public T2 Convert<T2>(object source)
        {
            
            string typeName = source.GetType().Name;
            var m = typeof(Convert).GetMethod("To" + typeName, new Type[] { typeof(T2) });
            T2 result = (T2)typeof(Convert).GetMethod("To" + typeName, new Type[] { typeof(T2) }).Invoke(null, new object[] { source });
            return result;
        }
    }
}
