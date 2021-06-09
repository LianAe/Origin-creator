using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origin_creator
{
    class Origin
    {
        public string OriginName { get; private set; }
        public string OriginNameCode { get; }
        public string FolderPath { get; }

        public Origin(string originName, string originNameCode, string folderPath)
        {
            this.OriginName = originName;
            this.OriginNameCode = originNameCode;
            this.FolderPath = folderPath;
        }
    }
}
