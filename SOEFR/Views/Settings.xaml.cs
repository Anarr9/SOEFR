using Microsoft.Maui.Controls;
using SOEFR.ViewModels;

namespace SOEFR.Views
{
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
        }
    }
}
