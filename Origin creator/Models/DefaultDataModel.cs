using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Origin_creator.Classes;

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

        public static List<Power> ReadVanillaPowers()
        {
            var test = Directory.GetDirectories(".");
            string[] vanillaPowerFiles = Directory.GetFiles(".\\vanillaPowers\\");//Static path for now.
            List <Power> vanillaPowers = new List<Power>();
            foreach (string powerFile in vanillaPowerFiles)
            {
                vanillaPowers.Add(ReadPowerFile(powerFile));
            }
            return vanillaPowers;
        }

        public static Power ReadPowerFile(string path)
        {
            Power deserializedPower = JsonConvert.DeserializeObject<Power>(File.ReadAllText(path));
            deserializedPower.powerJsonName = path.Substring(path.LastIndexOf('\\') + 1).Replace(".json", "");
            if (deserializedPower.name == null)
                deserializedPower.name = deserializedPower.powerJsonName;
            
            return deserializedPower;
        }
    }
}
