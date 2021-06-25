using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Origin_creator.Classes;

namespace Origin_creator.ViewModels
{
    public class SelectablePowerViewModel
    {
        public string TxtName { get; }
        public string TxtDescription { get; }
        public Power power { get; }

        public SelectablePowerViewModel(string txtName, string txtDescription, Power power)
        {
            TxtName = txtName;
            this.power = power;
            TxtDescription = txtDescription ?? "No description";
        }
    }
}
