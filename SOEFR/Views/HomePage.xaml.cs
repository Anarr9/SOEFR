using System;
using System.IO;
using Plugin.Maui.Audio;
using Microsoft.Maui.Controls;


namespace SOEFR.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly IAudioManager _audioManager;
        private readonly IAudioRecorder _audioRecorder;
        private IAudioPlayer _audioPlayer;
        private string _lastRecordedFilePath;

        public HomePage()
        {
            InitializeComponent();
            _audioManager = AudioManager.Current;
            _audioRecorder = _audioManager.CreateRecorder();
        }

        private async void OnRecordButtonClicked(object sender, EventArgs e)
        {
            if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission Required", "Microphone permission is required to record audio.", "OK");
                return;
            }

            if (!_audioRecorder.IsRecording)
            {
                RecordButton.BackgroundColor = Color.FromHex("#cd5c5c");
                ((FontImageSource)RecordButton.ImageSource).Glyph = "\uf28d"; 
                await _audioRecorder.StartAsync();
            }
            else
            {
                RecordButton.BackgroundColor = Color.FromHex("#34568B");
                ((FontImageSource)RecordButton.ImageSource).Glyph = "\uf04b"; // Record icon glyph, replace as needed
                var recordedAudio = await _audioRecorder.StopAsync();

                // Generate a unique file name
                var fileName = $"recording_{DateTime.Now:yyyyMMddHHmmss}.wav";
                _lastRecordedFilePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                // Save the recorded audio to a file
                using (var fileStream = new FileStream(_lastRecordedFilePath, FileMode.Create, FileAccess.Write))
                {
                    await recordedAudio.GetAudioStream().CopyToAsync(fileStream);
                }

                // Assuming you have a method to get a stream from the saved file
                using (var audioStream = new FileStream(_lastRecordedFilePath, FileMode.Open, FileAccess.Read))
                {
                    _audioPlayer = _audioManager.CreatePlayer(audioStream);
                }
            }
        }

        private void OnPlayButtonClicked(object sender, EventArgs e)
        {
            _audioPlayer?.Play();
        }
    }
}
