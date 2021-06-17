using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Origin_creator.Classes
{
    class Power
    {
        [JsonIgnore]
        public string powerJsonName;

        //Property names are as in the Json
        public string name;
        public string description;
        public string type;
        public bool hidden;

        public Power(string name, string description, string type, bool hidden)
        {
            this.name = name;
            this.description = description;
            this.type = type;
            this.hidden = hidden;
        }
    }
}
