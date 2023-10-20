using System;
using SOEFR.Models;
using SOEFR.Helpers;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace SOEFR.ViewModels
{
    public class PastLaunchesViewModel : BaseViewModel
    {
        public ObservableCollection<Root> LatestLaunchs { get; set; }

        private readonly HttpClient _client;

        public PastLaunchesViewModel()
        {
            _client = new HttpClient();
            LatestLaunchs = new ObservableCollection<Root>();
        }




    }
}
