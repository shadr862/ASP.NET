using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All
{
    internal class student
    {
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
    }
    internal class Subject
    {
        public string SubName { get; set; }
        public int SubMarkes { get; set; }
    }
}
