using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using Microsoft.Win32;
using Origin_creator.Annotations;
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

        public Visibility OriginMenuVisibility { get; private set; }
        public Visibility StartButtonsVisibility { get; private set; }
        public Visibility ReadonlyModeVisibility { get; }
        public bool ReadonlyMode { get; }
        public Origin LoadedOrigin { get; private set; }

        //Values of Origin
        public List<string> ListIconsName { get; set; }
        public string TxtOriginName { get; set; }
        public string ItemIconPath { get; private set; }
        public string TxtOriginDescription { get; set; }

        public byte Impact
        {
            get => this.impact;
            set
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

        //Values for Power
        public string TxtPowerName { get; set; }
        public string TxtPowerDescription { get; set; }
        public string TxtType { get; set; }
        public bool IsHidden { get; set; }



        private MainWindowModel mainWindowModel;
        private byte impact;

        public MainWindowViewModel()
        {
            this.StartButtonsVisibility = Visibility.Visible;
            this.OriginMenuVisibility = Visibility.Hidden;
            this.OpenOriginCommand = new RelayCommand(this.SelectOriginToOpen, () => true);
            this.CreateNewOriginCommand = new RelayCommand(() => MessageBox.Show("",""), () => true);
            this.SaveOriginCommand = new RelayCommand(() => this.mainWindowModel.SaveOriginToJson(this.LoadedOrigin), () => this.TxtOriginName != null);
            this.ReadonlyMode = true;
            this.ReadonlyModeVisibility = Visibility.Hidden;
            this.mainWindowModel = new MainWindowModel();
        }

        private void SelectOriginToOpen()
        {
            this.mainWindowModel.OpenOrigin(); //Dialog to chose folder gets opened.
            if (!this.mainWindowModel.IsFolderDataPack())
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
                this.LoadOriginValues();
            }
            
        }

        private void LoadOriginValues()
        {
            this.LoadedOrigin = this.mainWindowModel.LoadOrigin();
            this.OriginMenuVisibility = Visibility.Visible;
            this.StartButtonsVisibility = Visibility.Hidden;

            this.TxtOriginName = this.LoadedOrigin.name;
            this.TxtOriginDescription = this.LoadedOrigin.description;
            this.Impact = this.LoadedOrigin.impact;
            this.ListIconsName = this.mainWindowModel.iconsList.Select(i => i.ItemName).ToList();
            int startIntIcon = this.LoadedOrigin.icon.LastIndexOf(":") + 1;
            //Exact item name is searched by nameId in the iconlist
            this.SelectedIcon = this.mainWindowModel.iconsList.Find(n => n.ItemNameId == this.LoadedOrigin.icon.Substring(startIntIcon)).ItemName;
            this.ItemIconPath = this.mainWindowModel.iconsList.Find(n => n.ItemNameId == this.LoadedOrigin.icon.Substring(startIntIcon)).ItemIconPath;
            this.ListPowers = this.LoadedOrigin.powers;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
