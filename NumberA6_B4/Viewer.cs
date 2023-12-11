using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NumberA6_B4
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
            ConfigureAndPopulateChart(200, 10000, 200);
        }

        private void ConfigureAndPopulateChart(int minN, int maxN, int step)
        {
            // Настройка графика
            mainChart.ChartAreas[0].AxisX.Title = "N";
            mainChart.ChartAreas[0].AxisX.Interval = 1000;
            mainChart.ChartAreas[0].AxisY.Title = "Time, ms";
            mainChart.ChartAreas[0].AxisY.Interval = 200;
            mainChart.Series.Clear();

            var timer = Stopwatch.StartNew();

            var slowATasks = CreateAndRunTasks(TimeTests.SlowATest, minN, maxN, step);
            var fastATasks = CreateAndRunTasks(TimeTests.FastATest, minN, maxN, step);
            var slowBTasks = CreateAndRunTasks(TimeTests.SlowBTest, minN, maxN, step);

            AddSeriesToChart("SlowA", slowATasks);
            AddSeriesToChart("FastA", fastATasks);
            AddSeriesToChart("SlowB", slowBTasks);

            timer.Stop();

            totalTimeLabel.Text = $"Общее время выполнения в ассинхронном режиме заняло: {timer.ElapsedMilliseconds} мс";
        }

        private List<(Task<long>, int)> CreateAndRunTasks(Func<int, long> testMethod, int minN, int maxN, int step)
        {
            var tasks = new List<(Task<long>, int)>();
            for (int i = minN; i <= maxN; i += step)
            {
                int k = i;
                tasks.Add((Task.Run(() => testMethod(k)), i));
            }
            Task.WaitAll(tasks.Select(x => x.Item1).Cast<Task>().ToArray());
            return tasks;
        }

        private void AddSeriesToChart(string seriesName, List<(Task<long>, int)> tasks)
        {
            var series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Line
            };

            foreach (var task in tasks)
            {
                series.Points.AddXY(task.Item2, task.Item1.Result);
            }

            mainChart.Series.Add(series);
        }
    }
}