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
	public partial class WebPickerPage : ContentPage
	{
		public WebPickerPage()
		{
			InitializeComponent();

            this.Padding = new Thickness(10, Device.OnPlatform(40, 20, 20), 10, 5);

            // Picker 에 데이터를 Add 합니다.
            this.picker.Items.Add("Easy");
            this.picker.Items.Add("Normal");
            this.picker.Items.Add("Hard");


            this.webView.Source = new UrlWebViewSource { Url = "http://kjunblog.com/" };
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 선택한 항목을 팝업으로 띄워줍니다.
            string selectData = this.picker.Items[this.picker.SelectedIndex];
            DisplayAlert(selectData, "SelectValue", "OK");
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            // 선택 팝업이 뜨고 선택한 항목에 따라 버튼 색을 바꿔줍니다.
            string color = await DisplayActionSheet("선택하세요", "취소", "닫기", "BLUE", "YELLOW", "RED", "GREEN");
            switch (color)
            {
                case "BLUE": this.button.BackgroundColor = Color.Blue; break;
                case "YELLOW": this.button.BackgroundColor = Color.Yellow; break;
                case "RED": this.button.BackgroundColor = Color.Red; break;
                case "GREEN": this.button.BackgroundColor = Color.Green; break;
            }
        }
    }
}