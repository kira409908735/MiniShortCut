using MiniShortcut.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShortcut.Model
{
    [Table]
    public class ItemModel : BaseModel
    {
        private int mID;
        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID
        {
            get { return mID; }
            set
            {
                NotifyPropertyChanging("ID");
                mID = value;
                NotifyPropertyChanged("ID");
            }
        }
        private string mItemId;
        [Column]
        public string ItemId
        {
            get { return mItemId; }
            set { mItemId = value; }
        }


        private string mItemName;
        [Column]
        public string ItemName
        {
            get { return mItemName; }
            set { mItemName = value; }
        }

        private bool mItemStatus;//false:关，1：开
        [Column]
        public bool ItemStatus
        {
            get { return mItemStatus; }
            set { mItemStatus = value; }
        }

        private string mItemIcon;
        [Column]
        public string ItemIcon
        {
            get { return mItemIcon; }
            set { mItemIcon = value; }
        }
    }

   
}
