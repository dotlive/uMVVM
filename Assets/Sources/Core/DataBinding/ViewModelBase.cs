using System.Collections.Generic;

namespace uMVVM.Sources.Infrastructure
{
    public class ViewModelBase
    {
        private bool _isInitialized;

        public ViewModelBase ParentViewModel { get; set; }
        public bool IsRevealed { get; private set; }
        public bool IsRevealInProgress { get; private set; }
        public bool IsHideInProgress { get; private set ; }

        protected virtual void OnInitialize()
        {
        }

        public virtual void OnStartReveal()
        {
            IsRevealInProgress = true;
            // 在开始显示的时候进行初始化操作
            if (!_isInitialized)
            {
                OnInitialize();
                _isInitialized = true;
            }
        }

        public virtual void OnFinishReveal()
        {
            IsRevealInProgress = false;
            IsRevealed = true;
        }

        public virtual void OnStartHide()
        {
            IsHideInProgress = true;
        }

        public virtual void OnFinishHide()
        {
            IsHideInProgress = false;
            IsRevealed = false;
        }

        public virtual void OnDestroy()
        {
        }

        public IEnumerable<T> Ancestors<T>() where T : ViewModelBase
        {
            var parentViewModel = ParentViewModel;
            while (parentViewModel != null)
            {
                if (parentViewModel is T castedViewModel)
                {
                    yield return castedViewModel;
                }
                parentViewModel = parentViewModel.ParentViewModel;
            }
        }
    }
}
