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
using System.Collections;

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

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int columnIndex = e.Column;

            if (listView1.ListViewItemSorter != null && ((ListViewItemCompare)listView1.ListViewItemSorter).col == columnIndex)
            {
                switch (listView1.Sorting)
                {
                    case SortOrder.Ascending:
                        listView1.Sorting = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        listView1.Sorting = SortOrder.Ascending;
                        break;
                }
            }
            else
            {
                listView1.Sorting = SortOrder.Ascending;
            }

            listView1.ListViewItemSorter = new ListViewItemCompare(columnIndex, listView1.Sorting);
            listView1.Sort();
        }
    }

    class ListViewItemCompare : IComparer
    {
        public int col;
        SortOrder order;

        public ListViewItemCompare()
        {
            col = 0;
            order = SortOrder.Ascending;
        }

        public ListViewItemCompare(int headerIndex, SortOrder sortingOrder)
        {
            col = headerIndex;
            order = sortingOrder;
        }

        public int Compare(object x, object y)
        {
            int value1;
            int value2;

            if (Int32.TryParse(((ListViewItem)x).SubItems[col].Text, out value1) && Int32.TryParse(((ListViewItem)y).SubItems[col].Text, out value2))
            {
                if (order == SortOrder.Ascending)
                {
                    return value1.CompareTo(value2);
                }
                else
                {
                    return value2.CompareTo(value1);
                }
            }

            if (order == SortOrder.Ascending)
            {
                return string.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
            else
            {
                return string.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
            }
            
        }
    }
}
