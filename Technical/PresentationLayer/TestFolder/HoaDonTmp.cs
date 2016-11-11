using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace PresentationLayer.TestFolder
{
    public class HoaDonTmp
    {
        public string id;
        public string name;
        public HoaDonTmp(DataRow d)
        {
            this.id = d["id"].ToString();
            this.name = d["name"].ToString();
        }

    }
}
