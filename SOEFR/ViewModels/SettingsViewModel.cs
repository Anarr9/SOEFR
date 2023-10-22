using System;
using SOEFR.Models;
using SOEFR.Helpers;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Windows.Input;

namespace SOEFR.ViewModels
{
    public class SettingsViewModel
    {
        public ObservableCollection<SettingItem> Settings { get; set; }

        public SettingsViewModel()
        {
            Settings = new ObservableCollection<SettingItem>
            {
                new SettingItem { Title = "Connect", Color = "#4CAF50", BorderColor = "#388E3C", Command = new Command(OnConnect) },
                new SettingItem { Title = "Disconnect", Color = "#F44336", BorderColor = "#D32F2F", Command = new Command(OnDisconnect) }
            };
        }

        private void OnConnect()
        {
            // Connect logic
        }

        private void OnDisconnect()
        {
            // Disconnect logic
        }
    }

    public class SettingItem
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public string BorderColor { get; set; }
        public ICommand Command { get; set; }
    }
}