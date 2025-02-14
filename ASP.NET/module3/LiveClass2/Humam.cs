using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveClass2
{
    public class Humam:Stationary
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<MyTask> ListTask { get; set; }
        public MyTask myTask { get; set; }

        public Humam()
        {
            ListTask = new List<MyTask>();
            myTask = new MyTask();
            this.Name = "NULL";
            this.Age = 0;
        }

        public string Information()
        {
            return this.Name + " " + this.Age;
        }

        public string Information(string name,int age)
        {
            this.Name = name;
            this.Age = age;

            return this.Name + " " + this.Age;
        }

        public override string GetStationaryInformation()
        {
            return "the abstract function is override here";
        }
    }
}
