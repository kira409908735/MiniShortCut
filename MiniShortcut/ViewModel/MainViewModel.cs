using GalaSoft.MvvmLight;
using MiniShortcut.Model;
using System.Collections.ObjectModel;

namespace MiniShortcut.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// ItemViewModel 对象的集合。
        /// </summary>
        public ObservableCollection<ItemModel> Items { get; private set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
           
        }
      
    }
}