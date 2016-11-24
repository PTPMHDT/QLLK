using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class LinhKien_DAL
    {
        public static List<LinhKien_View> getAll_LinhKien()
        {
            var lk1 = from lk in Context.getInstance().db.LINHKIENs
                       select new LinhKien_View()
                       {
                           MaLinhKien = lk.MaLinhKien,
                           TenLinhKien = lk.TenLinhKien,
                           MaDonViTinh = lk.DONVITINH.MaDonViTinh,
                           TenDonViTinh = lk.DONVITINH.TenDonViTinh,
                           MaNhaCungCap = lk.NHACUNGCAP.MaNhaCungCap,
                           TenNhaCungCap = lk.NHACUNGCAP.TenNhaCungCap,
                           MaThuongHieu = lk.THUONGHIEU.MaThuongHieu,
                           TenThuongHieu = lk.THUONGHIEU.TenThuongHieu,
                           GiaBanLe = lk.GiaBanLe,
                           GiaBanSi = lk.GiaBanSi,
                           GiaNhap = lk.GiaNhap,
                           TinhTrang = lk.TinhTrang,
                           ThoiGianBaoHanh = lk.ThoiGianBaoHanh,
                           MoTa = lk.MoTa
                       };
            var lks= lk1.ToList();
            lks.ForEach(x =>  x.InitOldData());
            return lks;
        }

        public static List<LinhKien_View> getAll_LinhKien_ByNCC(string MaNCC)
        {
            var lk1 = from lk in Context.getInstance().db.LINHKIENs
                      where lk.MaNhaCungCap == MaNCC
                      select new LinhKien_View()
                      {
                          MaLinhKien = lk.MaLinhKien,
                          TenLinhKien = lk.TenLinhKien,
                          TenDonViTinh = lk.DONVITINH.TenDonViTinh,
                          TenNhaCungCap = lk.NHACUNGCAP.TenNhaCungCap,
                          TenThuongHieu = lk.THUONGHIEU.TenThuongHieu,
                          GiaBanLe = lk.GiaBanLe,
                          GiaBanSi = lk.GiaBanSi,
                          GiaNhap = (decimal)lk.GiaNhap,
                          TinhTrang = lk.TinhTrang,
                          ThoiGianBaoHanh = (int)lk.ThoiGianBaoHanh,
                          MoTa = lk.MoTa
                      };
            return lk1.ToList();
        }

        public static bool saves(DataUpdate<LinhKien_View> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    //list.Inserts.ForEach(x => {
                    //    Context.getInstance().db.LINHKIENs.Add(x.toLinhKien());
                    //});

                    LINHKIEN lk = new LINHKIEN() {MaLinhKien= "LK006", MaThuongHieu= "SONY", MaNhaCungCap = "CC001",TenLinhKien =  "ten",GiaBanLe =  6456,GiaBanSi= 43434,MaDonViTinh = "DV003",TinhTrang= 1 };
                    LINHKIEN lk1 = new LINHKIEN() { MaLinhKien = "LK006", MaThuongHieu = "SONY", MaNhaCungCap = "CC001", TenLinhKien = "ten", GiaBanLe = 6456, GiaBanSi = 43434, MaDonViTinh = "DV003", TinhTrang = 1 };
                    LINHKIEN lk2 = new LINHKIEN() { MaLinhKien = "LK006", MaThuongHieu = "SONY", MaNhaCungCap = "CC001", TenLinhKien = "ten", GiaBanLe = 6456, GiaBanSi = 43434, MaDonViTinh = "DV003", TinhTrang = 1 };
                    Context.getInstance().db.LINHKIENs.Add(lk);
                   // Context.getInstance().db.LINHKIENs.Add(lk1);
                    //Context.getInstance().db.LINHKIENs.Add(lk2);

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }  

            return true;
        }

        public static bool Add_LinhKien(LinhKien_View item)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.LINHKIENs.Add(item.toLinhKien());
                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Context.getInstance().db.LINHKIENs.Local.Clear();
                    transaction.Rollback();
                    return false;
                }
            }
            return true;
        }

        public static string get_LinhKienMax()
        {
            try
            {
                string result = Context.getInstance().db.LINHKIENs.OrderByDescending(x => x.MaLinhKien).First().MaLinhKien;
                int index = (Convert.ToInt16((result).Substring(2)) + 1);
                if (index < 10)
                    return "LK00" + index;
                else if (index < 100)
                    return "LK0" + index;
                return "LK" + index;
            }
            catch (Exception)
            {
                return "LK001";
            }
        }
    }
}
