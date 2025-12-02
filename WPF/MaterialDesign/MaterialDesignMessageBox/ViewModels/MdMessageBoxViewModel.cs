using MaterialDesignMessageBox.Common;
using MaterialDesignThemes.Wpf;

namespace MaterialDesignMessageBox.ViewModels
{
    public class MdMessageBoxViewModel : BindableBase
    {
        public MdMessageBoxViewModel()
        {
            OkCommand = new DelegateCommand(OkFun);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        private string message = string.Empty;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public DelegateCommand OkCommand { get; }
        public DelegateCommand CancelCommand { get; }

        private void OkFun()
        {
            DialogHost.Close(AppConstants.DialogHostMdMessageBox, ButtonResult.OK);

        }
        private void Cancel()
        {
            DialogHost.Close(AppConstants.DialogHostMdMessageBox, ButtonResult.Cancel);
        }
    }
}