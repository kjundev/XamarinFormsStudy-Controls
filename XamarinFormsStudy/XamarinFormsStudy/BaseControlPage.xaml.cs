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
    public partial class BaseControlPage : ContentPage
    {
        bool isActiveWindow = false;
        int buttonclick = 0;
        public BaseControlPage()
        {
            InitializeComponent();

            this.Padding = new Thickness(10, Device.OnPlatform(40, 20, 20), 10, 5);

            isActiveWindow = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.1), TimerCallback);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // 버튼 클릭시 숫자를 증가하여 표시해줍니다.
            int i = buttonclick++;
            this.entry.Text = i.ToString();
            this.editor.Text += i.ToString() + Environment.NewLine;
        }
        bool TimerCallback()
        {
            progressBar.Progress += 0.01;
            return isActiveWindow || progressBar.Progress == 1;
        }

        private void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            // 확인 팝업을 호출합니다.
            DisplayAlert("SearchBar",this.searchBar.Text + " Search...", "O", "X");
        }

        
        //protected override void OnStart()
        //{
        //    isActiveWindow = true;
        //    Device.StartTimer(TimeSpan.FromSeconds(0.1), TimerCallback);
        //}

        //protected override void OnSleep()
        //{
        //    isActiveWindow = false;
        //}

        //protected override void OnResume()
        //{

        //}


    }
}