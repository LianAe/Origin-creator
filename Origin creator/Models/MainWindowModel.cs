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
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Origin_creator
{
    class MainWindowModel
    {
        //Variables
        private Origin openOrigin;
        public List<IconItem> iconsList { get; }

        //Constructor
        public MainWindowModel()
        {
            this.iconsList = this.WriteIconListFromItemsList();
        }

        //Methods
        public void OpenOrigin()
        {
            FolderBrowserDialog getFolder = new FolderBrowserDialog();
            getFolder.ShowDialog();
            this.openOrigin = new Origin(
                Path.GetFileName(getFolder.SelectedPath), //Returns text after the last '/'
                Path.GetFileName(getFolder.SelectedPath).Replace(" ", "_").ToLower(), //Converting the folder name because the subfolders shouldn't use spaces or uppercase.
                getFolder.SelectedPath
                );
        }

        public bool IsFolderDataPack()
        {
            if (//Checking if all the needed files or folders are where they should be.
                File.Exists(this.openOrigin.OriginFolderPath + "\\pack.mcmeta") && 
                Directory.Exists(this.openOrigin.OriginFolderPath + $"\\data\\{this.openOrigin.OriginNameCode}\\powers") && 
                File.Exists(this.openOrigin.OriginFolderPath + "\\data\\origins\\origin_layers\\origin.json") &&
                File.Exists(this.openOrigin.OriginFolderPath + $"\\data\\{this.openOrigin.OriginNameCode}\\origins\\{this.openOrigin.OriginNameCode}.json"))
            {
                return true;
            }

            return false;
        }

        public Origin LoadOrigin()
        {
            string originJsonText = File.ReadAllText(this.openOrigin.OriginFolderPath +
                                                     $"\\data\\{this.openOrigin.OriginNameCode}\\origins\\{this.openOrigin.OriginNameCode}.json");
            //File with the fields: name, description, icon, impact, powers
            dynamic originJsonDeserialized = JsonConvert.DeserializeObject(originJsonText);
            this.openOrigin.SetValuesFromJson(originJsonDeserialized);
            return this.openOrigin;
        }

        public List<IconItem> WriteIconListFromItemsList()
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

        public void SaveOriginToJson(string name, string description, string icon, List<Power> powers, List<string> powersList)
        {
            
        }
    }
    
}
