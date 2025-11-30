namespace DialogHostDemo.ViewModels
{
    public class OneViewModel:BindableBase
    {
        private bool isDialogHostOpen;
        public bool IsDialogHostOpen
        {
            get { return isDialogHostOpen; }
            set { SetProperty(ref isDialogHostOpen, value); }
        }
        public DelegateCommand ShowDialogHostCommand => new DelegateCommand(ShowDialogHost);

        private void ShowDialogHost()
        {
            IsDialogHostOpen = true;
        }
    }
}