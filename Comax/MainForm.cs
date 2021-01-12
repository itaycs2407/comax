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
        private Controller ctrl;

        public void InitController(Controller i_Ctrl)
        {
            this.ctrl = i_Ctrl;
        }
        internal void InitDataGrid(List<Item> i_Database)
        {
            m_DataTable = new DataTable();
            createHeaders();
            loadData(i_Database);
            
        }

        private void loadData(List<Item> i_Database)
        {
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

       


        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox txtName = (sender as TextBox);
                if (txtName.Text.TrimEnd().TrimStart() == string.Empty)
                {
                    MessageBox.Show("You didnt enter text in the text box", "Warning", MessageBoxButtons.OK);
                }
                else
                {
                    intersectionByName(txtName.Text);
                }

            }
        }

        private void intersectionByName(string i_Text)
        {
            List<Item> intersection = ctrl.getItemsByName(i_Text);
            if (intersection != null)
            {
                this.m_DataTable = new DataTable();
                InitDataGrid(intersection);
            }
            else
            {
                MessageBox.Show(string.Format(@"No item name contains the string : {0}", i_Text) , "Warning", MessageBoxButtons.OK);
                this.ctrl.loadInitData();
            }
        }

        

    }
}
