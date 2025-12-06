using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PubSubEvent.Event;
using PubSubEvent.Views;

namespace PubSubEvent.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel(IEventAggregator ea)
        {
            PubCommand = new DelegateCommand(() =>
            {
                ea.GetEvent<MessageEvent>().Publish(
                    "这是来自 MainViewModel.cs 的 Publish() 函数发送的消息");
            });
            OpenCommand = new DelegateCommand(() =>
            {
                SubUnSubView view = new();
                view.Show();
            });
        }
        public DelegateCommand PubCommand { get; private set; }
        public DelegateCommand OpenCommand { get; private set; }
    }
}