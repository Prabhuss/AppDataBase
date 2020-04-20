using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DemoAPI
{
    public class DBFunctions
    {
        SQLiteAsyncConnection db;
        public DBFunctions(string dbPath)
        {
            //Connection setup
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<CustomerDetailsModel>().Wait();

        }

    }
}