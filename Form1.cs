using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms.NET__Async_Csharp__Split_Container__ProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private const string APP_NAME = «MY_PREDICTOR";
    private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                for (int j = 0; j < 10000000; j++)
                    i = 0;
                progressBar1.Value = i;
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await Task.Delay(3000); // Wait for 3 seconds
                                        // Invoke the button click on the UI thread
                this.Invoke((MethodInvoker)delegate {
                    button1_Click(sender, EventArgs.Empty);
                });
            });
        }
    }
}
