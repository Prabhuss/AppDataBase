using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoAPI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public static DBFunctions Conn;
        public static DBFunctions SQLiteDb
        {
            get
            {
                if (Conn == null)
                {
                    var dbName = "GetPYDB";
                    var dbLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
                    var dbPath = Path.Combine(dbLocation, dbName);
                    Conn = new DBFunctions(dbPath);
                    return Conn;
                }
                return Conn;
            }
        }
    

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
