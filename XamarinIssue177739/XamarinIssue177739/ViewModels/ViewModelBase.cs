using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinIssue177739.Misc;

namespace XamarinIssue177739.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        public ViewModelBase(Page page)
        {
            _navigation = page.Navigation;
            _displayAlertAction = (title, message) => page.DisplayAlert(title, message, "OK");
            _displayAlertWithResponseFunc = (title, cancel, buttons) => page.DisplayActionSheet(title, cancel, null, buttons);
        }

        protected readonly INavigation _navigation;

        private readonly Action<string, string> _displayAlertAction;
        private readonly Func<string, string, string[], Task<string>> _displayAlertWithResponseFunc;

        bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
    }
}
