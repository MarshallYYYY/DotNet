using DialogHostDemo.Models;
using MaterialDesignThemes.Wpf;
using System.Windows;

namespace DialogHostDemo.ViewModels
{
    public class TwoViewModel : BindableBase
    {
        public DelegateCommand ShowDialogHostCommand => new DelegateCommand(ShowDialogHost);

        private async void ShowDialogHost()
        {
            Person person = new Person
            {
                Name = "测试",
                Age = 12,
            };
            // 第二个参数 object dialogIdentifier 的写与不写，
            // 要跟 TwoView.xaml 中 DialogHost 的 Identifier 属性同步，并保持一致。
            //await DialogHost.Show(person);
            await DialogHost.Show(person, "Two");
        }
    }
}