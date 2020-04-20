using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace DemoAPI.Droid
{
    class SQLiteConn_Droid : SQLiteDBConnInterface
    {
        static SQLiteConnection Conn;

        public SQLiteConnection getSQLiteConnection()
        {
            if(Conn != null)
            {
                var dbName = "GetPYDB";
                var dbLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
                var dbPath = Path.Combine(dbLocation, dbName);
                Conn = new SQLiteConnection(dbPath);
                return Conn;
            }
            return Conn;
        }
        public void CreatTable<T>()
        {
            if (Conn != null)
            {
                Conn.CreateTable<T>();
            }
        }
    }
}