using System.Collections.Generic;
using Newtonsoft.Json;

namespace Origin_creator
{
    class Origin
    {
        [JsonIgnore]//Json serializer will ignore this
        public string OriginNameCode { get; }
        [JsonIgnore]
        public string OriginFolderPath { get; }

        public List<string> powers;//Variable names are as in JSON for easy converting
        public string icon;
        public byte impact;
        public string name { get; set; }
        public string description;


        public Origin(string name, string originNameCode, string originFolderPath)
        {
            this.name = name;
            this.OriginNameCode = originNameCode;
            this.OriginFolderPath = originFolderPath;
            this.powers = new List<string>();
        }

        public void SetValuesFromJson(dynamic originJsonValues)
        {
            this.name = originJsonValues.name;
            this.description = originJsonValues.description;
            this.impact = originJsonValues.impact;
            this.icon = originJsonValues.icon;
            this.powers = originJsonValues.powers.ToObject<List<string>>();
        }
    }
}
