using System.Windows;
using Origin_creator.ViewModels;

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
