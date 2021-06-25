using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Origin_creator.ViewModels;

namespace Origin_creator
{
    public class IconItem
    {
        //variables
        public readonly string ItemName;
        public string ItemNameId { get; }
        private string itemId;
        public string ItemIconPath { get; }

        //constructor
        public IconItem(string itemName, string itemId)
        {
            this.ItemName = itemName;
            this.itemId = itemId;
            this.ItemNameId = itemName.ToLower().Replace(" ", "_");//The Json list i'm using dosen't contain the exact item Namespace-Id so i have to convert the name.
            this.ItemIconPath = "/Origin creator;component/itemIcons/" + this.itemId + ".png";
        }

    }
}
