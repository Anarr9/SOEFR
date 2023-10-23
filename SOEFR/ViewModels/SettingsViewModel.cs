using System;
using SOEFR.Models;
using SOEFR.Helpers;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Windows.Input;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace SOEFR.ViewModels
{
    public class SettingsViewModel
    {
        public ObservableCollection<SettingItem> Settings { get; set; }

        private IAdapter Adapter => CrossBluetoothLE.Current.Adapter;
        private IDevice Device;

        public SettingsViewModel()
        {
            Settings = new ObservableCollection<SettingItem>
            {
                new SettingItem { Title = "Connect", Color = "#4CAF50", BorderColor = "#388E3C", Command = new Command(OnConnect) },
                new SettingItem { Title = "Disconnect", Color = "#F44336", BorderColor = "#D32F2F", Command = new Command(OnDisconnect) }
            };
        }

        private async void OnConnect()
        {
            var ble = CrossBluetoothLE.Current;
            Adapter.DeviceDiscovered += (s, a) =>
            {
                if (a.Device.Name == "Your_ESP32_Device_Name")
                {
                    Device = a.Device;
                    Adapter.StopScanningForDevicesAsync();
                }
            };
            await Adapter.StartScanningForDevicesAsync();

            if (Device != null)
            {
                await Adapter.ConnectToDeviceAsync(Device);
            }
        }

        private async void OnDisconnect()
        {
            if (Device != null)
            {
                await Adapter.DisconnectDeviceAsync(Device);
                Device = null;
            }
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