using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI
{
    public interface SQLiteDBConnInterface
    {
        SQLiteConnection getSQLiteConnection();
    }
}
