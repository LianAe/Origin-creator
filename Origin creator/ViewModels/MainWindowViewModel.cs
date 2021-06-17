using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Origin_creator.Annotations;
using Origin_creator.Classes;
using MessageBox = System.Windows.MessageBox;

namespace Origin_creator.ViewModels
{
    /*
    public static class GlobalVariables
    {
        public static string IconListPath = ".\\items\\";
    }*/
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand OpenOriginCommand { get;}
        public ICommand CreateNewOriginCommand { get; }
        public ICommand SaveOriginCommand { get; }

        public Visibility OriginMenuVisibility { get; private set; }//Menu is only visible if Origin is open.
        public Visibility StartButtonsVisibility { get; private set; }//Buttons are only visible if no Origin is open.
        public Visibility ReadonlyModeVisibility { get; }//Power selection is hidden in Readonly Mode
        public bool ReadonlyMode { get; }
        public Origin OpenOrigin { get; private set; }

        //Values of Origin
        public List<string> ListIconsName { get; set; }
        public string TxtOriginName { get; set; }
        public string ItemIconPath { get; private set; }//Path for the Icon PNG
        public string TxtOriginDescription { get; set; }

        public byte Impact
        {
            get => this.impact;
            set //Impact can't be over 3
            {
                if (value <= 3)
                {
                    this.impact = value;
                }
                else
                {
                    this.impact = 3;
                }
            }
        }
        public string SelectedIcon { get; set; }
        public List<string> ListPowers { get; set; }

        public string SelectedPower
        {
            get => this.selectedPower;
            set
            {
                this.selectedPower = value;
                this.FillPowerValues();
            } 
        }

        //Values for Power
        public string TxtPowerName { get; set; }
        public string TxtPowerDescription { get; set; }
        public string TxtType { get; set; }
        public bool IsPowerHidden { get; set; }



        private OriginFilesModel originFilesModel;
        private byte impact;
        private string selectedPower;

        public MainWindowViewModel()
        {
            this.StartButtonsVisibility = Visibility.Visible;
            this.OriginMenuVisibility = Visibility.Hidden;
            this.ReadonlyModeVisibility = Visibility.Hidden;
            this.ReadonlyMode = true;

            this.OpenOriginCommand = new RelayCommand(this.SelectOriginToOpen, () => true);
            this.CreateNewOriginCommand = new RelayCommand(() => MessageBox.Show("Coming soon","Not yet finished"), () => false);
            this.SaveOriginCommand = new RelayCommand(() => this.originFilesModel.SaveOriginToJson(this.OpenOrigin), () => this.TxtOriginName != null);

            this.originFilesModel = new OriginFilesModel();
        }

        private void SelectOriginToOpen()
        {
            this.originFilesModel.OpenOrigin(); //Dialog to chose folder gets opened.
            if (!this.originFilesModel.IsFolderDataPack())
            {
                //If the folder isn't an Origin, a message gets shown.
                MessageBoxResult result = MessageBox.Show("Folder is not an Origin data pack", "Invalide folder", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                { 
                    this.SelectOriginToOpen();
                }
            }
            else
            {
                this.FillOriginValues();
            }
            
        }

        private void FillOriginValues()
        {
            this.OpenOrigin = this.originFilesModel.LoadOrigin();
            this.OriginMenuVisibility = Visibility.Visible;
            this.StartButtonsVisibility = Visibility.Hidden;

            this.TxtOriginName = this.OpenOrigin.name;
            this.TxtOriginDescription = this.OpenOrigin.description;
            this.Impact = this.OpenOrigin.impact;
            this.ListIconsName = this.originFilesModel.iconsList.Select(i => i.ItemName).ToList();
            int startIntIcon = this.OpenOrigin.icon.LastIndexOf(":") + 1;
            //Exact item name is searched by nameId in the iconlist
            this.SelectedIcon = this.originFilesModel.iconsList.Find(n => n.ItemNameId == this.OpenOrigin.icon.Substring(startIntIcon)).ItemName;
            this.ItemIconPath = this.originFilesModel.iconsList.Find(n => n.ItemNameId == this.OpenOrigin.icon.Substring(startIntIcon)).ItemIconPath;
            this.ListPowers = this.OpenOrigin.powers;
        }

        private void FillPowerValues()
        {
            if (!this.SelectedPower.StartsWith("origin:"))
            {
                Power openPower = this.OpenOrigin.PowersList.Find(pw => pw.powerJsonName == this.SelectedPower);

                if (openPower.name != null)//If the Origin has no name, the file name is used.
                    this.TxtPowerName = openPower.name;
                else
                    this.TxtPowerName = this.SelectedPower.Substring(this.SelectedPower.IndexOf(":") + 1);
                
                this.TxtPowerDescription = openPower.description;
                this.TxtType = openPower.type;
                this.IsPowerHidden = openPower.hidden;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
