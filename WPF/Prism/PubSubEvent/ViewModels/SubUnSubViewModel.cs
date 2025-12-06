using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PubSubEvent.Event;

namespace PubSubEvent.ViewModels
{
    public class SubUnSubViewModel : BindableBase
    {
        public SubUnSubViewModel(IEventAggregator ea)
        {
            _event = ea.GetEvent<MessageEvent>();
            SubCommand = new DelegateCommand(Sub);
            UnsubCommand = new DelegateCommand(Unsub);
        }

        #region 所需的相关变量
        private readonly MessageEvent _event;
        private SubscriptionToken _token;
        #endregion

        #region 数据
        private string content = "这是内容区域";
        public string Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }
        private int subCount = 0;
        public int SubCount
        {
            get { return subCount; }
            set { SetProperty(ref subCount, value); }
        }
        public DelegateCommand SubCommand { get; private set; }
        public DelegateCommand UnsubCommand { get; private set; }
        #endregion

        private void Sub()
        {
            Content = "开始订阅\n";
            SubCount += 1;
            // 当订阅按钮被多次点击时，可以订阅多个消息，即使只有一个 _token 或者直接没有 _token。
            _token = _event.Subscribe(SubscribeFun);
        }
        private void Unsub()
        {
            Content = "取消订阅\n";
            SubCount -= 1;
            // 下面两种方式都是只能取消一个订阅，
            // 如果多次订阅，需要取消订阅时，需要多次点击取消订阅按钮。
            //_event.Unsubscribe(SubscribeFun);
            _event.Unsubscribe(_token);
        }
        private void SubscribeFun(string msg)
        {
            Content += msg + "\n";
        }
    }
}