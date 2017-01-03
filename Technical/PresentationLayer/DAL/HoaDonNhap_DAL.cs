using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class HoaDonNhap_DAL
    {
        public static List<HoaDonNhap_View> getAll_HoaDonNhap()
        {
            var hd = from hoadon in Context.getInstance().db.HOADON_NHAPHANG
                     select new HoaDonNhap_View
                       {
                           MaHoaDon = hoadon.MaHoaDon,
                           NgayLap = hoadon.NgayLap,
                           NhanVien = hoadon.NHANVIEN.TenNhanVien,
                           MaNhanVien = hoadon.MaNguoiLap,
                           TongTien = hoadon.TongTien,
                           TrangThai = hoadon.TrangThai,
                           NhaCungCap = hoadon.NHACUNGCAP.TenNhaCungCap,
                           MaNhaCungCap = hoadon.MaNhaCungCap,
                           SoDienThoai = hoadon.NHACUNGCAP.SoDienThoai
                       };
            return hd.ToList();
        }

        public static HoaDonNhap_View get_HoaDonNhap_By_MaHD(string maHD)
        {
            var hd = from hoadon in Context.getInstance().db.HOADON_NHAPHANG
                     where hoadon.MaHoaDon == maHD
                     select new HoaDonNhap_View
                     {
                         MaHoaDon = hoadon.MaHoaDon,
                         NgayLap = hoadon.NgayLap,
                         NhanVien = hoadon.NHANVIEN1.TenNhanVien,
                         MaNhanVien = hoadon.MaNguoiLap,
                         TongTien = hoadon.TongTien,
                         TrangThai = hoadon.TrangThai,
                         NhaCungCap = hoadon.NHACUNGCAP.TenNhaCungCap,
                         MaNhaCungCap = hoadon.MaNhaCungCap,
                         SoDienThoai = hoadon.NHACUNGCAP.SoDienThoai,
                         MaNhanVienSua = hoadon.MaNguoiSua,
                         TenNhanVienSua = hoadon.NHANVIEN.TenNhanVien,
                         NgaySua = (DateTime)hoadon.NgaySua,
                         GhiChu = hoadon.GhiChu
                     };
            HoaDonNhap_View hdV = hd.ToList()[0];
            hdV.ChiTietHoaDon = CT_HoaDonNhap_DAL.get_CTHoaDonNhap_By_MaHD_TT01(hdV.MaHoaDon);
            hdV.InitOldData();
            if (hdV.TrangThai == 0)
                hdV.Mode = TT.DELETE;
            return hdV;
        }

        public static string get_HoaDonNhapMax()
        {
            try
            {
                string result = Context.getInstance().db.HOADON_NHAPHANG.OrderByDescending(x => x.MaHoaDon).First().MaHoaDon;
                int index = (Convert.ToInt16((result).Substring(2)) + 1);
                if (index < 10)
                    return "HD00" + index;
                else if (index < 100)
                    return "HD0" + index;
                return "HD" + index;
            }
            catch (Exception)
            {
                return "HD001";
            }
        }

        public static HoaDonNhap_View get_HoaDonNhap_By_Seri(string seri)
        {
            var hd = from hoadon in Context.getInstance().db.CT_HOADON_NHAPHANG
                     where hoadon.Seri == seri
                     select new HoaDonNhap_View
                     {
                         MaHoaDon = hoadon.MaHoaDon
                     };
            
            return get_HoaDonNhap_By_MaHD(hd.ToList()[0].MaHoaDon);
        }

        public static bool add_HoaDonNhap(HoaDonNhap_View hd, List<CT_HoaDonNhap_View> ct_hds)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    decimal phanTramLoiNhuanBanLe = decimal.Parse(HeThong_DAL.getHeThongByMa("HT002").GiaTri);
                    decimal phanTramLoiNhuanBanBuon = decimal.Parse(HeThong_DAL.getHeThongByMa("HT003").GiaTri);

                    Context.getInstance().db.Entry(hd.toHoaDonNhap()).State = System.Data.Entity.EntityState.Added;
                    Context.getInstance().db.SaveChanges();
                    LINHKIEN lk;
                    ct_hds.ForEach(x =>
                    {
                        foreach (var seri in x.SoSeri)
                        {
                            Context.getInstance().db.Entry(x.toCT_HoaDonNhap(seri)).State = System.Data.Entity.EntityState.Added;
                            //nhap kho
                            KHO myK = new KHO();
                            myK.MaLinhKien = x.MaLinhKien;
                            myK.Seri = seri;
                            myK.NgayNhap = hd.NgayLap;
                            myK.TrangThai = 1;
                            Context.getInstance().db.Entry(myK).State = System.Data.Entity.EntityState.Added;
                        }
                        lk = Context.getInstance().db.LINHKIENs.Where(key => key.MaLinhKien == x.MaLinhKien).FirstOrDefault();
                        if (lk.GiaNhap != x.GiaNhap)
                        {
                            lk.GiaNhap = x.GiaNhap;
                            lk.GiaBanLe = x.GiaNhap + (x.GiaNhap * phanTramLoiNhuanBanLe / 100);
                            lk.GiaBanSi = x.GiaNhap + (x.GiaNhap * phanTramLoiNhuanBanBuon / 100);
                            Context.getInstance().db.Entry(lk).State = System.Data.Entity.EntityState.Modified;
                        }
                    });
                    //update so tien nhap hang cua nha cc
                    NHACUNGCAP ncc = Context.getInstance().db.NHACUNGCAPs.Where(key => key.MaNhaCungCap == hd.MaNhaCungCap).FirstOrDefault();
                    ncc.Tong += hd.TongTien;
                    Context.getInstance().db.Entry(ncc).State = System.Data.Entity.EntityState.Modified;

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------" + ex.Message);
                    return false;
                }

            }
            return true;
        }

        public static bool del_HoaDon(HoaDonNhap_View hd, DataUpdate<CT_HOADON_NHAPHANG> list_Change)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    hd.TrangThai = 0;
                    Context.getInstance().db.Entry(hd.toHoaDonNhap()).State = System.Data.Entity.EntityState.Modified;

                    //list_Change.Inserts.ForEach(x =>
                    //{
                    //});

                    //list_Change.Updates.ForEach(x =>
                    //{
                    //    x.TinhTrang = 1;
                    //    Context.getInstance().db.Entry(getCTHD(x)).State = System.Data.Entity.EntityState.Modified;
                    //});

                    list_Change.Deletes.ForEach(x =>
                    {
                        //set trang thai = 0 o day
                        x.TinhTrang = 0;
                        Context.getInstance().db.Entry(getCTHD(x)).State = System.Data.Entity.EntityState.Modified;

                        //them trong kho
                        KHO kho = Context.getInstance().db.KHOes.Where(key => key.MaLinhKien == x.MaLinhKien).Where(k => k.Seri == x.Seri).FirstOrDefault();
                        kho.TrangThai = 0;
                        Context.getInstance().db.Entry(kho).State = System.Data.Entity.EntityState.Modified;
                    });

                    //update so tien nhap hang cua nha cung cap
                    NHACUNGCAP kh = Context.getInstance().db.NHACUNGCAPs.Where(key => key.MaNhaCungCap == hd.MaNhaCungCap).FirstOrDefault();
                    kh.Tong -= hd.TongTien;
                    Context.getInstance().db.Entry(kh).State = System.Data.Entity.EntityState.Modified;

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------" + ex.Message);
                    return false;
                }
            }
            return true;
        }

        private static CT_HOADON_NHAPHANG getCTHD(CT_HOADON_NHAPHANG x)
        {
            CT_HOADON_NHAPHANG ct = Context.getInstance().db.CT_HOADON_NHAPHANG.Where(key => key.MaHoaDon == x.MaHoaDon)
                                                                          .Where(key => key.MaLinhKien == x.MaLinhKien)
                                                                          .Where(key => key.Seri == x.Seri)
                                                                         .FirstOrDefault();
            if (ct == null)
            {
                ct = new CT_HOADON_NHAPHANG();
            }
            ct.ThanhTien = x.ThanhTien;
            ct.Thue = x.Thue;
            ct.TinhTrang = x.TinhTrang;
            ct.SoLuong = x.SoLuong;
            ct.GiaNhap = x.GiaNhap;
            ct.GhiChu = x.GhiChu;
            return ct;
        }

        public static bool update_HoaDon(HoaDon_View hd, List<CT_HoaDon_View> ct_hds)
        {

            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(hd.toHoaDon()).State = System.Data.Entity.EntityState.Modified;

                    ct_hds.ForEach(x =>
                    {
                        Context.getInstance().db.CT_HOADON.Add(x.toCT_HoaDon());
                    });

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Context.getInstance().db.HOADONs.Local.Clear();
                    Context.getInstance().db.CT_HOADON.Local.Clear();
                    transaction.Rollback();
                    return false;
                }
            }
            return true;
        }

        internal static List<HoaDonNhap_View> getAll_HoaDonNhap_TheoThoiGian(DateTime startD, DateTime endD)
        {
            var hd = from hoadon in Context.getInstance().db.HOADON_NHAPHANG
                     where hoadon.NgayLap >= startD.Date
                     where hoadon.NgayLap <= endD.Date
                     select new HoaDonNhap_View
                     {
                         MaHoaDon = hoadon.MaHoaDon,
                         NgayLap = hoadon.NgayLap,
                         NhanVien = hoadon.NHANVIEN.TenNhanVien,
                         MaNhanVien = hoadon.MaNguoiLap,
                         TongTien = hoadon.TongTien,
                         TrangThai = hoadon.TrangThai,
                         NhaCungCap = hoadon.NHACUNGCAP.TenNhaCungCap,
                         MaNhaCungCap = hoadon.MaNhaCungCap,
                         SoDienThoai = hoadon.NHACUNGCAP.SoDienThoai,
                         GhiChu = hoadon.GhiChu,
                         MaNhanVienSua = hoadon.MaNguoiSua,
                         TenNhanVienSua = hoadon.NHANVIEN1.TenNhanVien,
                         NgaySua = (DateTime)hoadon.NgaySua
                     };
            var khp = hd.ToList();
            foreach (var item in khp)
            {
                item.ChiTietHoaDon = CT_HoaDonNhap_DAL.get_CTHoaDonNhap_By_MaHD_TT01(item.MaHoaDon);
                item.InitOldData();
                if (item.TrangThai == 0)
                    item.Mode = TT.DELETE;
            }
            return khp;
        }

        public static List<HoaDonNhap_View> searchSeri(string seri)
        {
            var hd = from hoadon in Context.getInstance().db.CT_HOADON_NHAPHANG
                     where hoadon.Seri.Contains(seri)
                     select new HoaDonNhap_View
                     {
                         MaHoaDon = hoadon.MaHoaDon
                     };
            List<string> lstMaHD = new List<string>();
            List<HoaDonNhap_View> lstHDV = new List<HoaDonNhap_View>();
            if (hd != null)
            {
                foreach (var item in hd.ToList())
                {
                    if (lstHDV.Where(key => key.MaHoaDon == item.MaHoaDon).FirstOrDefault() == null)
                    {
                        lstHDV.Add(get_HoaDonNhap_By_MaHD(item.MaHoaDon));
                    }
                }
                return lstHDV;
            }

            return null;
        }
    }
}
