using Dialog.Common;
using Prism.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Dialog.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public DelegateCommand<string> OpenCommand { get; private set; }
        private readonly IDialogService dialogService;
        public MainViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            OpenCommand = new DelegateCommand<string>(Open);
        }
        private readonly string infoHead = "MainViewModel.cs\n";
        private void Open(string viewName)
        {
            DialogParameters parameters = new()
            {
                { Constants.DialogParametersKeyTwo,
                    "MainViewModel.cs 通过 Open() 函数中的 dialogService.ShowDialog() 函数发送消息"  },
            };
            // ①
            dialogService.ShowDialog(viewName, parameters, callback =>
            {
                // ⑤
                MessageBox.Show($"{infoHead}" +
                    $"Open() → dialogService.ShowDialog()\n" +
                    $"{viewName} 的返回值：{callback.Result}");
                if (callback.Result == ButtonResult.OK)
                {
                    // ⑥
                    string value = callback.Parameters.GetValue<string>(Constants.DialogParametersKeyOne);
                    MessageBox.Show($"{infoHead}" +
                        $"Open() → dialogService.ShowDialog() → callback.Result == ButtonResult.OK\n" +
                        $"{value}");
                }
            });
        }
    }
}