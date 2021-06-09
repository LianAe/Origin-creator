using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Origin_creator
{
    class MainWindowModel
    {
        //Variables
        private Origin openOrigin;

        //Constructor
        public MainWindowModel()
        {
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
            if (
                Directory.Exists(this.openOrigin.FolderPath) //TEST To DELETE
                                                           /*
                File.Exists(this.openOrigin.FolderPath + "\\pack.mcmeta") && 
                Directory.Exists(this.openOrigin.FolderPath + $"\\data\\{this.openOrigin.OriginNameCode}\\powers") && 
                File.Exists(this.openOrigin.FolderPath + "\\data\\origins\\origin_layers\\origins.json") &&
                File.Exists(this.openOrigin.FolderPath + ("\\data\\{0}\\origins\\{0}", this.openOrigin.OriginNameCode))*/)
            {
                return true;
            }

            return false;
        }

        public void LoadOrigin()
        {

        }
    }
    
}
