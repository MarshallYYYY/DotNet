namespace MaterialDesignMessageBox.Services
{
    public interface IMessageBoxService
    {
       Task<ButtonResult> ShowAsync(string title, string message);
    }
}