using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Address Address
        {
            get => _address;
            set
            {
                this._address = value;
            }
        }

        private Address _address = null;

        public string[] Subjects { get; set; }

        public Address[] Addresses { get; set; }

        public GradeEnum Grade { get; set; }
        public string StudentName { get; set; }

        public string StudentDescription { get; set; }
    }
}
