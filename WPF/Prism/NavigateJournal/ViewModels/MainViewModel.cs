using NavigateJournal.Common;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigateJournal.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);

            GoBackCommand = new DelegateCommand(GoBack);
            GoForwardCommand = new DelegateCommand(GoForward);
        }
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private void Navigate(string target)
        {
            // 若有 NavigationParameters 对象需要传递用来发送信息，则将对象放入形参的最后即可。
            regionManager.RequestNavigate(
                Constants.MainViewRegionName, target,
                NavigationCallbackFun);
        }

        #region 导航日志 Journal
        private IRegionNavigationJournal? journal;

        // 当然也可以不用函数，用 Lambda 表达式。
        private void NavigationCallbackFun(NavigationResult result)
        {
            if (result.Success)
            {
                NavigationContext? context = result.Context;
                journal = context?.NavigationService.Journal;
            }
        }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoForwardCommand { get; set; }
        private void GoBack()
        {
            if (journal is not null && journal.CanGoBack)
                journal.GoBack();
        }
        private void GoForward()
        {
            if (journal is not null && journal.CanGoForward)
                journal.GoForward();
        }
        #endregion
    }
}