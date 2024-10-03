using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    internal class MyMappingExpression<T1, T2>
    {
        public Dictionary<Expression<Func<T1, object>>, Expression<Func<T2, object>>> dict = new Dictionary<Expression<Func<T1, object>>, Expression<Func<T2, object>>>();
        public MyMappingExpression<T1, T2> FromMember(Expression<Func<T1, object>> func1, Expression<Func<T2, object>> func2) 
        {
            dict[func1] = func2;
            return this;
        }
    }
}
