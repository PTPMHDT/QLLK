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

            CT_HoaDonNhap_View cthd = new CT_HoaDonNhap_View();

            bool ischange = true;

            // iterate through each cell and display the contents.
            for (int row = 2; row <= xlWorksheet.UsedRange.Rows.Count; ++row)
            {
                try
                {
                    if (ischange)
                    {
                        cthd = new CT_HoaDonNhap_View();
                        cthd.MaLinhKien = valueArray[row, 1].ToString().Trim();
                        cthd.TenLinhKien = valueArray[row, 2].ToString().Trim();
                        cthd.GiaNhap = Decimal.Parse(valueArray[row, 3].ToString().Trim());
                        cthd.SoLuong = Int32.Parse(valueArray[row, 4].ToString().Trim());
                        cthd.SoSeri = new List<string>();
                        cthd.Thue = 0;
                        cthd.ThanhTien = (cthd.GiaNhap * cthd.SoLuong) + (cthd.GiaNhap * cthd.SoLuong) * (Decimal)(cthd.Thue / 100);
                        ischange = false;
                    }
                    else
                    {
                        cthd.SoSeri.Add(valueArray[row, 5].ToString().Trim());
                        if (cthd.SoSeri.Count == cthd.SoLuong)
                        {
                            ischange = true;
                            lst.Add(cthd);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("File dữ liệu không đúng định dạng hoặc dữ liệu bị sai, trùng. Xin vui lòng kiểm tra lại!");
                    return new List<CT_HoaDonNhap_View>();
                }



                //var ct = lst.Where(key => key.MaLinhKien == maLK).FirstOrDefault();
                //if (ct != null)
                //{
                //    ct.SoLuong += 1;
                //    ct.ThanhTien = (ct.GiaNhap * ct.SoLuong) + (ct.GiaNhap * ct.SoLuong) * (Decimal)(ct.Thue / 100);
                //    ct.SoSeri.Add(seri);
                //}
                //else
                //{
                //    cthd = new CT_HoaDonNhap_View();
                //    cthd.MaHoaDon = maHD;
                //    cthd.SoLuong = 1;
                //    cthd.GiaNhap = giaNhap;
                //    cthd.MaLinhKien = maLK;
                //    LinhKien_View lk = LinhKien_DAL.get_LinhKien_ByMaLK(maLK);
                //    if(lk!= null)
                //        cthd.TenLinhKien = lk.TenLinhKien;
                //    cthd.Seri = seri;
                //    cthd.SoSeri = new List<string>();
                //    cthd.SoSeri.Add(seri);
                //    cthd.Thue = 0;
                //    cthd.ThanhTien = (cthd.GiaNhap * cthd.SoLuong) + (cthd.GiaNhap * cthd.SoLuong) * (Decimal)(cthd.Thue / 100); 
                //    cthd.TinhTrang = 1;
                //    lst.Add(cthd);
                //}

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
