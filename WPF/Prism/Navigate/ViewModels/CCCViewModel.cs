using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Navigate.ViewModels
{
    public class CCCViewModel : BindableBase, IConfirmNavigationRequest
    {
        private string? info;
        public string? Info
        {
            get { return info; }
            set { SetProperty(ref info, value); }
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool isNavigate =
                MessageBox.Show($"是否导航到 {navigationContext.Uri}？",
                "温馨提示", MessageBoxButton.YesNo) ==
                MessageBoxResult.Yes;
            continuationCallback(isNavigate);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}