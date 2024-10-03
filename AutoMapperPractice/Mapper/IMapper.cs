using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Mapper
{
    internal interface IMapper
    {
        T2 Convert<T2>(object source);
    }
}
