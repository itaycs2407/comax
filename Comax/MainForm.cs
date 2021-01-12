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

        private void dgItems_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            changeBackColorByColumnIndex(e.ColumnIndex);
        }

        private void changeBackColorByColumnIndex(int i_PressedColumnHeadesIndex)
        {
            for (int i = 0; i < this.dgItems.Columns.Count; i++)
            {
                this.dgItems.Columns[i].DefaultCellStyle.BackColor = Color.White;
                if (i == i_PressedColumnHeadesIndex)
                {
                    this.dgItems.Columns[i].DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

       

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox txtName = (sender as TextBox);
                if (txtName.Text.TrimEnd().TrimStart() == string.Empty)
                {
                    MessageBox.Show("You didnt enter text in the text box", "Warning", MessageBoxButtons.OK);
                }

            }
        }
    }
}
