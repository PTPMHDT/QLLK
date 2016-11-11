using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PresentationLayer.TestFolder
{
    class HoaDonTmps : List<HoaDonTmp>
    {
        public HoaDonTmps(DataTable dt)
        {

        }

        public DataTable toDataTable()
        {
            return new DataTable();
        }

        public void update()
        {

        }
    }
}
