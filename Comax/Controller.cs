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
            loadForm();
            this.mainForm.ShowDialog();
        }

        private void loadForm()
        {
            mainForm = new MainForm();
            mainForm.InitController(this);
            loadInitData();
        }
        public void loadInitData()
        {
            mainForm.InitDataGrid(this.m_Database);
        }

        internal List<Item> getItemsByName(string i_Text)
        {
            List<Item> nameIntersectionResult = new List<Item>();
            this.m_Database.ForEach((item)=> {
                if (item.Name.Contains(i_Text.TrimEnd().TrimStart()))
                {
                    nameIntersectionResult.Add(item);
                }

            });
            if (nameIntersectionResult.Count < 1)
            {
                return null;
            }

            return nameIntersectionResult;
        }
    }
}
