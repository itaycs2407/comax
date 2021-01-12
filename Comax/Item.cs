using System;
using System.Collections.Generic;
using System.Text;

namespace Comax
{
    public class Item
    {
        public int Kod { get; set; }
        public string Name { get; set; }
        public string BarKod { get; set; }

        public Item(int i_Kod, string i_Name, string i_BarKod)
        {
            this.Kod = i_Kod;
            this.Name = i_Name;
            this.BarKod = i_BarKod;
        }
    }
}
