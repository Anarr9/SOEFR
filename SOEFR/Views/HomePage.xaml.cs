using System;
using Plugin.Maui.Audio;
using Microsoft.Maui.Controls;

namespace SOEFR.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly IAudioManager _audioManager;
        private readonly IAudioRecorder _audioRecorder;
        private IAudioPlayer _audioPlayer;

        public HomePage()
        {
            InitializeComponent();

            // Make sure to register IAudioManager via dependency injection
            _audioManager = AudioManager.Current;
            _audioRecorder = _audioManager.CreateRecorder();
        }

        private async void OnRecordButtonClicked(object sender, EventArgs e)
        {
            if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
            {
                // Inform your user that the microphone permission is required.
                await DisplayAlert("Permission Required", "Microphone permission is required to record audio.", "OK");
                return;
            }

            if (!_audioRecorder.IsRecording)
            {
                // Update UI to reflect recording state if necessary, e.g., change button text
                RecordButton.Text = "Stop";
                await _audioRecorder.StartAsync();
            }
            else
            {
                // Update UI to reflect not recording state if necessary, e.g., change button text
                RecordButton.Text = "Record";
                var recordedAudio = await _audioRecorder.StopAsync();

                // Keep a reference to the player if you need to control playback later
                _audioPlayer = _audioManager.CreatePlayer(recordedAudio.GetAudioStream());
            }
        }

        private void OnPlayButtonClicked(object sender, EventArgs e)
        {
            _audioPlayer?.Play();
        }
    }
}
