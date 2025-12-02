using MaterialDesignMessageBox.Services;
using MaterialDesignMessageBox.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MaterialDesignMessageBox
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
            containerRegistry.Register<IMessageBoxService, MessageBoxService>();

            containerRegistry.Register<TwoView>();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Window twoView = Container.Resolve<TwoView>();
            twoView.Show();
        }
    }

}
