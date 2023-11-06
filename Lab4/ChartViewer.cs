using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab4
{
    public partial class ChartViewer : Form
    {
        public ChartViewer()
        {
            InitializeComponent();
            ChartInit(14, 2);
        }

        [SuppressMessage("ReSharper", "CoVariantArrayConversion")]
        private void ChartInit(int maxN, int minN)
        {
            // Настройка графика
            mainChart.ChartAreas[0].AxisX.Title = "N";
            mainChart.ChartAreas[0].AxisY.Title = "Time, ms";
            mainChart.ChartAreas[0].AxisY.Interval = 2000;
            mainChart.Series.Clear();

            var watch = Stopwatch.StartNew();

            // Создание и запуск задач
            List<(Task<long>, int)> simpleATasks = new List<(Task<long>, int)>();
            for (int i = minN; i <= maxN; i++)
            {
                int k = i;
                var task = new Task<long>(() => TimeTests.SimpleATest(k));
                task.Start();
                simpleATasks.Add((task, i));
            }

            List<(Task<long>, int)> simpleBTasks = new List<(Task<long>, int)>();
            for (int i = minN; i <= maxN; i++)
            {
                int k = i;
                var task = new Task<long>(() => TimeTests.SimpleBTest(k));
                task.Start();
                simpleBTasks.Add((task, i));
            }

            List<(Task<long>, int)> strongBTasks = new List<(Task<long>, int)>();
            for (int i = minN; i <= maxN; i++)
            {
                int k = i;
                var task = new Task<long>(() => TimeTests.StrongBTest(k));
                task.Start();
                strongBTasks.Add((task, i));
            }

            // Ожидание завершения всех задач
            Task.WaitAll(simpleATasks.Select(x => x.Item1).ToArray());
            Task.WaitAll(simpleBTasks.Select(x => x.Item1).ToArray());
            Task.WaitAll(strongBTasks.Select(x => x.Item1).ToArray());

            watch.Stop();
            totalTimeLabel.Text =
                $"Время затраченное на ассинхронное выполнение всех задач: {watch.ElapsedMilliseconds} мс";

            // Отрисовка графиков
            AddChartSeries("SimpleA", simpleATasks);
            AddChartSeries("SimpleB", simpleBTasks);
            AddChartSeries("StrongB", strongBTasks);
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