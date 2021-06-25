using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origin_creator.Models
{
    class NewOriginModel
    {
        public Origin OriginToCreat;

        public NewOriginModel(Origin originToCreat)
        {
            this.OriginToCreat = originToCreat;
        }


        public void CreateOriginDatapack()
        {
            Directory.CreateDirectory(this.OriginToCreat.OriginFolderPath + OriginToCreat.name);
        }
    }
}
