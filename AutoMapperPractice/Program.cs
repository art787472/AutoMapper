using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    internal class Program
    {


        static void Main(string[] args)
        {

            var address = new Address();
            address.Value = "user's address";
            var address2 = new Address();
            address2.Value = "user's address2";

            var addresses = new Address[] { address, address2 };
            var subjects = new string[] { "English", "Math" };
            var user = new User { Id = 1, Name = "Adom", Description = "I am Adom", Address = address, Subjects = subjects };
            user.Addresses = addresses;


            var s = MyAutoMapper.Map<User, Student>(user);


            var s2 = MyAutoMapper.Map<User, Student>(user, u =>
            {
                u.FromMember(x => x.Name, x => x.StudentName)
                .FromMember(x => x.Description, x => x.StudentDescription)
                .FromMember(x => x.Name, x => $"student: {x.Name}");

                return u;
            });

        }

    }
}
