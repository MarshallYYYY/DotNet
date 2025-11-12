using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PubSubEvent.Event;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PubSubEvent.ViewModels
{
    public class SubUnSubViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        public SubUnSubViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            InitCommand();
        }
        private void InitCommand()
        {
            SubCommand = new DelegateCommand(() =>
            {
                Content = "开始订阅\n";
                eventAggregator.GetEvent<MessageEvent>().Subscribe(SubscribeFun);
            });
            UnsubCommand = new DelegateCommand(() =>
            {
                Content = "取消订阅";
                eventAggregator.GetEvent<MessageEvent>().Unsubscribe(SubscribeFun);
            });
        }
        private string content = "这是内容区域";
        public string Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }
        private void SubscribeFun(string msg)
        {
            Content += msg + "\n";
        }
        public DelegateCommand SubCommand { get; private set; }
        public DelegateCommand UnsubCommand { get; private set; }
    }
}
