using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Origin_creator.ViewModels
{
    class MainWindowViewModel
    {
        public ICommand OpenOriginCommand { get; set; }
        public ICommand CreateNewOriginCommand { get; set; }
        public Visibility OriginMenuVisibility { get; set; }
    }
}
