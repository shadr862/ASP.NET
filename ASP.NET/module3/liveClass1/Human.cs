using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liveClass1
{
    public class Human:Religion,Ihobby
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Dname { get; set; }
        public string HobbyName { get; set;}

        public Human()
        {
            this.Name = "NULL";
            this.Age = 0;
            this.Dname = "NULL";
        }
        public Human( string name,int age,string dname)
        {
            this.Name = name;
            this.Age = age;
            this.Dname = dname;

        }
        //polymorphisim -function overloading
        public string BioData()
        {
            return this.Name+" "+this.Age+" "+this.Dname;
        }
        public string BioData(string name, int age, string dname)
        {
            this.Name = name;
            this.Age = age;
            this.Dname = dname;
            return this.Name + " " + this.Age + " " + this.Dname;
        }
        //inheretance with function overloading
        public string BioData(string name, int age, string dname,string religion)
        {
            this.Name = name;
            this.Age = age;
            this.Dname = dname;
            this.religionName = religion;
            return this.Name + " " + this.Age + " " + this.Dname+" "+this.religionName;
        }

        public string GetHobby(string name)
        {
            this.HobbyName = name;
            return this.HobbyName;
        }
    }
}
