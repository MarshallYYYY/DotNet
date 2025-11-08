using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dialog.Common;

namespace Dialog.ViewModels
{
    public class DialogViewModel : IDialogAware
    {
        public DelegateCommand OKCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DialogViewModel()
        {
            OKCommand = new DelegateCommand(() =>
            {
                DialogParameters parameters = new()
                {
                    { Constants.DialogParametersKeyOne ,
                        "DialogViewModel.cs 通过 RequestClose.Invoke() 函数发送消息" },
                };
                DialogResult? dialogResult = new(ButtonResult.OK)
                {
                    Parameters = parameters
                };
                RequestClose.Invoke(dialogResult);
            });

            CancelCommand = new DelegateCommand(() =>
            {
                RequestClose.Invoke(new DialogResult(ButtonResult.Cancel));
            });
        }

        #region IDialogAware

        /* 完整属性语法
         * 在构造函数中初始化（只初始化一次）
         * 对于 DialogCloseListener，强烈推荐使用 */
        public DialogCloseListener RequestClose { get; } = new();
        /* 表达式体属性语法（C# 6.0+）
         * 每次访问时创建新实例 */
        //public DialogCloseListener RequestClose => new();
        private readonly string infoHead = "DialogViewModel.cs\n";
        public bool CanCloseDialog()
        {
            // ③
            MessageBox.Show(infoHead + "CanCloseDialog()");
            return true;
        }

        public void OnDialogClosed()
        {
            // ④
            MessageBox.Show(infoHead + "OnDialogClosed()");
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            // ②
            string value = parameters.GetValue<string>(Constants.DialogParametersKeyTwo);
            MessageBox.Show(infoHead + "OnDialogOpened()\n" + value);
        }
        #endregion
    }
}
