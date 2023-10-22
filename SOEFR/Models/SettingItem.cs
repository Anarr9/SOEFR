using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SOEFR.Models
{
    public class SettingItem
    {
        public string Title { get; set; }  // The text displayed on the button.
        public string Color { get; set; }  // The background color of the button.
        public string BorderColor { get; set; }  // The border color of the button.
        public ICommand Command { get; set; }  // The command executed when the button is tapped.
    }

}