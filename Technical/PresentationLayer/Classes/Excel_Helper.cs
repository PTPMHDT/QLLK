using PresentationLayer.DAL;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PresentationLayer.Classes
{
    public class Excel_Helper
    {
        public static List<CT_HoaDonNhap_View> readFile(string maHD, string fileName)
        {
            


            List<CT_HoaDonNhap_View> lst = new List<CT_HoaDonNhap_View>();

            // Reference to Excel Application.
            Excel.Application xlApp = new Excel.Application();

            // Open the Excel file.
            // You have pass the full path of the file.
            // In this case file is stored in the Bin/Debug application directory.
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Path.GetFullPath(fileName));

            // Get the first worksheet.
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);

            // Get the range of cells which has data.
            Excel.Range xlRange = xlWorksheet.UsedRange;

            // Get an object array of all of the cells in the worksheet with their values.
            object[,] valueArray = (object[,])xlRange.get_Value(
                        Excel.XlRangeValueDataType.xlRangeValueDefault);

            CT_HoaDonNhap_View cthd;
            string maLK;
            string tenLK;
            Decimal giaNhap;
            float thue;
            string seri;

            // iterate through each cell and display the contents.
            for (int row = 2; row <= xlWorksheet.UsedRange.Rows.Count; ++row)
            {
                maLK = valueArray[row, 1].ToString().Trim();
                tenLK = valueArray[row, 2].ToString().Trim();
                giaNhap = Decimal.Parse(valueArray[row, 3].ToString().Trim());
                thue = float.Parse(valueArray[row, 4].ToString().Trim());
                seri = valueArray[row, 5].ToString().Trim();

                var ct = lst.Where(key => key.MaLinhKien == maLK).FirstOrDefault();
                if (ct != null)
                {
                    ct.SoLuong += 1;
                    ct.ThanhTien = (ct.GiaNhap * ct.SoLuong) + (ct.GiaNhap * ct.SoLuong) * (Decimal)(ct.Thue / 100);
                    ct.SoSeri.Add(seri);
                }
                else
                {
                    cthd = new CT_HoaDonNhap_View();
                    cthd.MaHoaDon = maHD;
                    cthd.SoLuong = 1;
                    cthd.GiaNhap = giaNhap;
                    cthd.MaLinhKien = maLK;
                    LinhKien_View lk = LinhKien_DAL.get_LinhKien_ByMaLK(maLK);
                    if(lk!= null)
                        cthd.TenLinhKien = lk.TenLinhKien;
                    cthd.Seri = seri;
                    cthd.SoSeri = new List<string>();
                    cthd.SoSeri.Add(seri);
                    cthd.Thue = thue;
                    cthd.ThanhTien = (cthd.GiaNhap * cthd.SoLuong) + (cthd.GiaNhap * cthd.SoLuong) * (Decimal)(cthd.Thue / 100); 
                    cthd.TinhTrang = 1;
                    lst.Add(cthd);
                }
                
            }

            // Close the Workbook.
            xlWorkbook.Close(false);

            // Relase COM Object by decrementing the reference count.
            Marshal.ReleaseComObject(xlWorkbook);

            // Close Excel application.
            xlApp.Quit();

            // Release COM object.
            Marshal.FinalReleaseComObject(xlApp);

            return lst;
        }
    }
}
