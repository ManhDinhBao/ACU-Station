using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace ACUManager
{
    public partial class ibsChart : UserControl
    {       
        string chartTitle;
        int count=0;
        public ibsChart()
        {
            InitializeComponent();
        }

        public ibsChart(string chartTile, int count)
        {
            InitializeComponent();            
            this.chartTitle = chartTile;
            this.count = count;
        }

        private void ibsChart_Load(object sender, EventArgs e)
        {
            try
            {
                chart.Series.Clear();

                Series series1 = new Series("Series 1", ViewType.Doughnut);
                if (count >= 100)
                {
                    series1.Points.Add(new SeriesPoint(chartTitle, 95));
                    series1.Points.Add(new SeriesPoint("NULL", 5));
                }
                else
                {
                    series1.Points.Add(new SeriesPoint(chartTitle, count));
                    series1.Points.Add(new SeriesPoint("NULL", 100 - count));
                }
                series1.LabelsVisibility = series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

                chart.Series.Add(series1);

                chart.Titles.Clear();

                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = string.Format(chartTitle);
                chartTitle1.Dock = ChartTitleDockStyle.Bottom;
                chartTitle1.MaxLineCount = 1;
                chartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.True;
                chartTitle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartTitle1.WordWrap = true;

                chart.Titles.Add(chartTitle1);

                //txtCount.Text = count.ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
