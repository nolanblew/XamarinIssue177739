using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinIssue177739.Misc;

namespace XamarinIssue177739.ViewModels
{
    public class BugPageViewModel : ViewModelBase
    {
        public BugPageViewModel(Page page) : base(page)
        {
            LaunchExternalAppCommand = new DelegateCommand(_LaunchExternalApp);
            CloseDialogCommand = new DelegateCommand(_CloseDialog);
            _SelectNewPhoto();
        }

        public DelegateCommand LaunchExternalAppCommand { get; }
        public DelegateCommand CloseDialogCommand { get; }

        private Random _random = new Random();
        private string[] _photoUrls = new[]
        {
            "https://upload.wikimedia.org/wikipedia/commons/4/4f/Matterhorn_Riffelsee_2005-06-11.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/Klamath_river_California.jpg/1200px-Klamath_river_California.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/MSH80_st_helens_eruption_plume_07-22-80.jpg/1200px-MSH80_st_helens_eruption_plume_07-22-80.jpg",
            "https://www.3wallpapers.fr/wp-content/uploads/2015/02/Plane-airport-iPhone-Parallax-3Wallpapers.jpg",
            "https://doninmass.files.wordpress.com/2012/12/sc2ot.jpg",
            "https://c1.staticflickr.com/9/8205/8253563259_d7946cddd6_b.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Jaz_beach_11.jpg/120px-Jaz_beach_11.jpg",
            "http://www.marksowers.com/verticalwallpaper/images/beachboatsm.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/EA-6B_Prowler_from_VAQ-138.jpg/86px-EA-6B_Prowler_from_VAQ-138.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e4/Changbai_chute1.JPG/146px-Changbai_chute1.JPG",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Gunsight_Mountain_Sunset_%2823690152761%29.jpg/270px-Gunsight_Mountain_Sunset_%2823690152761%29.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/3/37/Shoalhaven_River_-_near_the_Great_Dividing_Range%2C_west_of_Batemans_Bay.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/Hans_Baluschek_-_Arbeiterstadt_%281920%29.jpg/330px-Hans_Baluschek_-_Arbeiterstadt_%281920%29.jpg",
        };

        bool _isDialogVisible;

        public bool IsDialogVisible
        {
            get => _isDialogVisible;
            set => SetProperty(ref _isDialogVisible, value);
        }

        int _openCount;

        public int OpenCount
        {
            get => _openCount;
            set => SetProperty(ref _openCount, value);
        }

        string _photoUrl;

        public string PhotoUrl
        {
            get => _photoUrl;
            set => SetProperty(ref _photoUrl, value);
        }

        void _LaunchExternalApp()
        {
            Launcher.OpenAsync("http://www.xamarin.com/");
            OpenCount++;
            IsDialogVisible = true;
        }

        void _CloseDialog()
        {
            IsDialogVisible = false;
            _SelectNewPhoto();
        }

        void _SelectNewPhoto()
        {
            var nextPhoto = string.Empty;
            do
            {
                nextPhoto = _photoUrls[_random.Next(0, _photoUrls.Length)];
            }
            while (nextPhoto == PhotoUrl);

            PhotoUrl = nextPhoto;
        }
    }
}
