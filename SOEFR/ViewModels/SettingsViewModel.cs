using Shiny.BluetoothLE;
using Shiny;
using Shiny.Hosting;
using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SOEFR.ViewModels
{
    public class SettingsViewModel : BindableObject
    {
        private IBleManager _bleManager;
        private string _statusMessage;

        public SettingsViewModel()
        {
            _bleManager = ShinyHost.Resolve<IBleManager>();
            ScanCommand = new Command(ScanForDevices);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ScanCommand { get; }

        private async void ScanForDevices()
        {
            if (_bleManager.Status == AccessState.Available)
            {
                StatusMessage = "Scanning for ESP32 devices...";

                var scanner = _bleManager.Scan().Subscribe(scanResult =>
                {
                    // Device found logic
                    if (scanResult.Device.Name == "ESP32")
                    {
                        scanner.Dispose(); // Stop scanning
                        StatusMessage = "ESP32 device found, connecting...";
                        ConnectToDevice(scanResult.Device);
                    }
                });
            }
            else
            {
                StatusMessage = "Bluetooth not available.";
            }
        }

        private async void ConnectToDevice(IPeripheral peripheral)
        {
            try
            {
                await peripheral.ConnectAsync();
                StatusMessage = "Connected to ESP32.";

                var services = await peripheral.GetServicesAsync();
                var targetService = services.FirstOrDefault(s => s.Uuid == Guid.Parse("8e27f831-c8e2-4c0b-96e2-8e4ebc451a9b"));

                if (targetService != null)
                {
                    var characteristics = await targetService.GetCharacteristicsAsync();
                    var targetCharacteristic = characteristics.FirstOrDefault(c => c.Uuid == Guid.Parse("9172d2e8-a023-4e0f-a7c4-0978a7b084fe"));

                    if (targetCharacteristic != null)
                    {
                        // Subscribe to characteristic
                        targetCharacteristic.WhenNotificationReceived().Subscribe(result =>
                        {
                            // Handle the notification data
                            var data = result.Data;
                            StatusMessage = "Data received from ESP32.";
                            // You could also update another property that the UI can bind to, to display the data
                        });

                        // Enable notifications
                        await targetCharacteristic.EnableNotifications(true);
                    }
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error connecting to device: {ex.Message}";
            }
        }

        // Implement OnPropertyChanged if not already present in the class
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }
    }
}
