using System.Collections.Generic;
using System.Linq;

namespace Origin_creator.ViewModels
{
    public class NewOriginViewModel
    {
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

        private byte impact;
        private string selectedIcon;
        private List<IconItem> iconList;

        public NewOriginViewModel(List<IconItem> iconList)
        {
            this.iconList = iconList;
            this.ListIconsName = this.iconList.Select(i => i.ItemName).ToList();
        }

        public void UpdateIcon()
        {   //Sets the path of the Icon that is selected
            this.ItemIconPath = this.iconList.Find(n =>
                n.ItemName == this.SelectedIcon)?.ItemIconPath;
        }
    }
}
