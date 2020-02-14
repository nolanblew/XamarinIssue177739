using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinIssue177739.ViewModels;

namespace XamarinIssue177739.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BugPage : ContentPage
    {
        public BugPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            _ViewModel = new BugPageViewModel(this);
            this.BindingContext = _ViewModel;
            InitializeComponent();
        }

        private BugPageViewModel _ViewModel { get; }
    }
}