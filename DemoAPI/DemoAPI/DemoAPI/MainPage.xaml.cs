using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace DemoAPI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void setBtn_Clicked(object sender, EventArgs e)
        {
            IDictionary<string, string> ParameterList = new Dictionary<string, string>();
            //ParameterList.Add("phone", mobileNo.Text);
            //ParameterList.Add("mid", mID.Text);
            ParameterList.Add("phone", "9898989898");
            ParameterList.Add("mid", "180");
            TestAPIFunction(ParameterList);
        }

        private async void TestAPIFunction(IDictionary<string, string> ParameterList)
        {
            string url = "https://getpymobileapp.azurewebsites.net/getcustInfo";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //string jsonData = "{\"phone\":\"" + mobileNo.Text + "\",\"mid\":" + mID.Text + "}";
                    //string jsonData = "{\"phone\":\"9972792530\",\"mid\":180}";
                    string jsonData = JsonConvert.SerializeObject(ParameterList);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();

                    //handling the answer  
                    CustomerDetailsModel CDMTableList = JsonConvert.DeserializeObject<CustomerDetailsModel>(result);
                    var enumerable = new[] { CDMTableList };
                    view.ItemsSource = enumerable;
                    //Employees = new ObservableCollection<CustomerDetailsModel>(CDMTableList);
                    loadLabel.Text = "Successfully Fetched";
                }
                catch (Exception ex)
                {
                    loadLabel.Text = "Sorry!!" + ex.Message;
                }
            }
        }


        private void ResetUI()
        {
            try
            {
                mobileNo.Text = "";
                mID.Text = "";
                view.ItemsSource = null;
            }
            catch(Exception ex)
            {
                loadLabel.Text = "reset Error!!" + ex.Message;
            }
        }

        private void resetBtn_Clicked(object sender, EventArgs e)
        {
            ResetUI();
        }
    }
}
