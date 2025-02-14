using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liveClass1
{
    public interface Ihobby
    {
        public string HobbyName { get; set; }
        public string GetHobby(string name);
    }
}
