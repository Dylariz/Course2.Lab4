using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class ChartViewer : Form
    {
        public ChartViewer()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SimpleA algosA = new SimpleA();
            label1.Text = $"Answer: {algosA.Start(int.Parse(inputTextBox.Text))}";
        }
    }
}