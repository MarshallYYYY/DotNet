# Introduction

2025-11-7 22:53:43：

记录.NET的各方面知识点，以尽可能小的Demo形式进行展示。

# 项目层级

# WPF

## Basic

## MaterialDesign

## Prism

### ==PrismTemplate==

项目适配 Prism 的步骤：

① Visual Studio 中：

工具 --- NuGet 包管理器 --- 管理解决方案的 NuGet 程序包 --- 搜索 `Prism.DryIoc`，并安装。

或者

工具 --- NuGet 包管理器 --- 程序部管理器控制台 --- 输入安装命令：

```bash
Install-Package Prism.DryIoc -Version 9.0.537
```



② 安装成功后，修改下面的两个文件：

第一个文件：`App.xaml`

1. 删除 `StartupUri="MainWindow.xaml"`
2. 修改最外层xaml标签：`prism:PrismApplication`
3. 添加命名空间：`xmlns:prism="http://prismlibrary.com/"`

```xaml
<prism:PrismApplication
    x:Class="PrismTempalte.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="clr-namespace:bili_微软系列技术教程_WPF项目实战合集_6_Prism"
    xmlns:prism="http://prismlibrary.com/">
    <Application.Resources>

    </Application.Resources>
</prism:PrismApplication>
```

第二个文件：`App.xaml.cs`

`App`类实现继承的抽象类成员

```cs
using System.Configuration;
using System.Data;
using System.Windows;

namespace PrismTempalte
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
```



### RegionManager

基本的区域管理和视图导航

`MainView.xaml`

```xaml
<ContentControl
	Grid.Row="1"
	prism:RegionManager.RegionName="{x:Static common:Constants.MainViewRegionName }" />
```

`MainViewModel.cs`

```cs
// 通过构造函数依赖注入
IRegionManager regionManager
// 调用
regionManager.RequestNavigate(Constants.MainViewRegionName, target);
```

`App.xaml.cs`

```cs
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    // 若有 ViewModel
    containerRegistry.RegisterForNavigation<AAAView, AAAViewModel>();
    // 若只有 View
    containerRegistry.RegisterForNavigation<BBBView>();
}
```



### Navigate

1. 基础区域管理和导航
2. 导航时向目标View发送消息
3. 导航拦截

`MainViewModel.cs`

```cs
private void NavigateTwo(string target)
{
    NavigationParameters pairs = new()
    {
        { Constants.NavigateParamsKey, "MainViewModel 通过 RequestNavigate() 函数发送消息" }
    };
    regionManager.RequestNavigate(Constants.MainViewRegionName, target, pairs);
}
```

`BBBViewModel.cs`

`INavigationAware`

```cs
public bool IsNavigationTarget(NavigationContext navigationContext)
public void OnNavigatedTo(NavigationContext navigationContext)
public void OnNavigatedFrom(NavigationContext navigationContext)
```

```cs
// 两种写法
//string value  = navigationContext.Parameters[Constants.NavigateParamsKey]?.ToString();
string value = navigationContext.Parameters.GetValue<string>(Constants.NavigateParamsKey);
```

```cs
// 获取所有参数
foreach (var key in navigationContext.Parameters.Keys)
{
    object? value = navigationContext.Parameters[key];
    msg += $"NavigateParameters Key = {Constants.NavigateParamsKey}\n" +
        $"NavigateParameters Value = {value}";
}
```

`CCCViewModel.cs`

`IConfirmNavigationRequest`

```cs
public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
{
    bool isNavigate =
        MessageBox.Show($"是否导航到 {navigationContext.Uri}？",
        "温馨提示", MessageBoxButton.YesNo) ==
        MessageBoxResult.Yes;
    continuationCallback(isNavigate);
}
```



### NavigateJournal

导航日志

`MainViewModel.cs`

```cs
private IRegionNavigationJournal? journal;

private void Navigate(string target)
{
    // 若有 NavigationParameters 对象需要传递用来发送信息，则将对象放入形参的最后即可。
    regionManager.RequestNavigate(
        Constants.MainViewRegionName, target,
        NavigationCallbackFun);
}

// 当然也可以不用函数，用 Lambda 表达式。
private void NavigationCallbackFun(NavigationResult result)
{
    if (result.Success)
    {
        NavigationContext? context = result.Context;
        journal = context?.NavigationService.Journal;
    }
}

 private void GoBack()
 {
     if (journal is not null && journal.CanGoBack)
         journal.GoBack();
 }
 private void GoForward()
 {
     if (journal is not null && journal.CanGoForward)
         journal.GoForward();
 }
```



### Dialog

对话服务

`MainViewModel.cs`

```cs
private readonly IDialogService dialogService;

dialogService.ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback)
```

`DialogViewModel.cs`

`IDialogAware`

```cs
public DialogCloseListener RequestClose { get; } = new();

public bool CanCloseDialog()
public void OnDialogClosed()
public void OnDialogOpened(IDialogParameters parameters)
{
    string value = parameters.GetValue<string>("XXX");
    // 其他逻辑
}

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
```

`App.xaml.cs`

```cs
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterDialog<DialogView, DialogViewModel>();
}
```



### PubSubEvent

消息的发送、订阅、取消订阅

==没有特殊情况的话，最好只订阅一次！==

`MessageEvent.cs`

```cs
using Prism.Events;

public class MessageEvent : PubSubEvent<string>
{
}
```

`MainViewModel.cs`

```cs
IEventAggregator ea
ea.GetEvent<MessageEvent>().Publish(
    "这是来自 MainViewModel.cs 的 Publish() 函数发送的消息");
```

`SubUnSubViewModel.cs`

```cs
IEventAggregator ea
private readonly MessageEvent _event;

_event = ea.GetEvent<MessageEvent>();

private void SubscribeFun(string msg)
// 订阅的两种方式：
// ①：返回 token
private SubscriptionToken _token;
_token = _event.Subscribe(SubscribeFun);
// ②：也可以不用 token
_event.Subscribe(SubscribeFun);

// 取消订阅的两种方式：
_event.Unsubscribe(_token);
_event.Unsubscribe(SubscribeFun);
```

