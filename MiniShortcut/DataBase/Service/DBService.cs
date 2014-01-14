using MiniShortcut.DataBase.Context;
using MiniShortcut.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShortcut.DataBase.Service
{
    public class DBService
    {
        private readonly static DBService mInstance = new DBService();

        public static DBService Instance
        {
            get { return mInstance; }

        }

        private DBContext context = DBContext.Instance;

        public List<ItemModel> GetAllItem()
        {
            var query = from e in context.Item select e;
            return query.ToList<ItemModel>();
        }
    }
}
