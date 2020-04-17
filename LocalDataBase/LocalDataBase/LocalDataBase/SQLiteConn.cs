using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDataBase
{
    public interface SQLiteConn
    {
        SQLiteConnection getSQLiteConnection();
    }
}
