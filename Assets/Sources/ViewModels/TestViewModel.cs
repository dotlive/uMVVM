using Assets.Sources.Core.Message;
using Assets.Sources.Infrastructure;
using uMVVM.Sources.Infrastructure;

namespace Assets.Sources.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        private readonly BindableProperty<string> Color = new BindableProperty<string>();

        public TestViewModel()
        {
            MessageAggregator<object>.Instance.Subscribe("Toggle", ToggleHandler);
        }

        private void ToggleHandler(object sender, MessageArgs<object> args)
        {
            Color.Value = (string) args.Item;
        }
    }
}
