using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsStudy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SfDataGridPage : ContentPage
    {
        private ObservableCollection<OrderInfo> orderInfo;

        public SfDataGridPage()
        {
            InitializeComponent();

            // 바인딩될 데이터를 추가합니다.
            orderInfo = new ObservableCollection<OrderInfo>();
            orderInfo.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin"));
            orderInfo.Add(new OrderInfo(1002, "Ana Trujilo", "Mexico", "ANATR", "México D.F."));
            orderInfo.Add(new OrderInfo(1003, "Ant Fuller", "Mexico", "ANTON", "México D.F."));
            orderInfo.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London"));
            orderInfo.Add(new OrderInfo(1005, "Tim Adams", "Sweden", "BERGS", "Luleå"));
            orderInfo.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim"));
            orderInfo.Add(new OrderInfo(1007, "Andrew Fuller", "France", "BLONP", "Strasbourg"));
            orderInfo.Add(new OrderInfo(1008, "Martin King", "Spain", "BOLID", "Madrid"));
            orderInfo.Add(new OrderInfo(1009, "Lenny Lin", "France", "BONAP", "Marseille"));
            orderInfo.Add(new OrderInfo(1010, "John Carter", "Canada", "BOTTM", "Tsawassen"));
            orderInfo.Add(new OrderInfo(1011, "Lauro King", "UK", "AROUT", "London"));
            orderInfo.Add(new OrderInfo(1012, "Anne Wilson", "Germany", "BLAUS", "Mannheim"));
            orderInfo.Add(new OrderInfo(1013, "Alfki Kyle", "France", "BLONP", "Strasbourg"));
            orderInfo.Add(new OrderInfo(1014, "Gina Irene", "UK", "AROUT", "London"));

            // 컬럼 Sorting 활성화 여부
            this.dataGrid.AllowSorting = true;

            // 더블 클릭시 이벤트
            this.dataGrid.GridDoubleTapped += DataGrid_GridDoubleTapped;

            // 데이터 로드시 이벤트
            this.dataGrid.GridLoaded += DataGrid_GridLoaded;

            // 편집여부
            this.dataGrid.AllowEditing = true;

            // 고정 컬럼/열
            this.dataGrid.FrozenRowsCount = 2;

            // 컬럼 이동 여부
            this.dataGrid.AllowDraggingColumn = true;

            // 데이터를 바인딩합니다.
            this.dataGrid.ItemsSource = orderInfo;

        }

        /// <summary>
        /// 데이터 로드시 이벤트입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_GridLoaded(object sender, Syncfusion.SfDataGrid.XForms.GridLoadedEventArgs e)
        {
            ActivityIndicator indicator = new ActivityIndicator();
            indicator.IsRunning = true;
            indicator.IsVisible = true;
            indicator.BackgroundColor = Color.Gray;
            this.dataGrid.Children.Add(indicator);
            Task.Delay(2000).Wait();
            indicator.IsRunning = false;
            indicator.IsVisible = false;
        }

        /// <summary>
        /// 더블 클릭시 이벤트입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_GridDoubleTapped(object sender, Syncfusion.SfDataGrid.XForms.GridDoubleTappedEventsArgs e)
        {
            OrderInfo selectData = e.RowData as OrderInfo;
            DisplayAlert("Select Value", selectData.CustomerID, "OK");
        }

        /// <summary>
        /// 바인딩할 Test Class 입니다.
        /// </summary>
        class OrderInfo : INotifyPropertyChanged
        {
            private int orderID;
            private string customerID;
            private string customer;
            private string shipCity;
            private string shipCountry;

            public int OrderID
            {
                get { return orderID; }
                set { this.orderID = value; }
            }

            public string CustomerID
            {
                get { return customerID; }
                set { this.customerID = value; }
            }

            public string ShipCountry
            {
                get { return shipCountry; }
                set { this.shipCountry = value; }
            }

            public string Customer
            {
                get { return this.customer; }
                set { this.customer = value; }
            }

            public string ShipCity
            {
                get { return shipCity; }
                set { this.shipCity = value; }
            }

            public OrderInfo(int orderId, string customerId, string country, string customer, string shipCity)
            {
                this.OrderID = orderId;
                this.CustomerID = customerId;
                this.Customer = customer;
                this.ShipCountry = country;
                this.ShipCity = shipCity;
            }

            #region INotifyPropertyChanged implementation

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(String Name)
            {
                if (PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }

            #endregion
        }
    }
}