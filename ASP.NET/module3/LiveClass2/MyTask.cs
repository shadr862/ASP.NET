using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveClass2
{
    public class MyTask
    {
        public string TaskName { get; set; }
        public MyTask()
        {
            TaskName = "Default";
        }

        public static int TaskNumber()
        {
            return 1;
        }
    }
}
