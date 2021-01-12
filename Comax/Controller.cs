﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Comax
{
    public class Controller
    {
        private List<Item> m_Database = new List<Item>();
        private MainForm m_MainForm;

        private void loadData()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory().ToString(), "xml_ex.xml");
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                if (reader != null)
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
                else
                {
                    Console.WriteLine("sdfgsdfdfghdfghd");
                }
            }
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
