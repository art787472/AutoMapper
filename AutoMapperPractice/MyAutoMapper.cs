using AutoMapper;
using AutoMapper.Internal;
using AutoMapperPractice.Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using IMapper = AutoMapperPractice.Mapper.IMapper;

namespace AutoMapperPractice
{
    internal class MyAutoMapper
    {
        public MyAutoMapper() { }

        public static T2 Map<T1, T2>(T1 t1)
        {
           
            return ConvertType<T2>(t1);
            
        }

        public static T2 Map<T1, T2>(T1 t1, Func<MyMappingExpression<T1, T2>, MyMappingExpression<T1, T2>> myMappingExpression) where T2 : new()
        {
            T2 t2 = Map<T1, T2>(t1);
            MyMappingExpression<T1, T2> expressions = new MyMappingExpression<T1, T2>();
            myMappingExpression.Invoke(expressions);
            var dicts = expressions.dict;

            foreach (var item in dicts)
            {
                var func1 = item.Key;
                var func2 = item.Value;
                var T1member = func1.GetMember().Name;
                var T2member = func2.GetMember()?.Name;
                if (T2member != null)
                {
                    var T1propInfo = typeof(T1).GetProperty(T1member);
                    var T2propInfo = typeof(T2).GetProperty(T2member);
                    var v1 = T1propInfo.GetValue(t1);
                    T2propInfo.SetValue(t2, v1);

                }
                else
                {
                    var T1propInfo = typeof(T1).GetProperty(T1member);
                    var T2propInfo = typeof(T2).GetProperty(T1member);
                    var v = func2.Compile().Invoke(t2);

                    T2propInfo.SetValue(t2, v);
                }
            }
            return t2;
        }

       private static T2 ConvertType<T2>(object source)
       {
            
            IMapper mapper = null;
            
            switch (source.GetType().GetTypeProperty())
            {
                case ConvertCategory.BasicType:
                    mapper = new BasicMapper();
                    break;
                case ConvertCategory.ClassType:
                    mapper = new ClassMapper();
                    break;
                case ConvertCategory.ArrayType:
                    mapper = new ArrayMapper();
                    break;
                case ConvertCategory.CollectionType:
                    mapper = new CollectionMapper();
                    break;
                case ConvertCategory.EnumType:
                    mapper = new EnumMapper();
                    break;
            }

            return mapper.Convert<T2>(source);
                
       }
    }
}
