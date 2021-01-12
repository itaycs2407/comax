using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Comax
{
    public class Controller
    {
        private List<Item> m_Database = new List<Item>();
        private MainForm m_MainForm;
        private IDataLoader m_DataLoader = new XmlDataLoader();

        private void loadData()
        {
            this.m_Database = m_DataLoader.loadDataFromDataSet();
        }
        public Controller() {}

        public void Start()
        {
            loadData();
            loadForm();
            this.m_MainForm.ShowDialog();
        }

        private void loadForm()
        {
            m_MainForm = new MainForm();
            m_MainForm.InitController(this);
            loadInitData();
        }
        public void loadInitData()
        {
            m_MainForm.InitDataGrid(this.m_Database);
        }

        public List<Item> getItemsByNameAndColumn(string i_Text, bool i_ByName)
        {
            List<Item> textIntersectionResult = new List<Item>();
            if (i_ByName == true)
            {
                this.m_Database.ForEach((item)=> {
                    if (item.Name.Contains(i_Text.Trim()))
                    {
                        textIntersectionResult.Add(item);
                    }
                });
            }
            else
            {
                this.m_Database.ForEach((item) =>
                {
                   
                    if (item.Kod.Contains(i_Text.Trim()))
                    {
                        textIntersectionResult.Add(item);
                    }
                });
            }

            if (textIntersectionResult.Count < 1)
            {
                return null;
            }

            return textIntersectionResult;
        }
    }
}
