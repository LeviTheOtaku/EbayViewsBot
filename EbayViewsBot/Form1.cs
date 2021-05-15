using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EbayViewsBot
{
    public partial class EbayViewsBot : Form
    {
        public EbayViewsBot()
        {
            InitializeComponent();
        }

        private string globalUrl = "";
        private int completed = 0;
        private int todo = 100;
        private void button1_Click(object sender, EventArgs e)
        {
            globalUrl = textBox1.Text;
            completed = 0;
            todo = decimal.ToInt32(numericUpDown1.Value);
            progressBar1.Maximum = todo;
            doView.Start();
        }

        private void doView_Tick(object sender, EventArgs e)
        {
            if (completed < todo)
            {
                var client = new HttpClient();
                var content = client.GetStringAsync(globalUrl);
                completed++;

                progressBar1.Value = completed;

                Random rnd = new Random();
                doView.Interval = rnd.Next(150, 250);
            }
            else
            {
                doView.Stop();
            }
        }
    }
}
