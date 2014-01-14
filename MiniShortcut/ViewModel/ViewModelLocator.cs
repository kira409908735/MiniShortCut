/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MiniShortcut"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace MiniShortcut.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //SimpleIoc.Default.Register<MainViewModel>();
        }

        //public MainViewModel Main
        //{
        //    //get
        //    //{
        //    //    //return ServiceLocator.Current.GetInstance<MainViewModel>();
        //    //}
        //}

        private static ViewModelLocator instance;
        public static ViewModelLocator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = App.Current.Resources["Locator"] as ViewModelLocator;
                }
                return instance;
            }
        }

        //È«¾°Ò³
        private ShortcutVM mShortcut;

        public ShortcutVM Shortcut
        {
            get { return mShortcut ?? (mShortcut = new ShortcutVM()); }
            set { mShortcut = value; }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}