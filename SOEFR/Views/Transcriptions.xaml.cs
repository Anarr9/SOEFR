using SOEFR.ViewModels;
using SOEFR.Models;
using System; // For the Uri class
using System.Threading.Tasks; // For Task
using Microsoft.Maui.Controls; // For ContentPage, DisplayAlert, etc.

namespace SOEFR.Views
{
    public partial class Transcriptions : ContentPage
    {
        // Commented out the ViewModel for now.
        // private readonly TranscriptionsViewModel _viewModel;

        public Transcriptions()
        {
            InitializeComponent();

            // Commented out ViewModel instantiation and data binding.
            // _viewModel = new TranscriptionsViewModel();
            // BindingContext = _viewModel;

            // Commented out the Appearing event subscription.
            // this.Appearing += async (sender, e) => await InitializeDataAsync();
        }

        // Commented out the initialization method.
        /*
        private async Task InitializeDataAsync()
        {
            await _viewModel.PopulateTranscriptionsHistoryAsync();
        }
        */

        // Commented out the ListView item tapped event handler.
        /*
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is not Transcription transcription || string.IsNullOrEmpty(transcription.AudioLink))
            {
                await DisplayAlert(string.Empty, "This transcription does not have an audio.", "Ok");
                return;
            }

            try
            {
                Uri uri = new Uri(transcription.AudioLink);
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                await DisplayAlert("An unexpected error occurred",
                    "No audio player may be installed on the device",
                    "Ok");
            }
        }
        */
    }
}
