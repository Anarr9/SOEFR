using System;
using Newtonsoft.Json;
using SOEFR.Helpers;
using SOEFR.Models;

namespace SOEFR.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{

        private string _connectionStatus = "Testing Connection Status";
        public string ConnectionStatus
        {
            get => _connectionStatus;
            set => SetProperty(ref _connectionStatus, value);
        }

        // ... existing code ...

        public void UpdateConnectionStatus(string status)
        {
            ConnectionStatus = status;
        }
    }

}


