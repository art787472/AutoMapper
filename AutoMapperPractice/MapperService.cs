using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    internal class MapperService
    {
        
        private MapperConfiguration configuration;

        public MapperService()
        {
            configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<User, Student>()
                .ForMember(x => x.Name, y => y.MapFrom(o => $"student:{o.Name}"))
                .ForMember(x => x.Description, y => y.MapFrom(o => $"student describes:{o.Name}"))

                );
        }

        public static T2 Map<T1, T2>(T1 user, Func<IMappingExpression<T1, T2>, IMappingExpression<T1, T2>> func)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                func.Invoke(cfg.CreateMap<T1, T2>());
                
            });
            return configuration.CreateMapper().Map<T2>(user);
            
            
        }



    }
}
