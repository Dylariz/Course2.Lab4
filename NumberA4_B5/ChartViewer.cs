using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NumberA4_B5
{
    public partial class ChartViewer : Form
    {
        public ChartViewer()
        {
            InitializeComponent();
            ChartInit(14, 2);
        }
        
        private void ChartInit(int maxN, int minN)
        {
            // Настройка графика
            mainChart.ChartAreas[0].AxisX.Title = "N";
            mainChart.ChartAreas[0].AxisY.Title = "Time, ms";
            mainChart.ChartAreas[0].AxisY.Interval = 2000;
            mainChart.Series.Clear();

            var watch = Stopwatch.StartNew();

            // Создание и запуск задач
            var simpleATasks = CreateAndRunTasks(TimeTests.SlowATest, minN, maxN, 1);
            var simpleBTasks = CreateAndRunTasks(TimeTests.SlowBTest, minN, maxN, 1);
            var strongBTasks = CreateAndRunTasks(TimeTests.FastBTest, minN, maxN, 1);

            watch.Stop();
            totalTimeLabel.Text =
                $"Время затраченное на ассинхронное выполнение всех задач: {watch.ElapsedMilliseconds} мс";

            // Отрисовка графиков
            AddChartSeries("SlowA", simpleATasks);
            AddChartSeries("SlowB", simpleBTasks);
            AddChartSeries("FastB", strongBTasks);
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

        private void AddChartSeries(string name, List<(Task<long>, int)> tasks)
        {
            Series series = new Series(name);
            series.ChartType = SeriesChartType.Line;
            foreach (var task in tasks)
            {
                series.Points.AddXY(task.Item2, task.Item1.Result);
            }

            mainChart.Series.Add(series);
        }
    }
}