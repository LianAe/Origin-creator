using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Origin_creator.Models
{
    static class DefaultDataModel
    {

        public static List<IconItem> WriteIconListFromItemsList()
        {
            List<IconItem> itemsList = new List<IconItem>();
            string iconListFileText = File.ReadAllText(".\\items.json");
            dynamic iconList = JsonConvert.DeserializeObject(iconListFileText);
            foreach (var item in iconList)
            {
                itemsList.Add(new IconItem(item.name.ToString(), item.type.ToString() + "-" + item.meta.ToString()));
            }
            return itemsList;
        }
    }
}
