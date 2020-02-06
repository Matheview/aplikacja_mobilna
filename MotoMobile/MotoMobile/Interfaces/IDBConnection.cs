using System;
using System.Collections.Generic;
using SQLite;
using System.Text;

namespace MotoMobile.Interfaces
{
    public interface IDBConnection
    {
        SQLiteConnection CreateConnection();
    }
}
