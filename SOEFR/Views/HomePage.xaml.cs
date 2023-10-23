using SOEFR.ViewModels;
using Microsoft.Maui.Controls;

namespace SOEFR.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly HomePageViewModel _viewModel;

        public HomePage()
        {
            InitializeComponent();

            _viewModel = new HomePageViewModel();
            BindingContext = _viewModel;

            App.WebSocketClient.ConnectionStatusChanged += OnConnectionStatusChanged;
        }

        private void OnConnectionStatusChanged(string status)
        {
            _viewModel.UpdateConnectionStatus(status);
        }
    }
}
