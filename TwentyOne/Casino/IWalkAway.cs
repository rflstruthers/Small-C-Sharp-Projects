using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Interfaces
{
    interface IWalkAway
    {
        //Method must be implemented by any class that inherits from the IWalkAway interface
        void WalkAway(Player player);
    }
}
