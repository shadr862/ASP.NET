using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liveClass1
{
    public class Animal
    {
        public string GetSound(string animal)
        {
            if(animal=="cat")
            {
                return " Mew Mew";
            }
            else if (animal == "dog")
            {
                return " Bark Bark ";
            }
            else
            {
                return " Animal name does not Match";
            }
        }
    }
}
