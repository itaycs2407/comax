﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        private Controller m_Ctrl;

        public void InitController(Controller i_Ctrl)
        {
            this.m_Ctrl = i_Ctrl;
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
                this.m_DataTable.Rows.Add(item.Kod,item.BarKod, item.Name);
            }
        }

        // add all the info for the column headers
        private void createHeaders()
        {
            m_DataTable.Columns.Add("קוד", typeof(int));
            m_DataTable.Columns.Add("ברקוד", typeof(string));
            m_DataTable.Columns.Add("שם", typeof(string));
            
            this.dgItems.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.dgItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgItems.EnableHeadersVisualStyles = false;
            
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

        private bool isInpurEmpty(string i_Input)
        {
            return (i_Input.Trim() == string.Empty);
        }

        private void intersectionByData(string i_Text, bool i_ByName)
        {
            List<Item> intersection = m_Ctrl.getItemsByNameAndColumn(i_Text, i_ByName);
            if (intersection != null)
            {
                this.m_DataTable = new DataTable();
                InitDataGrid(intersection);
            }
            else
            {
                MessageBox.Show(string.Format(@"No item name contains the string : {0}", i_Text) , "Warning", MessageBoxButtons.OK);
                if (i_ByName)
                {
                    txtName.Text = string.Empty;
                }
                else
                {
                    txtKod.Text = string.Empty;
                }
                this.m_Ctrl.loadInitData();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox txtName = (sender as TextBox);
                if (!isInpurEmpty(txtName.Text))
                {
                    intersectionByData(txtName.Text, true);
                }
                else
                {
                    this.m_Ctrl.loadInitData();
                }
            }
        }
        
        private void txtName_KeyBlur(object sender, EventArgs e)
        {
            TextBox txtName = (sender as TextBox);
            if (!isInpurEmpty(txtName.Text))
            {
                intersectionByData(txtName.Text, true);
            }
            else
            {
                this.m_Ctrl.loadInitData();
            }
        }

        private void txtKod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox txtName = (sender as TextBox);
                if (!isInpurEmpty(txtName.Text))
                {
                    intersectionByData(txtName.Text, false);
                }
                else
                {
                    this.m_Ctrl.loadInitData();
                }
            }
        }

        private void txtKod_Leave(object sender, EventArgs e)
        {
            TextBox txtName = (sender as TextBox);
            if (!isInpurEmpty(txtName.Text))
            {
                intersectionByData(txtName.Text, false);
            }
            else
            {
                this.m_Ctrl.loadInitData();
            }
        }

        private void txtKod_Enter(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtKod.Text = string.Empty;
        }
    }
}
