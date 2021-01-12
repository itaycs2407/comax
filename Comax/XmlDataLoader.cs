using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Comax
{
    public class XmlDataLoader : IDataLoader
    {
        List<Item> resultListItem = new List<Item>(); 
        public List<Item> loadDataFromDataSet()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory().ToString(), "xml_ex.xml");
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                if (reader != null)
                {
                    while (reader.ReadToFollowing("row"))
                    {
                      
                        {
                            Item item = new Item(reader.GetAttribute(0), reader.GetAttribute(1), reader.GetAttribute(2));
                            this.resultListItem.Add(item);
                        }
                    }
                }
                return resultListItem;
            }
        }
    }
}
