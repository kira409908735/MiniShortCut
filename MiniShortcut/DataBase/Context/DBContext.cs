using MiniShortcut.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShortcut.DataBase.Context
{
    public class DBContext : DataContext
    {
        public DBContext() : base("Data Source = isostore:/DataBase.sdf") { }

        private readonly static DBContext mInstance = new DBContext();

        public static DBContext Instance
        {
            get
            {

                return mInstance;
            }

        }

        public Table<ItemModel> Item;
        //public Table<IndustryModel> Industry;
        //public Table<CityModel> City;
        //public Table<ProvinceModel> Province;
        //public Table<RecentCoditionModel> RecentCodition;
        //public Table<GuideInfoModel> Guide;
    }
}
