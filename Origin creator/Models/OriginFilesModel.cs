using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Newtonsoft.Json;
using Origin_creator.Classes;
using Origin_creator.Models;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Origin_creator
{
    class OriginFilesModel
    {
        //Fields
        private Origin openOrigin;
        public List<IconItem> iconsList { get; }
        private string originJsonPath;
        private string powersFolderPath;

        //Constructor
        public OriginFilesModel()
        {
            this.iconsList = DefaultDataModel.WriteIconListFromItemsList();
        }

        //Methods
        public void OpenOrigin()
        {
            FolderBrowserDialog getFolder = new FolderBrowserDialog();
            getFolder.ShowDialog();
            this.openOrigin = new Origin(
                Path.GetFileName(getFolder.SelectedPath), //Returns text after the last '/'
                Path.GetFileName(getFolder.SelectedPath).Replace("_origin", "").Replace(" ", "_").ToLower(),//Converting the folder name because the subfolders shouldn't use spaces or uppercase.
                                                                                                            //Sometimes the folder has _origin at the end wich needs to be removed.
                getFolder.SelectedPath
                );
            this.originJsonPath = this.openOrigin.OriginFolderPath + $"\\data\\{this.openOrigin.OriginNameCode}\\origins\\{this.openOrigin.OriginNameCode}.json";
            this.powersFolderPath = this.openOrigin.OriginFolderPath + $"\\data\\{this.openOrigin.OriginNameCode}\\powers";
        }

        public bool IsFolderDataPack()
        {
            if (//Checking if all the needed files or folders are where they should be.
                File.Exists(this.openOrigin.OriginFolderPath + "\\pack.mcmeta") && 
                Directory.Exists(this.powersFolderPath) && 
                File.Exists(this.openOrigin.OriginFolderPath + "\\data\\origins\\origin_layers\\origin.json") &&
                File.Exists(this.originJsonPath))
            {
                return true;
            }

            return false;
        }

        public Origin LoadOrigin()
        {
            string originJsonText = File.ReadAllText(this.originJsonPath);
            //File with the fields: name, description, icon, impact, powers
            dynamic originJsonDeserialized = JsonConvert.DeserializeObject(originJsonText);
            this.openOrigin.SetValuesFromJson(originJsonDeserialized);
            //Load all powers from the Origin wich aren't from the base Mod
            foreach (string originPower in this.openOrigin.powers.Where(pw => !pw.StartsWith("origin")))
            {
                this.openOrigin.PowersList.Add(LoadPower(originPower));
            }
            return this.openOrigin;
        }

        public Power LoadPower(string powerName)
        {
            string powerJonsText = File.ReadAllText(this.powersFolderPath + "\\" + powerName.Substring(powerName.IndexOf(":") + 1) + ".json");
            Power deserializedPower = JsonConvert.DeserializeObject<Power>(powerJonsText);
            deserializedPower.powerJsonName = powerName;
            return deserializedPower;
        }

        public void SaveOriginToJson(Origin origin)
        {
            dynamic originJsonText = JsonConvert.SerializeObject(openOrigin, Formatting.Indented);
                File.WriteAllText(this.originJsonPath, originJsonText);
        }
    }
    
}
