using MaterialDesignMessageBox.Services;
using System.Windows;

namespace MaterialDesignMessageBox.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IMessageBoxService messageBoxService;

        public MainViewModel(IMessageBoxService messageBoxService)
        {
            this.messageBoxService = messageBoxService;
            OpenMdMessageBoxCommand = new DelegateCommand(OpenMdMessageBox);
            SetIsOpenCommand = new DelegateCommand(SetIsOpen);
        }

        public DelegateCommand OpenMdMessageBoxCommand { get; }
        public DelegateCommand SetIsOpenCommand { get; }
        private async void OpenMdMessageBox()
        {
            ButtonResult result = await messageBoxService.ShowAsync("标题：测试", "内容：写点什么呢？");
            string msg = string.Empty;
            switch (result)
            {
                case ButtonResult.Abort:
                    break;
                case ButtonResult.Cancel:
                    msg = "点击了取消按钮";
                    break;
                case ButtonResult.Ignore:
                    break;
                case ButtonResult.No:
                    break;
                case ButtonResult.None:
                    break;
                case ButtonResult.OK:
                    msg = "点击了确定按钮";
                    break;
                case ButtonResult.Retry:
                    break;
                case ButtonResult.Yes:
                    break;
                default:
                    break;
            }
            msg += "\n" + result.ToString();
            MessageBox.Show(msg);
        }
        private bool isOpen = false;
        public bool IsOpen
        {
            get { return isOpen; }
            set { SetProperty(ref isOpen, value); }
        }
        private void SetIsOpen()
        {
            IsOpen = true;
        }
    }
}