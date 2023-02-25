using Engine;
using GUI;
using System.Windows;

namespace IceEmulator
{
    public partial class App : Application
    {
        // redefining actions on app startup
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Chassis chassis = new Chassis();
            MainWindow mainWindow = new MainWindow();
            LifeCycle lifeCycle = new LifeCycle();

            Presenter presenter = new Presenter(mainWindow, chassis, lifeCycle);

            
            mainWindow.Activate();
            mainWindow.Show();
        }
    }
}
