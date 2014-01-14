using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Info;
using Microsoft.Phone.Net.NetworkInformation;
using MiniShortcut.DataBase.Service;
using MiniShortcut.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Windows.Networking.Proximity;

namespace MiniShortcut.ViewModel
{
    public class ShortcutVM : ViewModelBase
    {
        DBService dbservice = DBService.Instance;

        private ObservableCollection<ItemModel> mItems;

        public ObservableCollection<ItemModel> Items
        {
            get { return mItems ?? (mItems = new ObservableCollection<ItemModel>()); }

        }


        private string mItemName;

        public string MyProperty
        {
            get { return mItemName; }
            set { mItemName = value; }
        }


        private bool mstatus_airplanemode;

        public bool status_airplanemode
        {
            get { return mstatus_airplanemode; }
            set
            {
                mstatus_airplanemode = value;
                RaisePropertyChanged("status_airplanemode");
            }
        }
        private bool mstatus_wifi;

        public bool status_wifi
        {
            get { return mstatus_wifi; }
            set
            {
                mstatus_wifi = value;
                RaisePropertyChanged("status_wifi");
            }
        }
        private bool mstatus_cellular;

        public bool status_cellular
        {
            get { return mstatus_cellular; }
            set
            {
                mstatus_cellular = value;
                RaisePropertyChanged("status_cellular");
            }
        }
        private bool mstatus_bluetooth;

        public bool status_bluetooth
        {
            get { return mstatus_bluetooth; }
            set
            {
                mstatus_bluetooth = value;
                RaisePropertyChanged("status_bluetooth");
            }
        }
        private bool mstatus_location;

        public bool status_location
        {
            get { return mstatus_location; }
            set
            {
                mstatus_location = value;
                RaisePropertyChanged("status_location");
            }
        }
        private bool mstatus_screenrotation;

        public bool status_screenrotation
        {
            get { return mstatus_screenrotation; }
            set
            {
                mstatus_screenrotation = value;
                RaisePropertyChanged("status_screenrotation");
            }
        }


        private ICommand mLoadCmd;

        public ICommand LoadCmd
        {
            get
            {
                return mLoadCmd ?? (mLoadCmd = new RelayCommand(() =>
                {

                    PowerSource power = DeviceStatus.PowerSource;
                    Debug.WriteLine("电池状态:" + power);
                    //是否有可用网络
                    bool isNetAvailable = Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                    var netInfo = Microsoft.Phone.Net.NetworkInformation.NetworkInterface.NetworkInterfaceType.ToString();
                    Debug.WriteLine("网络状态:" + netInfo + "   " + isNetAvailable);

                    //wifi
                    status_wifi = DeviceNetworkInformation.IsWiFiEnabled;
                    //手机数据
                    status_cellular = DeviceNetworkInformation.IsCellularDataEnabled;
                    //运营商

                    string celluarOperator = DeviceNetworkInformation.CellularMobileOperator.ToString();


                    //foreach (var item in dbservice.GetAllItem())
                    //{
                    //    Items.Add(item);
                    //}

                }));
            }
        }

        internal async Task GoLocation()
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-location:"));
        }

        internal async Task GoScreenrotation()
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-screenrotation:"));
        }

        internal async Task GoBluetooth()
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
        }

        internal async Task GoAirplanemode()
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-airplanemode:"));
        }

        internal async Task GoCellular()
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-cellular:"));
        }

        internal async Task GoWifi()
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-wifi:"));
        }


        //蓝牙状态
        private async void FindPaired()
        {

            // Search for all paired devices
            PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";

            try
            {
                var peers = await PeerFinder.FindAllPeersAsync();
                if (peers != null)
                {
                    this.status_bluetooth = true;
                }

                // Handle the result of the FindAllPeersAsync call
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x8007048F)
                {
                    //无蓝牙
                    this.status_bluetooth = false;
                }
            }
        }
    }
}
