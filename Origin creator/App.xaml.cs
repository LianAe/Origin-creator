using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Origin_creator.ViewModels;
using Origin_creator;

namespace Origin_creator
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel()
            };

            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
