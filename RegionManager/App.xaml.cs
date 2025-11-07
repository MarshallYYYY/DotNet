using RegionManager.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace RegionManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AAAView>();
            containerRegistry.RegisterForNavigation<BBBView>();
        }
    }
}