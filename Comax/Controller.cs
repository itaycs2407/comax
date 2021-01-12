using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Comax
{
    public class Controller
    {
        private List<Item> m_Database = new List<Item>();
        private MainForm mainForm;

        private void loadData()
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Users\Itay Cohen\Downloads\test.xml"))
            {
                while (reader.ReadToFollowing("row"))
                {
                    Item item = new Item(reader.GetAttribute(0), reader.GetAttribute(1), reader.GetAttribute(2));
                    this.m_Database.Add(item);
                }
            }
        }
        public Controller() { }
        

        public void start()
        {
            loadData();
            loadDataToForm();
            this.mainForm.ShowDialog();
        }

        private void loadDataToForm()
        {
            mainForm = new MainForm();
            mainForm.loadDataToGrid(this.m_Database);
        }
    }
}
