using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Origin_creator.ViewModels;

namespace Origin_creator
{
    class IconItem
    {
        //variables
        public string itemName;
        private string itemNameId;
        private string itemId;
        private string itemIconPath;

        //constructor
        public IconItem(string itemName, string itemId, string itemNameId)
        {
            this.itemName = itemName;
            this.itemId = itemId;
            this.itemNameId = itemNameId;
            this.itemIconPath = ".\\items\\" + this.itemId + ".png";
        }

    }
}
