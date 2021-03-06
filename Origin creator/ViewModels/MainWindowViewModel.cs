using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Origin_creator.Annotations;
using Origin_creator.Classes;
using Origin_creator.Views;
using MessageBox = System.Windows.MessageBox;

namespace Origin_creator.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand OpenOriginCommand { get;}
        public ICommand CreateNewOriginCommand { get; }
        public ICommand SaveOriginCommand { get; }
        public ICommand EditingModeCommand { get; }//Button to go in editing mode (leaving ReadonlyMode)
        public ICommand AddPowerCommand { get; }
        public ICommand RemovePowerCommand { get; }
        public ObservableCollection<SelectablePowerViewModel> VanillaPowersToSelect { get; set; }

        public Visibility OriginMenuVisibility { get; private set; }//Menu is only visible if Origin is open.
        public Visibility StartButtonsVisibility { get; private set; }//Buttons are only visible if no Origin is open.
        public Visibility ReadonlyModeVisibility { get; set; } //Power selection is hidden in Readonly Mode
        public bool ReadonlyMode { get; private set; }
        public string BtnEditing { get; private set; }
        public string BtnSaveChanges { get; set; }
        private Origin OpenOrigin { get; set; }
        public SelectablePowerViewModel SelectedVanillaPower { get; set; }

        //Values of Origin
        public List<string> ListIconsName
        {
            get => listIconsName;
            set
            {
                listIconsName = value;
                this.SavableValuesChanged();
            }
        }

        public string TxtOriginName { get; set; }
        public string ItemIconPath { get; private set; } //Path for the Icon PNG

        public string TxtOriginDescription
        {
            get => _txtOriginDescription;
            set
            {
                _txtOriginDescription = value;
                this.SavableValuesChanged();
            } 
        }

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
                this.SavableValuesChanged();
            }
        }

        public string SelectedIcon
        {
            get => selectedIcon;
            set
            {
                selectedIcon = value;
                this.UpdateIcon();
                this.SavableValuesChanged();
            } 
        }

        public List<string> ListPowers { get; set; }

        public string SelectedPower
        {
            get => this.selectedPower;
            set
            {
                this.selectedPower = value;
                if (value != null)
                    this.FillPowerValues();
            } 
        }

        //Values for Power
        public string TxtPowerName { get; set; }
        public string TxtPowerDescription { get; set; }
        public string TxtType { get; set; }
        public bool IsPowerHidden { get; set; }
        public string TxtCondition { get; set; }



        private LoadOriginFilesModel loadOriginFilesModel;
        private byte impact;
        private string selectedPower;
        private string selectedIcon;
        private string _txtOriginDescription;
        private List<string> listIconsName;

        public MainWindowViewModel()
        {
            this.StartButtonsVisibility = Visibility.Visible;
            this.OriginMenuVisibility = Visibility.Hidden;
            this.ReadonlyModeVisibility = Visibility.Collapsed;
            this.ReadonlyMode = true;
            this.BtnEditing = "Edit origin";
            this.BtnSaveChanges = "Save";

            this.OpenOriginCommand = new RelayCommand(this.SelectOriginToOpen, () => true);
            this.CreateNewOriginCommand = new RelayCommand(CreateNewOrigin, () => true);
            this.SaveOriginCommand = new RelayCommand(() => this.SaveOpenOrigin(), () => this.TxtOriginName != null);
            this.EditingModeCommand = new RelayCommand(this.ChangeEditingMode, () => true);
            this.AddPowerCommand = new RelayCommand(this.AddPowerToOrigin, () => true);
            this.RemovePowerCommand = new RelayCommand(this.RemovePowerFromOrigin, () => true);

            this.loadOriginFilesModel = new LoadOriginFilesModel();
            FillVanillaPowersToSelect();
        }

        private void FillVanillaPowersToSelect()
        {
            this.VanillaPowersToSelect = new ObservableCollection<SelectablePowerViewModel>();
            foreach (Power power in this.loadOriginFilesModel.VanillaPowers)
                //Fill listBox with powers you can choose. 
            {   //Dosen't work well because the name and descriptions are saved in an other file.
                this.VanillaPowersToSelect.Add(new SelectablePowerViewModel(power.name, power.description, power));
            }
        }

        private void CreateNewOrigin()
        {
            FillVanillaPowersToSelect();
            NewOriginView createOriginWindow = new NewOriginView()
            {
                DataContext = new NewOriginViewModel(this.loadOriginFilesModel.IconsList, this.VanillaPowersToSelect)
            };

            createOriginWindow.ShowDialog();
        }

        private void SelectOriginToOpen()
        {
            this.loadOriginFilesModel.OpenOrigin(); //Dialog to chose folder gets opened.
            if (!this.loadOriginFilesModel.IsFolderDataPack())
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
            this.OpenOrigin = this.loadOriginFilesModel.LoadOrigin();
            this.OriginMenuVisibility = Visibility.Visible;
            this.StartButtonsVisibility = Visibility.Hidden;

            this.TxtOriginName = this.OpenOrigin.name;
            this.TxtOriginDescription = this.OpenOrigin.description;
            this.Impact = this.OpenOrigin.impact;
            this.ListIconsName = this.loadOriginFilesModel.IconsList.Select(i => i.ItemName).ToList();
            int startIntIcon = this.OpenOrigin.icon.LastIndexOf(":") + 1;
            //Exact item name is searched by nameId in the iconlist
            this.SelectedIcon = this.loadOriginFilesModel.IconsList.Find(n => n.ItemNameId == this.OpenOrigin.icon.Substring(startIntIcon)).ItemName;
            this.ItemIconPath = this.loadOriginFilesModel.IconsList.Find(n => n.ItemNameId == this.OpenOrigin.icon.Substring(startIntIcon)).ItemIconPath;
            this.BtnSaveChanges = this.BtnSaveChanges.Replace("*", "");
            this.UpdatePowerLists();
        }

        private void FillPowerValues()
        {
            Power openPower;
            if (this.SelectedPower.StartsWith("origins:"))
            {   //Geting the power values from the vanilla list if it starts with "origin:"
                openPower = this.loadOriginFilesModel.VanillaPowers.Find(pw => pw.powerJsonName == this.SelectedPower.Replace("origins:", ""));
            }
            else
            {   
                openPower = this.OpenOrigin.PowersList.Find(pw => pw.powerJsonName == this.SelectedPower.Substring(this.SelectedPower.IndexOf(":") + 1));
            }

            if (openPower != null)
            {
                //If the Origin has no name, the file name is used.
                this.TxtPowerName = openPower.name ?? this.SelectedPower.Substring(this.SelectedPower.IndexOf(":") + 1);
                this.TxtPowerDescription = openPower.description ?? "No description";
                this.TxtType = openPower.type;
                this.TxtCondition = openPower.condition;
                this.IsPowerHidden = openPower.hidden;
            }
        }
        private void ChangeEditingMode()
        {
            if (ReadonlyMode)
            {
                ReadonlyMode = false;
                this.ReadonlyModeVisibility = Visibility.Visible;
                this.BtnEditing = "Exit editing mode";
            }
            else if (!ReadonlyMode)
            {
                ReadonlyMode = true;
                this.ReadonlyModeVisibility = Visibility.Collapsed;
                this.BtnEditing = "Edit origin";
            }
        }

        private void SaveOpenOrigin()
        {
            // this.openOrigin.name = this.TxtOriginName;
            this.OpenOrigin.description = this.TxtOriginDescription;
            this.OpenOrigin.impact = this.impact;
            //The json file needs a namespace in front of the icon, usually "minecraft:"
            this.OpenOrigin.icon = this.loadOriginFilesModel.IconsList.Find(ic => ic.ItemName == this.SelectedIcon).ItemNameId.Insert(0, "minecraft:");
            this.loadOriginFilesModel.SaveOriginToJson(this.OpenOrigin);
            this.BtnSaveChanges = this.BtnSaveChanges.Replace("*", "");
        }
        public void UpdateIcon()
        {   //Sets the path of the Icon that is selected
            this.ItemIconPath = this.loadOriginFilesModel.IconsList.Find(n => 
                n.ItemName == this.SelectedIcon)?.ItemIconPath;
        }
        private void AddPowerToOrigin()
        {
            string powerToAddName = this.SelectedVanillaPower.power.powerJsonName.Insert(0, "origins:");
            this.OpenOrigin.powers.Add(powerToAddName);
            this.SavableValuesChanged();
            this.UpdatePowerLists();
        }

        private void RemovePowerFromOrigin()
        {
            this.OpenOrigin.powers.Remove(this.SelectedPower);
            this.SavableValuesChanged();
            UpdatePowerLists();
        }

        private void UpdatePowerLists()//Updates VanillaPowers and Powers of the Origin
        {
            this.ListPowers = new List<string>(this.OpenOrigin.powers);
            this.FillVanillaPowersToSelect();//Resets List to all vanilla Powers
            //Removing selectable vanilla Powers that are already in Origin
            foreach (string power in OpenOrigin.powers.Where(pw => pw.StartsWith("origins:")))
            {
                try
                {
                    this.VanillaPowersToSelect.Remove(this.VanillaPowersToSelect.Single(pw => pw.power.powerJsonName.Equals(power.Replace("origins:", ""))));
                }
                catch (InvalidOperationException e)
                {

                }
            }
        }

        private void SavableValuesChanged()
        {
            this.BtnSaveChanges = "Save*";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
