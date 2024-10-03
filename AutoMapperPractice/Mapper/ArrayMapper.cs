using AutoMapper.Mappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Mapper
{
    internal class ArrayMapper : IMapper
    {
        public T2 Convert<T2>(object source)
        {
            
            var destinationType = typeof(T2).GetElementType();
            var detinationListType = typeof(List<>).MakeGenericType(destinationType);
            var sourceType = source.GetType().GetElementType();
            IEnumerable enumerable = source as IEnumerable;
            IList sourceList = enumerable as IList;
            

            IList result = Activator.CreateInstance(detinationListType) as IList;


            
            foreach ( var item in enumerable)
            {
                var r = ConvertService.CallMap(sourceType, destinationType, item);
                result.Add(r);
            }
            object res = Array.CreateInstance(destinationType, result.Count);
            result.CopyTo((Array)res, 0);
            
            return (T2)res;
        }
    }
}
