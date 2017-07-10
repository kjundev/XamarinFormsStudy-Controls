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
    public partial class ListViewPage2 : ContentPage
    {
        public ListViewPage2()
        {
            InitializeComponent();

            //MainListView.ItemsSource = new List<string> { "AA", "BB", "CC" };

            // 데이터들을 정의합니다.
            ListViewTestData data1 = new ListViewTestData() { ID = 1, Name = "user1", Age = 34, Dept = "Povice", Desc = "TestUser1" };
            ListViewTestData data2 = new ListViewTestData() { ID = 2, Name = "user2", Age = 31, Dept = "Povice", Desc = "TestUser2" };
            ListViewTestData data3 = new ListViewTestData() { ID = 3, Name = "user3", Age = 30, Dept = "Povice", Desc = "TestUser3" };
            ListViewTestData data4 = new ListViewTestData() { ID = 4, Name = "user4", Age = 40, Dept = "kjun", Desc = "TestUser4" };

            List<ListViewTestData> testData = new List<ListViewTestData>();
            testData.Add(data1);
            testData.Add(data2);
            testData.Add(data3);
            testData.Add(data4);

            // ListView 의 Source 에 적용하면 디자인 코드의 itemtemplate 에 바인딩될 항목을들 찾아 바인딩됩니다.
            MainListView.ItemsSource = testData;
        }
        /// <summary>
        ///  ListView 에 바인딩될 데이터입니다.
        /// </summary>
        public class ListViewTestData
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Dept { get; set; }
            public string Desc { get; set; }
        }
    }
}