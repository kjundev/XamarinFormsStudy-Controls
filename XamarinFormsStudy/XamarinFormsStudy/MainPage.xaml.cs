using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsStudy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Content = new Label
            //{
            //    Text = "Hello, Forms!",
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //};

            //Content = new StackLayout
            //{
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    Children =
            //    {
            //        new Label{
            //                    Text = "Hello, Forms!",
            //                    VerticalOptions = LayoutOptions.CenterAndExpand,
            //                    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //        }
            //    }
            //};

            Button gridPageButton = new Button() { Text = "GridPage" };
            gridPageButton.Clicked += Button_Clicked;

            Button masterDetailPageButton = new Button() { Text = "MasterDetailPage" };
            masterDetailPageButton.Clicked += Button_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    gridPageButton,
                    masterDetailPageButton
                }
            };

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string pagename = ((Button)sender).Text;
            switch (pagename)
            {
                case "GridPage":
                    await Navigation.PushAsync(new GridPage());
                    break;
                case "MasterDetailPage":
                    await Navigation.PushAsync(new MasterDetailTestPage());
                    break;
            }
        }
    }
}
