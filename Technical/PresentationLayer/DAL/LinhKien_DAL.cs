using PresentationLayer.GlobalVariable;
using PresentationLayer.View;
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
                           DonViTinh = lk.DONVITINH.TenDonViTinh,
                           MaNhaCungCap = lk.MaNhaCungCap,
                           MaDonViTinh = lk.MaDonViTinh,
                           MaThuongHieu = lk.MaThuongHieu,
                           GiaBanLe = lk.GiaBanLe,
                           GiaBanSi = lk.GiaBanSi,
                           TinhTrang = lk.TinhTrang,
                           MoTa = lk.MoTa,
                           ThuongHieu = lk.THUONGHIEU.TenThuongHieu
                       };
            var lks= lk1.ToList();
            lks.ForEach(x =>  x.InitOldData());
            return lks;
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
    }
}
