using MaterialDesignMessageBox.Services;
using System.Windows;

namespace MaterialDesignMessageBox.ViewModels
{
    public class TwoViewModel : BindableBase
    {
        private readonly IMessageBoxService messageBoxService;

        public TwoViewModel(IMessageBoxService messageBoxService)
        {
            this.messageBoxService = messageBoxService;
            OpenMdMessageBoxCommand = new DelegateCommand(OpenMdMessageBox);
        }
        public DelegateCommand OpenMdMessageBoxCommand { get; }
        private async void OpenMdMessageBox()
        {
            // 注意：因为 TwoView.xaml 中没有DialogHost，所以会显示在 MainView.xaml 中。
            ButtonResult result = await messageBoxService.ShowAsync("AAA", "BBB");
            MessageBox.Show(result.ToString());
        }
    }
}