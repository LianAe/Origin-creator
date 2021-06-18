using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Origin_creator.Classes
{
    public class Power
    {
        [JsonIgnore]
        public string powerJsonName;

        //Property names are as in the Json
        public string name;
        public string description;
        public string type;
        public bool hidden;
        public string condition;

        public Power(string name, string description, string type, bool hidden, dynamic condition)
        {
            this.name = name;
            this.description = description;
            this.type = type;
            this.hidden = hidden;
            this.condition = condition?.ToString();
        }
    }
}
