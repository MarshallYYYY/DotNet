using Prism.Navigation.Regions;
using RegionManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionManager.ViewModels
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
            // ① 直接传递字符串
            //regionManager.Regions["ContentRegion"].RequestNavigate(target);

            // ② 使用单独的类和变量来封装明文字符串
            //regionManager.Regions[Constants.MainViewRegionName].RequestNavigate(target);

            // ③ 扩展方法写法
            regionManager.RequestNavigate(Constants.MainViewRegionName, target);
        }
    }
}
