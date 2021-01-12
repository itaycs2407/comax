using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Comax
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private DataTable m_DataTable = new DataTable();

        internal void loadDataToGrid(List<Item> i_Database)
        {
            createHeaders();
            foreach (Item item in i_Database)
            {
                this.m_DataTable.Rows.Add(item.Kod, item.Name, item.BarKod);
            }
        }

        private void createHeaders()
        {
            m_DataTable.Columns.Add("קוד", typeof(string));
            m_DataTable.Columns.Add("שם", typeof(string));
            m_DataTable.Columns.Add("ברקוד", typeof(string));
            this.dgItems.DataSource = m_DataTable;
        }
    }
}
