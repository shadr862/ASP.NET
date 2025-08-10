using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace where_operator
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Tech> Programming { get; set; }
    }

    internal class Tech
    {
        public string skill { get; set; }
    }
}
