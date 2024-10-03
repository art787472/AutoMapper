using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Mapper
{
    internal class EnumMapper : IMapper
    {
        public T2 Convert<T2>(object source)
        {
            object value = (int)source;

            T2 t2 = (T2)value;
            return t2;
        }
    }
}
