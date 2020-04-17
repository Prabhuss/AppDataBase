using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalDataBase;
using SQLite;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using LocalDataBase.Droid;

[assembly:Dependency(typeof(LocalDataBase_Droid))]
namespace LocalDataBase.Droid 
{
    class LocalDataBase_Droid : SQLiteConn
    {
        public SQLiteConnection getSQLiteConnection()
        {
            var dbName = "MyLocalDB";
            var dbLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var dbPath = Path.Combine(dbLocation, dbName);
            var Conn = new SQLiteConnection(dbPath);
            return Conn;
        }

    }
}
