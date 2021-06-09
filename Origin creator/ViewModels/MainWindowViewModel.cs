using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using Microsoft.Win32;
using MessageBox = System.Windows.MessageBox;

namespace Origin_creator.ViewModels
{
    class MainWindowViewModel
    {
        public ICommand OpenOriginCommand { get; set; }
        public ICommand CreateNewOriginCommand { get; set; }
        public Visibility OriginMenuVisibility { get; set; }

        private MainWindowModel mainWindowModel;

        public MainWindowViewModel()
        {
            this.OriginMenuVisibility = Visibility.Hidden;
            this.OpenOriginCommand = new RelayCommand(this.SelectOriginToOpen, () => true);
            this.CreateNewOriginCommand = new RelayCommand(() => MessageBox.Show("",""), () => true);
            this.mainWindowModel = new MainWindowModel();
        }

        private void SelectOriginToOpen()
        {
            this.mainWindowModel.OpenOrigin(); //Dialog to chose folder gets opened.
            if (!this.mainWindowModel.IsFolderDataPack())
            {
                MessageBoxResult result = MessageBox.Show("Folder is not an Origin data pack", "Invalide folder", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                { 
                    this.SelectOriginToOpen();
                }
            }
            else
            {
                this.mainWindowModel.LoadOrigin();
            }
            
        }
    }
}
