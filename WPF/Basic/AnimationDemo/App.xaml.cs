using System.Configuration;
using System.Data;
using System.Windows;

namespace AnimationDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //new MainWindow().Show();
            new Animation2Window().Show();
            new LinearWindow().Show();
            new DiscreteWindow().Show();
            new SplineWindow().Show();
            new EasingWindow().Show();
        }
    }

}
