using System.Windows;
using Navigate.ViewModels;
using Navigate.Views;

namespace Navigate
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 因为 AAAViewModel.cs 中没有任何逻辑代码，所以添加与否都可以。
            //containerRegistry.RegisterForNavigation<AAAView>();
            containerRegistry.RegisterForNavigation<AAAView, AAAViewModel>();
            containerRegistry.RegisterForNavigation<BBBView, BBBViewModel>();
            containerRegistry.RegisterForNavigation<CCCView, CCCViewModel>();
        }
    }
}