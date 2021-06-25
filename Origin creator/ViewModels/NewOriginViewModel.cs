using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using Origin_creator.Annotations;
using Origin_creator.Models;

namespace Origin_creator.ViewModels
{
    public class NewOriginViewModel : INotifyPropertyChanged
    {
        //This Class need a lot of refactoring
        public ICommand AddVanillaPowerCommand { get; }
        public ICommand CreateNewOriginCommand { get; }

        private Origin newOrigin;
        private NewOriginModel newOriginModel;
        public string TxtOriginName { get; set; }
        public string ItemIconPath { get; set; }
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

        public string SelectedIcon
        {
            get => selectedIcon;
            set
            {
                selectedIcon = value;
                this.UpdateIcon();
            }
        }
        public string SelectedPower { get; set; }
        public List<string> ListPowers { get; set; }
        public List<string> ListIconsName { get; }
        public ObservableCollection<SelectablePowerViewModel> VanillaPowersToSelect { get; set; }
        public SelectablePowerViewModel SelectedVanillaPower { get; set; }

        private byte impact;
        private string selectedIcon;
        private List<IconItem> iconList;

        public NewOriginViewModel(List<IconItem> iconList, ObservableCollection<SelectablePowerViewModel> vanillaPowersToSelect)
        {
            this.iconList = iconList;
            this.ListIconsName = this.iconList.Select(i => i.ItemName).ToList();
            this.VanillaPowersToSelect = vanillaPowersToSelect;
            this.AddVanillaPowerCommand = new RelayCommand(AddVanillaPowerToOrigin, () => true);
            this.CreateNewOriginCommand = new RelayCommand(CreateNewOriginDatapack, () => true);

            FolderBrowserDialog whereToSaveOrigin = new FolderBrowserDialog();
            whereToSaveOrigin.ShowDialog();
            this.newOrigin = new Origin(whereToSaveOrigin.SelectedPath);
            this.newOriginModel = new NewOriginModel(this.newOrigin);

        }

        private void CreateNewOriginDatapack()
        {
            newOriginModel.CreateOriginDatapack();
        }

        private void AddVanillaPowerToOrigin()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateIcon()
        {   //Sets the path of the Icon that is selected
            this.ItemIconPath = this.iconList.Find(n =>
                n.ItemName == this.SelectedIcon)?.ItemIconPath;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
