using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
