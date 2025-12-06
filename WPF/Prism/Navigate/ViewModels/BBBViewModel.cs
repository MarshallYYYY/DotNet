using Navigate.Common;
using System.Windows;

namespace Navigate.ViewModels
{
    public class BBBViewModel : BindableBase, INavigationAware
    {
        private string? info;
        public string? Info
        {
            get { return info; }
            set { SetProperty(ref info, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext is null)
                return;
            if (navigationContext.Parameters is null)
                return;
            if (navigationContext.Parameters.ContainsKey(Constants.NavigateParamsKey))
            {
                // 两种写法
                //string value  = navigationContext.Parameters[Constants.NavigateParamsKey]?.ToString();
                string value = navigationContext.Parameters.GetValue<string>(Constants.NavigateParamsKey);
                Info =
                    $"以下信息均由 BBBViewModel.cs - INavigationAware 接口 - OnNavigatedTo() 函数 显示：\n" +
                    $"NavigateParameters Key = {Constants.NavigateParamsKey}\n" +
                    $"NavigateParameters Value = {value}";
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        // Q: 当处于 BBBView 时，点击 MainView 中的 <Navigate BBBView> 按钮也会触发该函数；
        // 这个 navigationContext 跟 OnNavigatedTo() 中的是一样的；
        // 该函数不能阻止页面跳转。
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            string msg =
                "以下信息均由 OnNavigatedFrom() 函数 显示：\n" +
                "即将离开 BBBView\n";
            // 获取目标视图的Uri
            Uri targetUri = navigationContext.Uri;
            msg += $"导航到: {targetUri}\n";

            // 获取目标视图名称
            string viewName = navigationContext.Uri.ToString();
            msg += $"目标视图: {viewName}\n";

            // 获取所有参数
            foreach (var key in navigationContext.Parameters.Keys)
            {
                object? value = navigationContext.Parameters[key];
                msg += $"NavigateParameters Key = {Constants.NavigateParamsKey}\n" +
                    $"NavigateParameters Value = {value}";
            }
            MessageBox.Show(msg);
        }
    }
}