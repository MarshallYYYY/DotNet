using DialogHostDemo.Views;
using System.Windows;

namespace DialogHostDemo
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<OneView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
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