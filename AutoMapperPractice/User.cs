using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    internal class User
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
        private Address _address;
        public Address[] Addresses { get; set; }
        public string[] Subjects { get; set; }

        public GradeEnum Grade { get; set; }
    }
}
