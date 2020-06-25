using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;

namespace NetworkMonitor
{
    public partial class Form1 : Form
    {
        private bool start = true;
        Thread listThread;
        long networkByteStartDown;
        long networkByteStartUp;

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            
            if (start)
            {
                listThread = new Thread(delegate () { PopulateListView();  });
                listThread.Start();
                start = false;
                startButton.Text = "Stop";
                networkByteStartDown = Network.GetTotalNetworkBytes()[0];
                networkByteStartUp = Network.GetTotalNetworkBytes()[1];
            }
            else if (!start)
            {
                listThread.Abort();
                start = true;
                startButton.Text = "Start";
            }
        }

        void PopulateListView()
        {
            while (true)
            {
                string[][] items = Network.Usage();
                listView1.Items.Clear();
                try
                {
                    downloadDisplay.Text = (Network.GetTotalNetworkBytes()[0] - networkByteStartDown).ToString();
                    uploadDisplay.Text = (Network.GetTotalNetworkBytes()[1] - networkByteStartUp).ToString();

                    foreach (string[] value in items.Where(arr => Convert.ToInt32(arr[1]) != 0 || Convert.ToInt32(arr[2]) != 0))
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { value[0].ToString(), value[1].ToString(), value[2].ToString() }));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Couldn't Populate List View", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void downloadDisplay_Click(object sender, EventArgs e)
        {

        }

        private void uploadDisplay_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
