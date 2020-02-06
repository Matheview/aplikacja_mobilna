using MotoMobile.Interfaces;
using MotoMobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MotoMobile.Controllers
{
    public static class DatabaseController
    {
        static SQLiteConnection dbConnection;

        public static void Connect()
        {
            dbConnection = DependencyService.Get<IDBConnection>().CreateConnection();
        }

        public static List<T> GetAllItems<T>() where T : IDataModel, new()
        {
            //return dbConnection.Query<T>("Select * From [Employee]");
            return (from table in dbConnection.Table<T>()
                    select table).ToList();
        }

        public static int InsertItem(IDataModel item)
        {
            return dbConnection.Insert(item);
        }
    }
}
