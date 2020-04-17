using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocalDataBase
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public SQLiteConnection conn;
        public ProductModel Item;
        public MainPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteConn>().getSQLiteConnection();
            conn.CreateTable<ProductModel>();
        }

        private void setBtn_Clicked(object sender, EventArgs e)
        {
            if(itemName.Text!="")
            {
                loadLabel.Text = itemName.Text + " Added to Cart";
            }
            Item = new ProductModel();
            Item.Name = itemName.Text;
            Item.Quantity = itemQuantity.Text;
            conn.Insert(Item);
            itemName.Text = "";
            itemQuantity.Text = "";
        }

        private void resetBtn_Clicked(object sender, EventArgs e)
        {
            loadLabel.Text = "";
            var data = (from item in conn.Table<ProductModel>() select item);
            view.ItemsSource = data;
        }
    }
}
