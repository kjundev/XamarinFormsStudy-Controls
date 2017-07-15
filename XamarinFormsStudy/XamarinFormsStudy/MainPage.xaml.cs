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

        Dictionary<string, Page> dic = new Dictionary<string, Page>();

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

            StackLayout stackLayout = new StackLayout() { VerticalOptions = LayoutOptions.CenterAndExpand };

            dic.Add("MasterDetailPage", new MasterDetailPage1());
            dic.Add("StackLayoutPage", new StackLayoutPage());
            dic.Add("AbsoluteLayoutPage", new AbsoluteLayoutPage());
            dic.Add("RelativeLayoutPage", new RelativeLayoutPage());
            dic.Add("GridPage", new GridPage());
            dic.Add("BaseControlPage", new BaseControlPage());
            dic.Add("WebPickerPage", new WebPickerPage());
            dic.Add("ListViewPage", new ListViewPage());
            dic.Add("OxyPlotPage", new OxyPlotPage());
            dic.Add("OxyPlotLineChartPage", new OxyPlotLineChartPage());
            dic.Add("SfDataGridPage", new SfDataGridPage());
            dic.Add("SQLiteSamplePage", new SQLiteSamplePage().GetSampleContentPage());

            foreach (var data in dic)
            {
                Button button = new Button() { Text = data.Key };
                button.Clicked += Button_Clicked;
                stackLayout.Children.Add(button);
            }
            var scroll = new ScrollView();
            scroll.Content = stackLayout;
            Content = scroll;
            

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string pagename = ((Button)sender).Text;
            await Navigation.PushAsync(dic[pagename]);
        }
    }
}
