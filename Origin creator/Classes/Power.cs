using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origin_creator.Classes
{
    class Power
    {
        private string powerName;
        private string powerDescription;
        private string powerType;
        private bool hidden;

        public Power(string powerName, string powerDescription, string powerType, bool hidden)
        {
            this.powerName = powerName;
            this.powerDescription = powerDescription;
            this.powerType = powerType;
            this.hidden = hidden;
        }
    }
}
