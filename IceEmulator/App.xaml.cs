using Engine;
using GUI;
using System.Windows;
using View;

namespace IceEmulator
{
    public partial class App : Application
    {
        // redefining actions on app startup
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            LifeCycle lifeCycle = new LifeCycle();
            ChassisInfromation chassisInfromation = new ChassisInfromation();
            Presenter presenter = new Presenter(mainWindow, lifeCycle, chassisInfromation);

            mainWindow.Activate();
            mainWindow.Show();
        }
    }
}
