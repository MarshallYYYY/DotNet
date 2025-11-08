using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PubSubEvent.Event;
using PubSubEvent.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PubSubEvent.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        public MainViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            PubCommand = new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<MessageEvent>().Publish(
                    "来自 MainViewModel.cs 通过 Publish() 函数发送的消息");
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