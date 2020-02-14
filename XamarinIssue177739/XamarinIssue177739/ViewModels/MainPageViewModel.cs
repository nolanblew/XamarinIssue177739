using System.Windows.Input;
using Xamarin.Forms;
using XamarinIssue177739.Misc;
using XamarinIssue177739.Pages;

namespace XamarinIssue177739.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(Page page) : base(page)
        {
            NextButtonCommand = new DelegateCommand(_NextPage);
        }

        public ICommand NextButtonCommand { get; }

        private void _NextPage()
        {
            _navigation.PushAsync(new BugPage());
        }
    }
}
