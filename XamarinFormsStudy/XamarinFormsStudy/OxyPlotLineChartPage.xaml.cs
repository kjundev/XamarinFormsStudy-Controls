using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
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
    public partial class OxyPlotLineChartPage : ContentPage
    {
        public OxyPlotLineChartPage()
        {
            InitializeComponent();

            Random r = new Random();
            // 차트에 표현해줄 데이터 입니다.
            Dictionary<DateTime, double> data = new Dictionary<DateTime, double>();
            data.Add(new DateTime(2017, 7, 10, 09, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 10, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 11, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 12, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 13, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 14, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 15, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 16, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 17, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 18, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 19, 30, 00), r.NextDouble());
            data.Add(new DateTime(2017, 7, 10, 20, 30, 00), r.NextDouble());


            CreateBarChart(false,"OxyPlot Line Chart", data);
        }

        private void CreateBarChart(bool stacked, string title, Dictionary<DateTime, double> dataList)
        {
            // 차트에 바인딩될 데이터 Model 입니다.
            var model = new PlotModel
            {
                Title = title,
                PlotType = PlotType.XY,
            };

            // x축은 시간이 보이도록 설정합니다.
            model.Axes.Add(new DateTimeAxis
            {
                Title = "시간",
                Position = AxisPosition.Bottom,
                StringFormat = "HH:mm:ss"
            });

            // Y 축은 값입니다.
            model.Axes.Add(new LinearAxis
            {
                Title = "만원",
                Position = AxisPosition.Left
            });

            // 각 포인트의 데이터를 model 에 add 합니다.
            // 여기서 PointAnnotation 는 각 포인트에 라벨을 표시하기 위함입니다.
            var Points = new List<DataPoint>();
            //int idx = 0;
            foreach (var i in dataList)
            {
                var pointAnnotation = new PointAnnotation();
                pointAnnotation.X = TimeSpanAxis.ToDouble(i.Key);
                pointAnnotation.Y = i.Value;
                pointAnnotation.TextVerticalAlignment = VerticalAlignment.Top;
                pointAnnotation.TextHorizontalAlignment = HorizontalAlignment.Center;
                pointAnnotation.Text = (i.Value).ToString("#.00");
                // 실제 데이터 값을 포인트에 add 합니다.
                Points.Add(new DataPoint(TimeSpanAxis.ToDouble(i.Key), i.Value));
                // 해당 포인트에 대한 라벨표시값도 추가합니다.
                model.Annotations.Add(pointAnnotation);
            }

            // Line 차트를 그리기 위한 라인시리즈를 정의합니다.
            var s = new LineSeries();

            // 각 포인트에 동그란 점으로 표시하게 합니다.
            s.MarkerType = MarkerType.Circle;
            // 정의한 포이트 데이터들을 라인시리즈의 소스로 적용합니다.
            s.ItemsSource = Points;
            // 차트에 적용할 model 에 추가합니다.
            model.Series.Add(s);

            // 위에서 정의한 model 을 차트에 적용합니다.
            PlotChart.Model = model;
        }
        
    }
}