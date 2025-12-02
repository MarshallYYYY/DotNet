using MaterialDesignMessageBox.Common;
using MaterialDesignMessageBox.ViewModels;
using MaterialDesignMessageBox.Views;
using MaterialDesignThemes.Wpf;

namespace MaterialDesignMessageBox.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public async Task<ButtonResult> ShowAsync(string title, string message)
        {
            MdMessageBoxViewModel vm = new()
            {
                Title = title,
                Message = message
            };
            // 不会违反 MVVM，在 WPF/Prism/MVVM 架构里，这种由 Service 层创建 View + ViewModel 并注入的方式非常常见。
            // Service 层属于 UI 层的一部分，本来就允许直接创建 View。
            // 只要 View 与 ViewModel 之间没有相互依赖，就是合格的 MVVM。
            MdMessageBoxView view = new()
            {
                DataContext = vm
            };
            // DialogHost.Show() 的返回值 = 调用 DialogHost.Close() 时传入的对象
            object? result = await DialogHost.Show(view, AppConstants.DialogHostMdMessageBox);
            
            #region 当返回值类型为 IDialogResult
            // 下面的写法依然会在(IDialogResult)result 处提示“可能为 null”
            // 这是因为 C# 的空合并运算符 ?? 对类型转换前的表达式不做“消除 null” 推断。
            //return (IDialogResult)result ?? new DialogResult(ButtonResult.None);

            // 正确写法一：
            //if (result is null)
            //{
            //    return new DialogResult(ButtonResult.None);
            //}
            //return (IDialogResult)result;

            // 正确写法二：
            //return result is IDialogResult dialogResult
            //    ? dialogResult
            //    : new DialogResult(ButtonResult.None); 
            #endregion

            // 全新版本：返回值类型修改为 ButtonResult
            if (result is null)
            {
                return ButtonResult.None;
            }
            return (ButtonResult)result;
        }
    }
}