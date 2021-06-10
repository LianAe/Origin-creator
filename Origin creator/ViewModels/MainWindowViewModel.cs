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
        public ICommand CreateNewOriginCommand { get;}

        public Visibility OriginMenuVisibility { get; set; }

        //Values of Origin
        public List<string> ListIconsName { get; set; }
        public string TxtOriginName { get; set; }
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
            this.OriginMenuVisibility = Visibility.Hidden;
            this.OpenOriginCommand = new RelayCommand(this.SelectOriginToOpen, () => Convert.ToBoolean(OriginMenuVisibility));
            this.CreateNewOriginCommand = new RelayCommand(() => MessageBox.Show("",""), () => Convert.ToBoolean(OriginMenuVisibility));
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
                this.loadOriginValues();
            }
            
        }

        private void loadOriginValues()
        {
            Origin loadedOrigin = this.mainWindowModel.LoadOrigin();
            this.OriginMenuVisibility = Visibility.Visible;

            this.TxtOriginName = loadedOrigin.OriginName;
            this.TxtOriginDescription = loadedOrigin.originDescription;
            this.Impact = loadedOrigin.originImpact;
            this.ListIconsName = this.mainWindowModel.iconsList.Select(i => i.itemName).ToList();
            this.ListPowers = loadedOrigin.originPowersList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
