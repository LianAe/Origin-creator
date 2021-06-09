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
        public string OriginName { get; set; }
        public string OriginNameCode { get; }
        public string OriginFolderPath { get; }
        public string originDescription;
        public byte originImpact;
        public string originIconNameId;
        public List<string> originPowersList;


        public Origin(string originName, string originNameCode, string originFolderPath)
        {
            this.OriginName = originName;
            this.OriginNameCode = originNameCode;
            this.OriginFolderPath = originFolderPath;
            this.originPowersList = new List<string>();
        }

        public void SetValuesFromJson(dynamic originJsonValues)
        {
            this.OriginName = originJsonValues.name;
            this.originDescription = originJsonValues.description;
            this.originImpact = originJsonValues.impact;
            this.originIconNameId = originJsonValues.icon;
            this.originPowersList = originJsonValues.powers.ToObject<List<string>>();
        }
    }
}
