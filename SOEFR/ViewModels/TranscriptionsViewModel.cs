using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SOEFR.Models;
using SOEFR.Helpers;

namespace SOEFR.ViewModels
{
    public class TranscriptionsViewModel : BaseViewModel
    {
        public ObservableCollection<Transcription> TranscriptionsHistory { get; set; }

        private readonly HttpClient _client;

        public TranscriptionsViewModel()
        {
            _client = new HttpClient();
            TranscriptionsHistory = new ObservableCollection<Transcription>();
        }

        public async Task PopulateTranscriptionsHistoryAsync()
        {
            var transcriptions = await RetrieveAllTranscriptionsAsync();
            foreach (Transcription transcription in transcriptions)
            {
                TranscriptionsHistory.Add(transcription);
            }
        }

        private async Task<ObservableCollection<Transcription>> RetrieveAllTranscriptionsAsync()
        {
            // TODO: Update the URL to point to your transcriptions endpoint
            var transcriptionsSerialized = await _client.GetStringAsync(Constants.BaseUrl + "transcriptions");

            var transcriptionsDeserialized = JsonConvert.DeserializeObject<List<Transcription>>(transcriptionsSerialized);

            return new ObservableCollection<Transcription>(transcriptionsDeserialized);
        }
    }
}
