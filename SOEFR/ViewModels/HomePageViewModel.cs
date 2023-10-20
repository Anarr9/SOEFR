using System;
using Newtonsoft.Json;
using SOEFR.Helpers;
using SOEFR.Models;

namespace SOEFR.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{
		public Root NextLaunch
		{
			get => _nextLaunch;
			set => SetProperty(ref _nextLaunch, value);
		}

		public Root LatestLaunch
		{
			get => _latestLaunch;
			set => SetProperty(ref _latestLaunch, value);
		}

		public Roadster RoadsterInfo
		{
			get => _roadsterInfo;
			set => SetProperty(ref _roadsterInfo, value);
		}

        private readonly HttpClient _client;
		private Root _nextLaunch;
		private Root _latestLaunch;
		private Roadster _roadsterInfo;

		public HomePageViewModel()
		{
			_client = new HttpClient();
		}

    }
}

