using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveClass2
{
    public abstract class Stationary
    {
         public string StationaryName { get; set; }
         public string GetStationaryName(string name)
         {
            this.StationaryName = name;
            return this.StationaryName;
         }

        public abstract string GetStationaryInformation();


    }
}
