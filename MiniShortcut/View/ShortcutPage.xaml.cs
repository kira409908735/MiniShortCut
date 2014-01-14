using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MiniShortcut.ViewModel;

namespace MiniShortcut.View
{
    public partial class ShortcutPage : PhoneApplicationPage
    {
        public ShortcutPage()
        {
            InitializeComponent();
        }


        private void Button_Click_wifi(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Instance.Shortcut.GoWifi();
        }

        private void Button_Click_cellular(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Instance.Shortcut.GoCellular();
        }

        private void Button_Click_airplanemode(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Instance.Shortcut.GoAirplanemode();
        }

        private void Button_Click_bluetooth(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Instance.Shortcut.GoBluetooth();
        }

        private void Button_Click_screenrotation(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Instance.Shortcut.GoScreenrotation();
        }

        private void Button_Click_location(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Instance.Shortcut.GoLocation();
        }
    }
}