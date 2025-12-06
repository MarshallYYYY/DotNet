using Navigate.Common;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigate.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private void Navigate(string target)
        {
            //NavigateOne(target);
            NavigateTwo(target);
        }
        /// <summary>
        /// 第一种导航函数：基本的请求导航。
        /// 例：AAAView
        /// </summary>
        /// <param name="target"></param>
        private void NavigateOne(string target)
        {
            regionManager.RequestNavigate(Constants.MainViewRegionName, target);
        }
        /// <summary>
        /// 第一种导航函数：导航时向目标View发送信息（导航参数）。
        /// 例：BBBView
        /// </summary>
        /// <param name="target"></param>
        private void NavigateTwo(string target)
        {
            NavigationParameters pairs = new()
            {
                { Constants.NavigateParamsKey, "MainViewModel 通过 RequestNavigate() 函数发送消息" }
            };
            regionManager.RequestNavigate(Constants.MainViewRegionName, target, pairs);
        }
    }
}