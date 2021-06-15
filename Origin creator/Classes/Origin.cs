using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Origin_creator.Classes;

namespace Origin_creator
{
    class Origin
    {
        public string OriginNameCode { get; }
        public string OriginFolderPath { get; }
        public string name { get; set; }//Variable names are as in JSON for easy converting
        public string description;
        public byte impact;
        public string icon;
        public List<string> powers;


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
