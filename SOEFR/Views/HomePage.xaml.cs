using SOEFR.ViewModels;
using Microsoft.Maui.Controls;

namespace SOEFR.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly HomePageViewModel _viewModel;

        public HomePage()
        {
            InitializeComponent();

            _viewModel = new HomePageViewModel();
            BindingContext = _viewModel;
        }

        // You can uncomment and expand on these event handlers when you're ready to add functionality.
        //private void NextLaunchWebcastTap(object sender, TappedEventArgs e) { /*...*/ }
        //private void LatestLaunchWebcastTap(object sender, TappedEventArgs e) { /*...*/ }
        //private void RoadsterWebcastTap(object sender, TappedEventArgs e) { /*...*/ }
        //private void RoadsterWikiTap(object sender, TappedEventArgs e) { /*...*/ }
        //private async void OpenUrl(string link) { /*...*/ }
    }
}
