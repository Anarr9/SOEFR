using Shiny.BluetoothLE;
using Shiny;
using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Reactive.Linq;

namespace SOEFR.ViewModels
{   
    public class SettingsViewModel : BindableObject
    {
        private IBleManager _bleManager;
        private string _statusMessage;

        /*
        public SettingsViewModel()
        {
            // Assuming that Shiny provides a dependency injection container that can resolve services.
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
            // Assuming GetStatusAsync() is an async method that returns the status of the BLE manager.
            var status = await _bleManager.RequestAccess();
            if (status == AccessState.Available)
            {
                StatusMessage = "Scanning for ESP32 devices...";

                IDisposable scanner = null;
                scanner = _bleManager.Scan().Subscribe(scanResult =>
                {
                    // Assuming the ScanResult provides a Peripheral property that contains the BLE device.
                    if (scanResult.Peripheral.Name == "ESP32")
                    {
                        scanner?.Dispose(); // Stop scanning safely by checking if scanner is not null
                        StatusMessage = "ESP32 device found, connecting...";
                        ConnectToDevice(scanResult.Peripheral);
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
                // Assuming services are identified by a string representation of their GUID.
                var targetService = services.FirstOrDefault(s => s.Uuid.ToString().Equals("8e27f831-c8e2-4c0b-96e2-8e4ebc451a9b", StringComparison.OrdinalIgnoreCase));

                if (targetService != null)
                {
                    var characteristics = await peripheral.GetCharacteristicsAsync(serviceUuid);
                    var targetCharacteristic = characteristics.FirstOrDefault(c => c.Uuid.ToString().Equals("9172d2e8-a023-4e0f-a7c4-0978a7b084fe", StringComparison.OrdinalIgnoreCase));

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
        */

        // Implement OnPropertyChanged if not already present in the class
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName); 
        }
    }
}
