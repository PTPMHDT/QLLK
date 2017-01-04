using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace PresentationLayer.DAL
{
    public class KiemKho_DAL
    {
        public static string getMaxKiemKho(int c)
        {
            try
            {
                string result = Context.getInstance().db.KIEMKHOes.OrderByDescending(x => x.MaKiemKho).First().MaKiemKho;
                int index = (Convert.ToInt16((result).Substring(2)) + 1) + c;
                if (index < 10)
                    return "KK00" + index;
                else if (index < 100)
                    return "KK0" + index;
                return "KK" + index;
            }
            catch (Exception)
            {
                return "KK001";
            }
        }
        public static List<CT_KiemKho_View> get_AllLinhKien(string maThuongHieu)
        {
            var kho1 = from kho in Context.getInstance().db.KHOes
                       where kho.LINHKIEN.THUONGHIEU.MaThuongHieu == maThuongHieu
                       select new CT_KiemKho_View
                       {
                           
                           MaLinhKien = kho.MaLinhKien,
                           TenLinhKien = kho.LINHKIEN.TenLinhKien,
                           //MaDonViTinh = kho.LINHKIEN.DONVITINH.MaDonViTinh,
                           DonViTinh = kho.LINHKIEN.DONVITINH.TenDonViTinh,
                           GhiChu = kho.LINHKIEN.MoTa

                       };

            List<CT_KiemKho_View> myHD = new List<CT_KiemKho_View>();
            bool isHave = false;
            foreach (var item in kho1.ToList())
            {
                if (myHD.Count > 0)
                {
                    isHave = false;
                    foreach (var item1 in myHD)
                    {
                        if (item.MaLinhKien == item1.MaLinhKien)
                        {
                            item1.SoLuong += 1;
                            isHave = true;
                            break;
                        }
                    }
                    if (!isHave)
                    {
                        item.SoLuong += 1;
                        myHD.Add(item);
                    }

                }
                else
                {
                    
                    item.SoLuong += 1;
                    myHD.Add(item);
                }

            }
            return myHD;// kho1.ToList();

        }
        public static bool add_KiemKho(KiemKho_View hd, DataUpdate<CT_KIEMKHO> list_Change)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    hd.TrangThai = 1;
                    Context.getInstance().db.Entry(hd.toKiemKho()).State = System.Data.Entity.EntityState.Added;
                    list_Change.Inserts.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x).State = System.Data.Entity.EntityState.Added;
                    });

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    //Context.getInstance().db.KHOes.Local.Clear();
                    //Context.getInstance().db.CT_HOADON.Local.Clear();
                    //Context.getInstance().db.KHACHHANGs.Local.Clear();
                    //Context.getInstance().db.NHANVIENs.Local.Clear();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------" + ex.Message);
                    return false;
                }
            }
            return true;
        }

    }
}
