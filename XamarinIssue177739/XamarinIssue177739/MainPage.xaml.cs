using System.ComponentModel;
using Xamarin.Forms;
using XamarinIssue177739.ViewModels;

namespace XamarinIssue177739
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            _ViewModel = new MainPageViewModel(this);
            this.BindingContext = _ViewModel;
            InitializeComponent();
        }

        private MainPageViewModel _ViewModel { get; }
    }
}
