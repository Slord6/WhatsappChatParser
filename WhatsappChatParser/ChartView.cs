using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WhatsappChatParser
{
    public partial class ChartView : Form
    {
        public ChartView()
        {
            InitializeComponent();
            chart.Series.Clear();
        }

        public void ReplaceData<T,U>(Dictionary<T,U> data, double gridLineFrequencyX = 1.0f, double gridLineFrequencyY = 10.0f)
        {
            Series dataSeries = new Series("Word Distribution", data.Count);
            chart.Series.Add(dataSeries);
            chart.Series["Word Distribution"].Points.DataBindXY(data.Keys, data.Values);
            chart.ChartAreas["ChartArea1"].AxisX.Interval = gridLineFrequencyX;
            chart.ChartAreas["ChartArea1"].AxisY.Interval = gridLineFrequencyY;
        }

        private void asImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "chart.png";
            DialogResult result = saveFileDialog.ShowDialog();

            if(result != DialogResult.Cancel)
            {
                chart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
            }
        }
    }
}
