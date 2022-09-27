using Assets.Sources.Models;
using uMVVM.Sources.Infrastructure;

namespace Assets.Sources.ViewModels
{
    public class BadgeViewModel : ViewModelBase
    {
        private readonly BindableProperty<string> Icon = new BindableProperty<string>();
        private readonly BindableProperty<string> ElementColor = new BindableProperty<string>();

        public void Initialization(Badge badge)
        {
            Icon.Value = badge.Icon;
            ElementColor.Value = badge.ElementColor;
        }
    }
}
