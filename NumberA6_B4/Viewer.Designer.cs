namespace NumberA6_B4
{
    partial class Viewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(11, 36);
            this.mainChart.Margin = new System.Windows.Forms.Padding(2);
            this.mainChart.Name = "mainChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.mainChart.Series.Add(series1);
            this.mainChart.Size = new System.Drawing.Size(1038, 360);
            this.mainChart.TabIndex = 3;
            this.mainChart.Text = "chart1";
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalTimeLabel.Location = new System.Drawing.Point(241, 9);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(574, 23);
            this.totalTimeLabel.TabIndex = 4;
            this.totalTimeLabel.Text = "Общее время выполнения в ассинхронном режиме заняло: ";
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 407);
            this.Controls.Add(this.totalTimeLabel);
            this.Controls.Add(this.mainChart);
            this.Name = "Viewer";
            this.Text = "Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label totalTimeLabel;

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;

        #endregion
    }
}