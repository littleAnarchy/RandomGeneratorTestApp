using RandomGenerator.Desktop.View;
using System.Windows;

namespace RandomGenerator.Desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = CompositionRoot.Composite();
            mainWindow.Show();
        }
    }
}
