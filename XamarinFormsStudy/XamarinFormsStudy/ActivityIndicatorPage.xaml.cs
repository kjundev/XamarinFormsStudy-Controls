using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsStudy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityIndicatorPage : ContentPage
    {
        public ActivityIndicatorPage()
        {
            InitializeComponent();

            Label header = new Label
            {
                Text = "ActivityIndicator",
                FontSize = 40,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            ActivityIndicator activityIndicator = new ActivityIndicator
            {
                Color = Device.OnPlatform<Color>(Color.Black, Color.Default, Color.Default),
                IsRunning = true,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout
            {
                Children =
                    {
                    header,
                    activityIndicator
                    }
            };

            //IsBusy = true;
            //new Task(method).Start();

            //this.BtnLogin.Clicked += BtnLogin_Clicked;

        }

        //private async void method()
        //{
        //    await Task.Delay(5000);
        //    this.stackLayout1.IsVisible = false;
        //    this.activityIndicator.IsRunning = false;
        //}

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            IsBusy = false;
            
        }
    }
}