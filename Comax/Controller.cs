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
            using (XmlReader reader = XmlReader.Create(@"xml_ex.xml"))
            {
                while (reader.ReadToFollowing("row"))
                {
                    int kodAsInt;
                    if (int.TryParse(reader.GetAttribute(0).ToString(), out kodAsInt))
                    {
                        Item item = new Item(kodAsInt, reader.GetAttribute(1), reader.GetAttribute(2));
                        this.m_Database.Add(item);

                    }
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

        internal List<Item> getItemsByNameAndColumn(string i_Text, bool i_ByName)
        {
            List<Item> nameIntersectionResult = new List<Item>();
            if (i_ByName == true)
            {
                this.m_Database.ForEach((item)=> {
                    if (item.Name.Contains(i_Text.TrimEnd().TrimStart()))
                    {
                        nameIntersectionResult.Add(item);
                    }

                });
            }
            else
            {
                this.m_Database.ForEach((item) =>
                {
                    int kodAsInt;
                    if (int.TryParse(i_Text.TrimEnd().TrimStart(), out kodAsInt) && item.Kod == kodAsInt)
                    {
                        nameIntersectionResult.Add(item);
                    }

                });
            }
            if (nameIntersectionResult.Count < 1)
            {
                return null;
            }

            return nameIntersectionResult;
        }
    }
}
