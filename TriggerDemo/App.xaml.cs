using System.Configuration;
using System.Data;
using System.Windows;

namespace TriggerDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new MainWindow().Show();
            new MultiTriggerWindow().Show();
            new EventTriggerWindow().Show();
            new DataTriggerWindow().Show();
        }
    }

}
